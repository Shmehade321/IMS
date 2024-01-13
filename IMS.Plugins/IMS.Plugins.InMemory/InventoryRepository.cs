using IMS.CoreBusiness;
using IMS.UseCases;

namespace IMS.Plugins.InMemory;

public class InventoryRepository : IInventoryRepository
{
    private List<Inventory> _inventories;
    public InventoryRepository()
    {
        _inventories = new List<Inventory>()
        {
            new Inventory() { Id = 1, Name = "Apple", Quantity = 10, Price = 1.99 },
            new Inventory() { Id = 2, Name = "Orange", Quantity = 20, Price = 2.99 },
            new Inventory() { Id = 3, Name = "Banana", Quantity = 30, Price = 3.99 },
            new Inventory() { Id = 4, Name = "Pineapple", Quantity = 40, Price = 4.99 },
            new Inventory() { Id = 5, Name = "Watermelon", Quantity = 50, Price = 5.99 },
        };
    }

    public Task AddInventoryAsync(Inventory inventory)
    {
        if(_inventories.Any(x => x.Name.Equals(inventory.Name, StringComparison.OrdinalIgnoreCase)))
            return Task.CompletedTask;
        
        var maxId = _inventories.Max(x => x.Id);
        inventory.Id = maxId + 1;

        _inventories.Add(inventory);
        return Task.CompletedTask;
    }

    public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string name)
    {
        if(string.IsNullOrWhiteSpace(name)) return await Task.FromResult(_inventories);

        return await Task.FromResult(_inventories.Where(i => i.Name.Contains(name, StringComparison.OrdinalIgnoreCase)));
    }
}
