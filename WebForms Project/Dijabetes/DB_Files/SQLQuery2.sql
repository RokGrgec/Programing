select m.[Name] as MealName, c.CarbPerCent as Carb, c.FatPerCent as Fat, c.ProteinPerCent as Protein, c.TotalPer from CombDefinition as c
join MealName as m on c.ID = m.Id
where MealCombinationID = 1
