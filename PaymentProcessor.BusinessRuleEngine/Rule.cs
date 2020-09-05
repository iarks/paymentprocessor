using PaymentProcessor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
