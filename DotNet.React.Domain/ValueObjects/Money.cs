using DotNet.React.Domain.Common;

namespace DotNet.React.Domain.ValueObjects
{
    public sealed record Money
    {
        private Money() { Currency = null!; }
        public decimal Amount { get; }
        public string Currency { get; }
        public Money(decimal amount, string currency)
        {
            if (amount < 0)
                throw new DomainException(
                    "Money amount cannot be negative.");
            if (string.IsNullOrWhiteSpace(currency))
                throw new DomainException(
                    "Currency is required.");
            Amount = amount;
            Currency = currency.ToUpperInvariant();
        }

        public static Money Zero(string currency)
       => new(0, currency);

        public Money Add(Money other)
        {
            EnsureSameCurrency(other);

            return new Money(
                Amount + other.Amount,
                Currency);
        }

        public Money Subtract(Money other)
        {
            EnsureSameCurrency(other);

            return new Money(
                Amount - other.Amount,
                Currency);
        }

        private void EnsureSameCurrency(Money other)
        {
            if (Currency != other.Currency)
            {
                throw new DomainException(
                    "Currency mismatch.");
            }
        }
    }
}
