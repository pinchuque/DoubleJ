using System;


namespace DoubleJ.Oms.LabelManager.Models
{
    public class OrderEventArgs : EventArgs
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int LocationId { get; set; }
        public int Quantity { get; set; }
        public decimal Weight { get; set; }
        public int OrderDetailId { get; set; }
    }
}