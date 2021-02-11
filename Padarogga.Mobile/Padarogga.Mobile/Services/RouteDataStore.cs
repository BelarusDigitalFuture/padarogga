using Padarogga.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;


namespace Padarogga.Mobile.Services
{
    public class RouteDataStore : IDataStore<RouteDto>
    {
        List<RouteDto> items;
        string baseAddress = "https://localhost:44308";
        public RouteDataStore()
        {
            items = new List<RouteDto>()
            {
                new RouteDto()
                {
                    Name = "Замки. Зубры. Пивоварни.",
                    Description = "В течение года в календаре встречается несколько праздничных дат, которые немного длиннее привычных выходных, " +
                    "но при этом гораздо короче среднестатистического отпуска.К примеру, приближающиеся ноябрьские праздники. Три дня отдыха и вопрос 'как лучше распорядиться свободным временем?'." +
                    "Наше предложение — отправиться путешествовать. Быстро, насыщенно и, главное, не потратив ни минуты на оформление документов.Речь идет о необычных достопримечательностях Республики Беларусь, с которыми наверняка знаком не каждый российский турист. " +
                    "О том, как за три дня увидеть пять замков, посмотреть на зубров и выпить пива по рецептам 1872 года",
                    CategoryName = "Туризм",
                    Difficulty = Difficulty.Easy,
                    Duration = 2,
                    Rating = 4,
                    Comments = 10,
                    Favorites = 7
                }
            };
        }

        public async Task<bool> AddItemAsync(RouteDto item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var oldItem = items.Where((RouteDto arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<RouteDto> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<RouteDto>> GetItemsAsync(bool forceRefresh = false)
        {
            //var address = $"{baseAddress}/routes";
            //items = await address.GetJsonAsync<List<RouteDto>>();
            
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(RouteDto item)
        {
            var oldItem = items.Where((RouteDto arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}
