using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;


namespace DoubleJ.Oms.Model.ViewModels.Internal
{
    public class NutritionInfoViewModel
    {
        public int ProductId { get; set; }

        [DisplayName("Description")]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(22)]
        [DisplayName("Serving Size")]
        public string ServingSize { get; set; }

        [Required]
        [StringLength(12)]
        [DisplayName("Serving per Container")]
        public string ServingPerContainer { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Calories")]
        public int Calories { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Calories from Fat")]
        public int CaloriesFat { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Total Fat")]
        public int TotalFat { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "99999999999999")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        [DisplayName("Saturated Fat")]
        public decimal SatFat { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "99999999999999")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        [DisplayName("Trans Fat")]
        public decimal TransFat { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "99999999999999")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        [DisplayName("Polyunsaturated Fat")]
        public decimal PolyFat { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "99999999999999")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0}")]
        [DisplayName("Monounsaturated Fat")]
        public decimal MonoFat { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Cholesterol")]
        public int Cholesterol { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Sodium")]
        public int Sodium { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Total Carbohydrates")]
        public int Carbs { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Protein")]
        public int Protein { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Vitamin A")]
        public int VitA { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Vitamin C")]
        public int VitC { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Calcium")]
        public int Calcium { get; set; }

        [Required]
        [Range(typeof(int), "0", "100000")]
        [DisplayName("Iron")]
        public int Iron { get; set; }
    }
}