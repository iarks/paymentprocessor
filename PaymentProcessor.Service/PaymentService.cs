using PaymentProcessor.BusinessRuleEngine;
using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentProcessor.Service
{
    public class PaymentService
    {
        private readonly List<Rule> _paymentRulesAsPredicates;
        private readonly Dictionary<string, IRuleExecutor> _ruleInstanceToExecute;

        public PaymentService(List<Rule> paymentRulesAsPredicates,
           Dictionary<string, IRuleExecutor> ruleInstanceToExecute)
        {
            _paymentRulesAsPredicates = paymentRulesAsPredicates;
            _ruleInstanceToExecute = ruleInstanceToExecute;
        }

        public BusinessEntity CheckRulesForPayments(List<PaymentProcessor.Entities.Payment> payments)
        {
            try
            {
                foreach (var predicatedRules in _paymentRulesAsPredicates)
                {
                    // this contains all the payments that matches the rule
                    var paymentsThatMatchRule = payments.Where(predicatedRules.RulePredicate).ToList();

                    // now execute the rule logic for the payments.
                    foreach (var payment in paymentsThatMatchRule)
                    {
                        if (_ruleInstanceToExecute.ContainsKey(predicatedRules.RuleInstanceName))
                        {
                            _ruleInstanceToExecute[predicatedRules.RuleInstanceName].Execute(payment);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                // log the error
                Console.WriteLine(ex.Message);
                throw;
            }
            return new BusinessEntity { IsSuccess = true };
        }


    }
}
