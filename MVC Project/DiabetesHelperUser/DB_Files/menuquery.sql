select * from CombDefinition where MealCombinationID =(select Id from MealCombination where NumOfMeals = 3) 




select m.[Name] as MealName ,c.FatPerCent, c.ProteinPerCent, c.CarbPerCent, c.TotalPer from CombDefinition as c 
join MealName as m  on c.MealNameID = m.Id
where MealCombinationID = (select Id from MealCombination where NumOfMeals = 2)



select * from Good 
join FoodType on Good.IDType = FoodType.Id
where IDType=1


select mn.[Name] as MealName, g.[Name], g.Energy_kcal,g.Energy_kJ, mu.[Name] as MeasuringUnit, t.[Type] as FoodType from Meal as m inner join MealName as mn on m.IDMealName = mn.Id inner join Good as g on m.IDGood = g.Id inner join MeasuringUnit as mu on g.IDMeasuringUnit = mu.Id inner join FoodType as t on g.IDType = t.Id where IDMenu = (select Id from Menu where NumberOfMeals = 3)




select mn.[Name] as MealName, g.[Name], g.Energy_kcal,g.Energy_kJ, mu.[Name] as MeasuringUnit, t.[Type] as FoodType
from Meal as m
inner join MealName as mn on m.IDMealName = mn.Id
inner join Good as g on m.IDGood = g.Id
inner join MeasuringUnit as mu on g.IDMeasuringUnit = mu.Id
inner join FoodType as t on g.IDType = t.Id
where IDMenu = (select Id from Menu where NumberOfMeals = 3)


select * from Menu
select * from Meal


select mn.[Name] as MealName, g.[Name], g.Energy_kcal,g.Energy_kJ, mu.[Name] as MeasuringUnit from Meal as m inner join MealName as mn on m.IDMealName = mn.Id inner join Good as g on m.IDGood = g.Id inner join MeasuringUnit as mu on g.IDMeasuringUnit = mu.Id where IDMenu = (select Id from Menu where NumberOfMeals = 3)


select m.Id as ID, m.[Name] as MealName, c.CarbPerCent as Carb, c.FatPerCent as Fat, 
c.ProteinPerCent as Protein,c.TotalPer 
from CombDefinition as c 
join MealName as m on c.MealNameID = m.Id 
where MealCombinationID = 1