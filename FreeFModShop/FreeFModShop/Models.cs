using Newtonsoft.Json;

namespace FreeFModShop
{
    public class PostItem
    {
        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("purchaseQuantity")]
        public int PurchaseQuantity { get; set; } = 1;

        [JsonProperty("currency")]
        public string Currency { get; set; } = "MtxCurrency";

        [JsonProperty("currencySubType")]
        public string CurrencySubType { get; set; } = string.Empty;

        [JsonProperty("expectedTotalPrice")]
        public int ExpectedTotalPrice { get; set; } = 0;

        [JsonProperty("gameContext")]
        public string GameContext { get; set; } = string.Empty;
    }

    public class CatalogEntry
    {
        [JsonProperty("devName")]
        public string DevName { get; set; }

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("fulfillmentIds")]
        public List<object> FulfillmentIds { get; set; }

        [JsonProperty("dailyLimit")]
        public int DailyLimit { get; set; }

        [JsonProperty("weeklyLimit")]
        public int WeeklyLimit { get; set; }

        [JsonProperty("monthlyLimit")]
        public int MonthlyLimit { get; set; }

        [JsonProperty("categories")]
        public List<string> Categories { get; set; }

        [JsonProperty("prices")]
        public List<Price> Prices { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("matchFilter")]
        public string MatchFilter { get; set; }

        [JsonProperty("filterWeight")]
        public int FilterWeight { get; set; }

        [JsonProperty("appStoreId")]
        public List<object> AppStoreId { get; set; }

        [JsonProperty("requirements")]
        public List<Requirement> Requirements { get; set; }

        [JsonProperty("offerType")]
        public string OfferType { get; set; }

        [JsonProperty("giftInfo")]
        public GiftInfo GiftInfo { get; set; }

        [JsonProperty("refundable")]
        public bool Refundable { get; set; }

        [JsonProperty("metaInfo")]
        public List<object> MetaInfo { get; set; }

        [JsonProperty("displayAssetPath")]
        public string DisplayAssetPath { get; set; }

        [JsonProperty("itemGrants")]
        public List<ItemGrant> ItemGrants { get; set; }

        [JsonProperty("sortPriority")]
        public int SortPriority { get; set; }

        [JsonProperty("catalogGroupPriority")]
        public int CatalogGroupPriority { get; set; }
    }

    public class GiftInfo
    {
    }

    public class ItemGrant
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("templateId")]
        public string TemplateId { get; set; }
    }

    public class Meta
    {
    }

    public class Price
    {
        [JsonProperty("currencyType")]
        public string CurrencyType { get; set; }

        [JsonProperty("currencySubType")]
        public string CurrencySubType { get; set; }

        [JsonProperty("regularPrice")]
        public int RegularPrice { get; set; }

        [JsonProperty("finalPrice")]
        public int FinalPrice { get; set; }

        [JsonProperty("saleExpiration")]
        public DateTime SaleExpiration { get; set; }

        [JsonProperty("basePrice")]
        public int BasePrice { get; set; }
    }

    public class Requirement
    {
        [JsonProperty("requirementType")]
        public string RequirementType { get; set; }

        [JsonProperty("requiredId")]
        public string RequiredId { get; set; }

        [JsonProperty("minQuantity")]
        public int MinQuantity { get; set; }
    }

    public class StoreFrontRoot
    {
        [JsonProperty("refreshIntervalHrs")]
        public int RefreshIntervalHrs { get; set; }

        [JsonProperty("dailyPurchaseHrs")]
        public int DailyPurchaseHrs { get; set; }

        [JsonProperty("expiration")]
        public DateTime Expiration { get; set; }

        [JsonProperty("storefronts")]
        public List<Storefront> Storefronts { get; set; }
    }

    public class Storefront
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("catalogEntries")]
        public List<CatalogEntry> CatalogEntries { get; set; }
    }
}
