
select m.[Name] as MealName ,c.FatPerCent, c.ProteinPerCent, c.CarbPerCent, c.TotalPer from CombDefinition as c 
join MealName as m  on c.MealNameID = m.Id
where MealCombinationID = (select Id from MealCombination where NumOfMeals = 3)



select mn.[Name] as MealName from Meal as m  inner join MealName as mn on m.IDMealName = mn.Id where IDMenu = (select Id from Menu where NumberOfMeals = 3)



select g.*, m.[Name] as MeasuringUnit, t.[Type] as FoodType from Good as g inner join MeasuringUnit as m on g.IDMeasuringUnit = m.Id inner join FoodType as t on g.IDType = t.Id




select * from [User]

select u.Id, u.[Weight] as [Weight], u.Height as Height, u.DiaType as DiabetesType, u.Activity as Activity, u.Age as Age from [User] as u where Id = 2



