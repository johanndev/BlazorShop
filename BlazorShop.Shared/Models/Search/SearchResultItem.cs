namespace BlazorShop.Shared.Models.Search
{
    public class SearchResultItem
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Vendor { get; set; }
        public string Title { get; set; }
        public string HtmlDescription { get; set; }
        public string Type { get; set; }
        public string Tags { get; set; }
        public int? VariantGrams { get; set; }
        public int? VariantInventoryQty { get; set; }
        public int? VariantPrice { get; set; }
        public string ImageSrc { get; set; }
        public string ImageAltText { get; set; }

    }
}