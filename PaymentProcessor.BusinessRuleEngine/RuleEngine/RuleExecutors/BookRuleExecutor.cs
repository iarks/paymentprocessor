using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors
{
    public class BookRuleExecutor : IRuleExecutor
    {
        public void Execute(Payment payment)
        {
            Console.WriteLine("Generating Duplicate packing slip");
            Console.WriteLine("Generating Comission Payment");
        }
    }
}
