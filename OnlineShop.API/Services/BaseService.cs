using OnlineShop.Domain.Interfaces;

namespace OnlineShop.API.Services;

public class BaseService
{
    private protected IUnitOfWork UnitOfWork { get; }

    private protected BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}