using AutoMapper;
using ToDo.Application.Dtos.Item;
using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;

namespace ToDo.Application.AppServices
{
    public class ItemAppService : IItemAppService
    {
        private readonly IItemRepository repository;
        private readonly IMapper mapper;

        public ItemAppService(IItemRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task CreateItemAsync(CreateItemRequestDto dto)
        {
            try
            {
                var item = new Item(dto.Description);
                await repository.AddAsync(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateItem(Guid id)
        {
            try
            {
                Item item = repository.GetOne(id);
                
                item.Done = item.Done.Equals(true) ? false : true;

                await repository.EditAsync(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task RemoveItem(Guid id)
        {
            try
            {
                await repository.RemoveAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<ItemResponseDto>> GetItemsAsync()
        {
            try
            {
                var response = await repository.GetAllAsync();
                return mapper.Map<IEnumerable<ItemResponseDto>>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}