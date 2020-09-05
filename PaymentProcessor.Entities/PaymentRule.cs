using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcessor.Entities
{
    /// <summary>
    /// The payment rule class is the class that will hold the rule for the payment service
    /// </summary>
    public class PaymentRule
    {
        /// <summary>
        /// The Id
        /// </summary>
        public string RuleId { get; set; }

        /// <summary>
        /// The operation the rule is checking.
        /// </summary>
        public string Operation { get; set; }

        /// <summary>
        /// The name of the parameter to check for against predicates
        /// </summary>
        public string Parameter { get; set; }

        /// <summary>
        /// The constant to check against.
        /// For this case, the constants represent the item bought
        /// </summary>
        public string Constant { get; set; }

        /// <summary>
        /// A string representing the rule
        /// </summary>
        public string RuleName { get; set; }

        /// <summary>
        /// The the rule instance to call when executing a rule logic
        /// </summary>
        public string RuleInstance { get; set; }
    }
}
