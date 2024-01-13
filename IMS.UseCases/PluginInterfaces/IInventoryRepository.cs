using IMS.CoreBusiness;

namespace IMS.UseCases;

public interface IInventoryRepository
{
    Task AddInventoryAsync(Inventory inventory);
    Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name);
}
