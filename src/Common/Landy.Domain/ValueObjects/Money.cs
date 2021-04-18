using System.Collections.Generic;

namespace Landy.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public decimal Value { get; }
        public string Currency { get; }

        private Money() { }

        public Money(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }
    }
}