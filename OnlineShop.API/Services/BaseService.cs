using OnlineShop.Domain.Interfaces;

namespace OnlineShop.API.Services;

public class BaseService
{
    public IUnitOfWork UnitOfWork { get; }

    public BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}