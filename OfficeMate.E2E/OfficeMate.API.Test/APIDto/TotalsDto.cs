namespace OfficeMate.API.Test.APIDto
{
    public class TotalsDto
    {
        public Totals Totals { get; set; }
    }
    public class Totals
    {
        public decimal Grand_total { get; set; }
        public decimal Subtotal { get; set; }
        public int Items_qty { get; set; }
        public List<Items> Items { get; set; }

    }
    public class Items
    { 
        public string Name { get; set; }
        public int Qty { get; set; }
        public int Item_id { get; set; }
        public decimal Base_price { get; set; }
        public int Tax_percent { get; set; }
    }
}
