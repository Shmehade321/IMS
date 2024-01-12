using IMS.CoreBusiness;

namespace IMS.UseCases;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
}
