using PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions;
using PaymentProcessor.Entities;
using System;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.RuleExecutors
{
    class LearningToSkiRuleExecutor : IRuleExecutor
    {
        public void Execute(Payment payment)
        {
            Console.WriteLine("Adding First Aid video");
            Console.WriteLine("");
        }
    }
}
