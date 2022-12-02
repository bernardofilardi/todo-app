using ToDo.Application.Dtos.Item;

namespace ToDo.Application.Interfaces
{
    public interface IItemAppService
    {
        Task<IEnumerable<ItemResponseDto>> GetItemsAsync();

        Task CreateItemAsync(CreateItemRequestDto dto);

        Task UpdateItem(Guid id);

        Task RemoveItem(Guid id);
    }
}
