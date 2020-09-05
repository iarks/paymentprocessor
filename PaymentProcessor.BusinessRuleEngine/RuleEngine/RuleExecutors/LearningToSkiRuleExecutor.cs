using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors
{
    class LearningToSkiRuleExecutor:IRuleExecutor
    {
        public void Execute(Payment payment)
        {
            Console.WriteLine("Adding First Aid video");

        }
    }
}
