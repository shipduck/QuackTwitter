using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuackTwitter
{
    partial class Twitter
    {
        public IList<TwitterStatus> FavoritesList(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(GET(Constants.FavoritesURL + "/list.json", parameters));
        }

        async public Task<IList<TwitterStatus>> FavoritesListAsync(IDictionary<string, string> parameters = null)
        {
            return JsonConvert.DeserializeObject<IList<TwitterStatus>>(await GETasync(Constants.FavoritesURL + "/list.json", parameters));
        }

        public TwitterStatus FavoritesDestroy(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.FavoritesURL + "/destroy.json", parameters));
        }

        async public Task<TwitterStatus> FavoritesDestroyAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(await POSTasync(Constants.FavoritesURL + "/destroy.json", parameters));
        }

        public TwitterStatus FavoritesCreate(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(POST(Constants.FavoritesURL + "/create.json", parameters));
        }

        async public Task<TwitterStatus> FavoritesCreateAsync(IDictionary<string, string> parameters)
        {
            Utils.RequiredParameters(parameters, "id");

            return JsonConvert.DeserializeObject<TwitterStatus>(await POSTasync(Constants.FavoritesURL + "/create.json", parameters));
        }
    }
}
