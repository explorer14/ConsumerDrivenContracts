namespace Provider
{
    public class Proposal
    {
        public int Quantity { get; set; }

        public string Reference { get; set; }

        public decimal Proportion { get; set; }

        public bool IsActive { get; set; }

        public string TotalExpectedCentralStock { get; set; }

        public decimal Discount { get; set; }
    }
}