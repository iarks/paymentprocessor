using PaymentProcessor.BusinessRuleEngine;
using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;
using System.Collections.Generic;

namespace PaymentProcessor.Service
{
   public class PaymentService
   {
        public PaymentService(List<Rule> paymentRulesAsPredicates,
           Dictionary<string, IRuleExecutor> ruleInstanceToExecute)
        {
           
        }

        public BusinessEntity CheckRulesForPayments(List<Payment> payments)
        {
           
            return new BusinessEntity();
        }


    }
}
