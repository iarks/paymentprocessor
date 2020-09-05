using PaymentProcessor.BusinessRuleEngine;
using PaymentProcessor.BusinessRuleEngine.RuleEngine;
using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using PaymentProcessor.Service;
using System;
using System.Collections.Generic;

namespace paymentprocessor
{
    public class Program
    {
        private List<PaymentRule> paymentRules;

        private List<PaymentProcessor.Entities.Payment> payments;

        private List<Rule> paymentRulesAsPredicates;

        /// <summary>
        /// This dictionary holds the compiles rule methods. 
        /// <para>Ideally, this would be declared as a singleton in a larger application</para> 
        /// </summary>
        private Dictionary<string, IRuleExecutor> ruleInstanceToExecute;

        private void Setup()
        {
            // List of rules
            // ideally these would come from a database or a config file
            // See readme for schema details
            paymentRules = new List<PaymentRule>()
            {
                new PaymentRule
                {
                    Parameter = "PaymentFor",
                    Operation="Equal",
                    Constant="Physical Product",
                    RuleInstance = "PhysicalProductRuleExecutor"
                },
                new PaymentRule
                {
                    Parameter = "PaymentFor",
                    Operation="Equal",
                    Constant="Book",
                    RuleInstance = "BookRuleExecutor"
                },
                new PaymentRule
                {
                    Parameter = "PaymentFor",
                    Operation="Equal",
                    Constant="Membership",
                    RuleInstance = "MembershipRuleExecutor"
                },
                new PaymentRule
                {
                    Parameter = "PaymentFor",
                    Operation="Equal",
                    Constant="MembershipUpgrade",
                    RuleInstance = "MembershipUpgradeRuleExecutor"
                },
                new PaymentRule
                {
                    Parameter = "PaymentFor",
                    Operation="Equal",
                    Constant="Learning To Ski",
                    RuleInstance = "LearningToSkiRuleExecutor"
                },

            };

            // List of payments made
            // Ideally this would come from somewhere in the application
            payments = new List<PaymentProcessor.Entities.Payment>()
            {
                new PaymentProcessor.Entities.Payment("Physical Product", 123.00F, new { }),
                new PaymentProcessor.Entities.Payment("Membership", 120F, new { })
            };

            // compile all rules from database into predicates
            // This should be done in application startup, when all rules are loaded into the system
            paymentRulesAsPredicates = new List<Rule>();
            foreach (var paymentRule in paymentRules)
            {
                string ruleInstance;
                paymentRulesAsPredicates.Add(new Rule
                {
                    RulePredicate = ExpressionBuilder<PaymentProcessor.Entities.Payment>.GenerateExpression(paymentRule,
                        out ruleInstance).Compile(),
                    RuleInstanceName = ruleInstance
                });
            }

            // generate each business rule method instance for the rule and cache it in a dictionary
            // this is done at runtime so that new rule instances can be created when new rules are
            // added to the database
            // this should be done in application startup
            ruleInstanceToExecute = new Dictionary<string, IRuleExecutor>();
            foreach (var paymentRulePredicate in paymentRulesAsPredicates)
            {
                var typeName = paymentRulePredicate.RuleInstanceName;
                string objectToInstantiate = $"PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors.{typeName}, PaymentProcessor.BusinessRuleEngine";
                var objectType = Type.GetType(objectToInstantiate);
                var instantiatedObject = Activator.CreateInstance(objectType);
                ruleInstanceToExecute.Add(typeName, instantiatedObject as IRuleExecutor);
            }
        }


        public void PaymentService_CheckRulesForPayment()
        {

            Setup();

            // This is the business logic as follows.

            // in a real application, the dependencies of this payment service will be generated and injected using some kind of container
            // In a .NET core prod application, this payment service itself should be registered in a container and injected where required
            // Also, this payment service would be async
            var sut = new PaymentService(paymentRulesAsPredicates, ruleInstanceToExecute);

            _ = sut.CheckRulesForPayments(payments);
        }
    }
}
