using PaymentProcessor.Entities;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine.Abstractions
{
    /// <summary>
    /// Serves as the parent class of all rule execution instances
    /// </summary>
    public interface IRuleExecutor
    {
        /// <summary>
        /// The rule logic to execute
        /// </summary>
        /// <param name="payment">the payment object</param>
        void Execute(Payment payment);
    }
}
