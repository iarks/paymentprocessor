using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors
{
    public class PhysicalProductRuleExecutor:IRuleExecutor
    {
        public void Execute(Payment payment)
        {
            Console.WriteLine("Generating Packing Slip");
            Console.WriteLine("Generating Comission Payment");
        }
    }
}
