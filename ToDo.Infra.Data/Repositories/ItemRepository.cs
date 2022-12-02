using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using ToDo.Domain.Entities;
using ToDo.Domain.Interface;

namespace ToDo.Infra.Data.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _connectionString;
        public ItemRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ToDoDb");
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            IEnumerable<Item> result;
            var query = "select * from Items";
            using (var con = new SqlConnection(_connectionString))
            {   
                try
                {
                    con.Open();
                    result = await con.QueryAsync<Item>(query);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
                return result;
            };

        }

        public async Task AddAsync(Item item)
        {
            var query = "insert into Items(Id, Description, Done, CreatedAt) values(@Id, @Description, @Done, @CreatedAt)";
            using (var con = new SqlConnection(_connectionString))
            {    
                try
                {
                    con.Open();
                    await con.ExecuteAsync(query, item);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            };
        }

        public async Task EditAsync(Item item)
        {

            var query = "update Items set Done = @Done where id = @Id";
            var parameters = new
            {
                Done = item.Done,
                Id = item.Id
            };
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    await con.ExecuteAsync(query, parameters);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            };
        }

        public Item GetOne(Guid id)
        {
            Item item;
            var query = "select * from Items where id = @Id";
            var parameters = new { Id = id };
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    item = con.QuerySingle<Item>(query, parameters);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            };
            return item;

        }

        public async Task RemoveAsync(Guid id)
        {
            var query = "delete from Items where id = @Id";
            var parameters = new { Id = id };
            using (var con = new SqlConnection(_connectionString))
            {
                try
                {
                    con.Open();
                    await con.ExecuteAsync(query, parameters);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    con.Close();
                }
            };

        }
    }
}
