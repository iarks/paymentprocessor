using PaymentProcessor.Entities;
using System;
using System.Linq.Expressions;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine
{
    public static class ExpressionBuilder<T> where T : class
    {
        /// <summary>
        /// Converts a rule obtained from db into a compile-able predicate
        /// </summary>
        /// <param name="rule">the rule entity to be converted into expression</param>
        /// <param name="ruleInstance">the name of the rule instance to register this rule with</param>
        /// <returns>The compileable expression</returns>
        public static Expression<Func<T, bool>> GenerateExpression(PaymentRule rule,
            out string ruleInstance)
        {
            // extract the name of the property to match
            var prop = typeof(T).GetProperty(rule.Parameter);

            if (prop != null)
            {
                // generate the parameter to match. This name can be anything, but it should be of the generic type.
                // This ensures that our expression has some amount of type safety
                var parameter = Expression.Parameter(typeof(T), "prop");

                // generate the left expression from the parameter
                var leftExpression = Expression.Property(parameter, rule.Parameter);

                // generate the constant expression to match against
                var constantExpression = Expression.Constant(rule.Constant, typeof(string));

                // check if the expression can be parsed
                if (ExpressionType.TryParse(rule.Operation, out ExpressionType operation))
                {
                    var expression = Expression.MakeBinary(operation, leftExpression, constantExpression);
                    ruleInstance = rule.RuleInstance;
                    return Expression.Lambda<Func<T, bool>>(expression, parameter);
                }
                ruleInstance = null;
                return null;
            }
            ruleInstance = null;
            return null;

        }
    }
}
