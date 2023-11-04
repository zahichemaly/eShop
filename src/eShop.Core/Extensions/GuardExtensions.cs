using Ardalis.GuardClauses;
using eShop.Core.Entities;
using eShop.Core.Exceptions;

namespace eShop.Core.Extensions
{
    public static class GuardExtensions
    {
        public static void EmptyBasketOnCheckout(this IGuardClause guardClause, IReadOnlyCollection<BasketItem> basketItems)
        {
            if (!basketItems.Any()) throw new EmptyBasketOnCheckoutException();
        }
    }
}
