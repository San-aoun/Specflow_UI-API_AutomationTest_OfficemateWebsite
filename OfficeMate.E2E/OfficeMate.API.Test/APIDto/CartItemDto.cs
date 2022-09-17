namespace OfficeMate.API.Test.APIDto
{
    public class CartItemDto
    {
        public CartItem CartItem { get; set; }

    }

    public class CartItem
    {
        public string Sku { get; set; }
        public int Qty { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Product_Type { get; set; }
    }
}
