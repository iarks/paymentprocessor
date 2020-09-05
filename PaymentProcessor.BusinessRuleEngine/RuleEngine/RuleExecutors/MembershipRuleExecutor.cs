using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors
{
    class MembershipRuleExecutor:IRuleExecutor
    {
        public void Execute(Payment payment)
        {
            Console.WriteLine("Activate Membership");
            Console.WriteLine("Activate membership sent");
        }
    }
}
