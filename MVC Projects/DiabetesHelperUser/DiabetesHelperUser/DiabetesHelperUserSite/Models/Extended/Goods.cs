using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.MetadataServices;
using System.Web;

namespace DiabetesHelperUser.Models
{
    [MetadataType(typeof(GoodsData))]
    public partial class Goods
    {

    }
    public class GoodsData
    {
        public string Name { get; set; }
        public Nullable<int> Energy_kcal { get; set; }
        public Nullable<int> Energy_kJ { get; set; }
        public Nullable<int> IDType { get; set; }
        public Nullable<int> IDMeasuringUnit { get; set; }

        public virtual FoodType FoodType { get; set; }
        public virtual MeasuringUnit MeasuringUnit { get; set; }
        public virtual ICollection<Meal> Meals { get; set; }
    }
}