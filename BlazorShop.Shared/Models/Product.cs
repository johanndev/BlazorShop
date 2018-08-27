namespace BlazorShop.Shared.Models
{
    public class Product
    {
        public int Id { get; set; }
        public Category Category { get; set; }
        public string Handle { get; set; }
        public string Title { get; set; }
        public string HtmlDescription { get; set; }
        public string Vendor { get; set; }
        public string Type { get; set; }
        public string Tags { get; set; }
        public bool Published { get; set; }
        public string Option1Name { get; set; }
        public string Option1Value { get; set; }
        public string Option2Name { get; set; }
        public string Option2Value { get; set; }
        public string Option3Name { get; set; }
        public string Option3Value { get; set; }
        public string VariantSku { get; set; }
        public int? VariantGrams { get; set; }
        public int? VariantInventoryQty { get; set; }
        public VariantInventoryPolicy VariantInventoryPolicy { get; set; }
        public int? VariantPrice { get; set; }
        public int? VariantCompareAtPrice { get; set; }
        public bool VariantRequiresShipping { get; set; }
        public string VariantBarcode { get; set; }
        public string ImageSrc { get; set; }
        public string ImageAltText { get; set; }
        public bool GiftCard { get; set; }
        public string VariantImageSrc { get; set; }
        public WeightUnit VariantWeightUnit { get; set; }
    }
}
