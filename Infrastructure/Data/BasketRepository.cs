using System.Text.Json;
using Core.Entities;
using Core.Interfaces;
using StackExchange.Redis;

namespace Infrastructure.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }
        /*
         * baskets are stored as string in redis database
         * take our obj(our json that comes up from the client) and serialize into a string which is stored in redis DB as string
         * when we want to get it our, we need to de-serialize it into something<customerBasket> we can use in customerBasket
         */

        public async Task<CustomerBasket> GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);
            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }
        /*
         * If we are updating a basket we are replacing existing basket in redis DB with what ever coming up from client as new basket
         * we won't update individual values, we replace existing strings represent our DB with the new version of this basket
         * TimeToLive is Busniness Desicion , think about these questions :
         * How Many Customer WE likely to have? 
         * How many basket are going to live in memory? 
         * how much memory we have in our server ?
         * What make sense from a buisness point of view of how long you should store this information in the server ?
         */
        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(30));
            if(!created) return null;
            return await GetBasketAsync(basket.Id); // we used this method again cause it already Deserialized 
        }
    }
}
