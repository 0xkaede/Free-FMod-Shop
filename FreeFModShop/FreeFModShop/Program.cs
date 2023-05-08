//
// Created by 0xkaede
//

using Newtonsoft.Json;
using RestSharp;

namespace FreeFModShop
{
    internal class Program
    {
        private static readonly string ID = "User ID Here";
        private static readonly string Bearer = "Bearer Here";

        public static async Task Main(string[] args)
        {
            Console.Title = "Free Fmod items by 0xkaede";
            Console.WriteLine("Created by 0xkaede thank you for using! Be warned you will go into minus vbucks!");

            foreach (var id in await GetFmodOfferIds())
                await PurchaseItem(id);

            Console.WriteLine("Done!");
            Console.Read();
        }

        public async static Task<List<string>> GetFmodOfferIds()
        {
            var Idlist = new List<string>();

            try
            {
                var data = JsonConvert.DeserializeObject<StoreFrontRoot>
                    (await new HttpClient().GetStringAsync(new Uri("https://api.fmod.dev/fortnite/api/storefront/v2/catalog")));

                if (data is null)
                    return Idlist;

                foreach (var storeFront in data.Storefronts)
                {
                    if (storeFront.Name is "BRSeasonStorefront")
                        continue;

                    foreach (var catalogEntries in storeFront.CatalogEntries)
                        Idlist.Add(catalogEntries.OfferId);
                }

                return Idlist;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when getting Shop Offsets, Message: {ex.Message}");
                Console.Read();
                return Idlist;
            }
        }

        public async static Task PurchaseItem(string offerId)
        {
            var item = new PostItem
            {
                OfferId = offerId,
                PurchaseQuantity = 1,
                Currency = "MtxCurrency",
                CurrencySubType = string.Empty,
                ExpectedTotalPrice = 0,
                GameContext = string.Empty
            };

            var options = new RestClientOptions("https://api.fmod.dev")
            {
                MaxTimeout = -1,
                UserAgent = " Fortnite/++Fortnite+Release-8.51-CL-6165369 Windows/10.0.19045.1.768.64bit",
            };

            var client = new RestClient(options);
            var request = new RestRequest($"/fortnite/api/game/v2/profile/{ID}/client/PurchaseCatalogEntry?profileId=common_core&rvn=17/fortnite/api/game/v2/profile/b5w05lhys5963f4vjvg3cyyvf77vfuni/client/PurchaseCatalogEntry?profileId=common_core&rvn=17", Method.Post)
                .AddHeader("Content-Type", "application/json")
                .AddHeader("X-EpicGames-AnalyticsSessionId", "{1B94E773-4A2A-4D03-5F1D-F79261A8204F}")
                .AddHeader("X-EpicGames-GameSessionId", "FRONTEND-14B5C7BF4BCE0246CA7E52BA7D3FE755")
                .AddHeader("X-EpicGames-ProfileRevisions", "[{\"profileId\":\"common_public\",\"clientCommandRevision\":0},{\"profileId\":\"common_core\",\"clientCommandRevision\":17},{\"profileId\":\"athena\",\"clientCommandRevision\":29}]")
                .AddHeader("X-Epic-Correlation-ID", "FN-5OXtiiYSTEWn27WpNcVAGg")
                .AddHeader("Authorization", $"bearer {Bearer}")
                .AddStringBody(JsonConvert.SerializeObject(item), DataFormat.Json);

            var response = await client.ExecuteAsync(request);

            if (response.StatusCode is System.Net.HttpStatusCode.OK)
                Console.WriteLine($"{offerId} was purchaced.");
            else
                Console.WriteLine($"Error when trying to Purchase {offerId}. CODE: {response.StatusCode}");

        }
    }
}