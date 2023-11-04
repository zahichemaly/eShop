using eShop.Core.Entities;
using eShop.Core.Interfaces;

namespace eShop.Application.Services
{
    public class BasketService
    {
        private readonly IRepository<Basket> _basketRepository;
        private readonly IAppLogger<BasketService> _logger;

        public BasketService(IRepository<Basket> basketRepository,
            IAppLogger<BasketService> logger)
        {
            _basketRepository = basketRepository;
            _logger = logger;
        }
    }
}
