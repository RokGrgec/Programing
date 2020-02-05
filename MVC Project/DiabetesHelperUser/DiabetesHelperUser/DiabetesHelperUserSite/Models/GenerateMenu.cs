using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiabetesHelperUser.Models
{
    public class GenerateMenu
    {
        public GenerateMenu()
        {

        }
        public Good Good { get; set; }
        public FoodType FoodType { get; set; }
        public MeasuringUnit MeasuringUnit { get; set; }
        public CombDefinition CombDefinition { get; set; }
        public List<CombDefinition> CombDefinitions { get; set; }
        public MealCombination MealCombination { get; set; }
        public Meal Meal { get; set; }
        public Menu Menu { get; set; }
        public MealName MealName { get; set; }
        public ViewModels ViewModels { get; set; }
    }

    public class ViewModels
    {
        public string ErrorMessage { get; set; }
        public int NumberOfMealsInTale;
        public List<Good> Carbs { get; set; }
        public List<Good> Fats { get; set; }
        public List<Good> Proteins { get; set; }
        public List<MealName> MealNames { get; set; }
        public List<MeasuringUnit> MeasuringUnitCarb { get; set; }
        public List<MeasuringUnit> MeasuringUnitFat { get; set; }
        public List<MeasuringUnit> MeasuringUnitProtein { get; set; }
        public List<FoodType> FoodTypes { get; set; }
        public int NumberOfMeals;
    }
}