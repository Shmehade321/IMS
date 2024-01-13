using IMS.CoreBusiness;

namespace IMS.UseCases;

public class AddInventoryUseCase : IAddInventoryUseCase
{
    private readonly IInventoryRepository _inventoryRepository;

    public AddInventoryUseCase(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task ExecuteAsync(Inventory inventory)
    {
        await _inventoryRepository.AddInventoryAsync(inventory);
    }
}
