using ToDo.Domain.Entities;

namespace ToDo.Domain.Interface
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task AddAsync(Item item);
        Task EditAsync(Item item);
        Item GetOne(Guid id);
        Task RemoveAsync(Guid id);
    }
}
