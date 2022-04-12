using OnlineShop.Domain.Interfaces;

namespace OnlineShop.Domain.Base;

public class BaseService
{
    public IUnitOfWork UnitOfWork { get; }

    public BaseService(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}