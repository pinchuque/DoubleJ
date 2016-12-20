using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class ShopFloorViewModel
    {
        public ShopFloorViewModel()
        {
            Locations = new Dictionary<int, string>();
            Products = new Dictionary<int, string>();

            Bags = Enumerable.Empty<ShopFloorItem>();
            Boxes = Enumerable.Empty<ShopFloorItem>();

            Offals = Enumerable.Empty<ComboOffalItem>();
            Combos = Enumerable.Empty<ComboOffalItem>();
        }

        public IDictionary<int, string> Locations { get; set; }
        public IDictionary<int, string> Products { get; set; }

        public IEnumerable<ShopFloorItem> Bags { get; set; }
        public IEnumerable<ShopFloorItem> Boxes { get; set; }

        public IEnumerable<ComboOffalItem> Offals { get; set; }
        public IEnumerable<ComboOffalItem> Combos { get; set; }

        public string OrderId { get; set; }

        private ShopFloorItem.CompletionStatus GetItem(int productId, int locationId, IEnumerable<ShopFloorItem> source)
        {
            var item = source.FirstOrDefault(x => x.ProductId == productId);
            if (item == null)
            {
                return null;
            }

            return item.Items.FirstOrDefault(x => x.LocationId == locationId);
        }

        public string GetCompleted(int productId, int locationId, IEnumerable<ShopFloorItem> source)
        {
            var completionStatus = GetItem(productId, locationId, source);
            if (completionStatus == null)
            {
                return string.Empty;
            }

            return completionStatus.Completed.ToString(CultureInfo.InvariantCulture);
        }

        public string GetTotal(int productId, int locationId, IEnumerable<ShopFloorItem> source)
        {
            var completionStatus = GetItem(productId, locationId, source);
            if (completionStatus == null)
            {
                return string.Empty;
            }

            return completionStatus.Total.ToString(CultureInfo.InvariantCulture);
        }
    }

    public class ShopFloorItem
    {
        public ShopFloorItem()
        {
            Items = Enumerable.Empty<CompletionStatus>();
        }

        public int ProductId { get; set; }

        public IEnumerable<CompletionStatus> Items { get; set; }

        public class CompletionStatus
        {
            public int LocationId { get; set; }

            public int Completed { get; set; }
            public int Total { get; set; }
        }
    }

    public class ComboOffalItem
    {
        public string ProductName { get; set; }
        public string QtyWeight { get; set; }
        public string ShipTo { get; set; }
    }
}
