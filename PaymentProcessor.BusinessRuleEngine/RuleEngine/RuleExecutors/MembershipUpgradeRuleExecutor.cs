using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors
{
    class MembershipUpgradeRuleExecutor : IRuleExecutor
    {
        public void Execute(Payment payment)
        {
            Console.WriteLine("Upgrading membership");
            Console.WriteLine("Upgrade Email sent");
            Console.WriteLine("");
        }
    }
}
