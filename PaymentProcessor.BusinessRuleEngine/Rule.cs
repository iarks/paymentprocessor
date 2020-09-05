using PaymentProcessor.Entities;
using System;

namespace PaymentProcessor.BusinessRuleEngine
{
    /// <summary>
    /// Holds the rule execution predicates
    /// </summary>
    public class Rule
    {

        public Func<Payment, bool> RulePredicate { get; set; }

        public string RuleInstanceName { get; set; }
    }
}
