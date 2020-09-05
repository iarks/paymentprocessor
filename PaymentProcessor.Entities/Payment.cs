namespace PaymentProcessor.Entities
{
    /// <summary>
    /// The payment class serves as a business entity that holds the transaction
    /// </summary>
    public class Payment
    {
        public Payment(string paymentFor, float paidAmount, object item)
        {
            PaidAmount = paidAmount;
            PaymentFor = paymentFor;
            Item = item;
        }

        /// <summary>
        /// This property the payment to the rule engine.
        /// In production code, this should probably be changed to an enum
        /// </summary>
        public string PaymentFor { get; set; }

        /// <summary>
        /// The amount paid
        /// </summary>
        public float PaidAmount { get; set; }

        /// <summary>
        /// The actual item associated with the payment
        /// This could be a book, a video, a physical product, etc.
        /// </summary>
        public object Item { get; set; }
    }
}
