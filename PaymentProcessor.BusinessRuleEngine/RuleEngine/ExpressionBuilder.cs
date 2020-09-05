using PaymentProcessor.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace PaymentProcessor.BusinessRuleEngine.RuleEngine
{
    public static class ExpressionBuilder<T> where T : class
    {
        public static Expression<Func<T, bool>> GenerateExpression(PaymentRule rule, 
            out string ruleInstance)
        {
            ruleInstance = string.Empty;
            return null;
        }
    }
}
