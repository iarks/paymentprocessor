using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors
{
    public class BookRuleExecutor : IRuleExecutor
    {
        public void Execute(Payment payment)
        {
            Console.WriteLine("Generating Duplicate packing slip");
            Console.WriteLine("Generating Comission Payment");
            Console.WriteLine("");
        }
    }
}
