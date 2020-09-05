using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors
{
    public class PhysicalProductRuleExecutor : IRuleExecutor
    {
        public void Execute(Payment payment)
        {
            Console.WriteLine("Generating Packing Slip");
            Console.WriteLine("Generating Comission Payment");
        }
    }
}
