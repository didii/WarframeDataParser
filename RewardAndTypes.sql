SELECT R.Name, RT.Name as RewardTypeName FROM [dbo].[Rewards] R
LEFT OUTER JOIN [dbo].[RewardTypes] RT ON RT.Id = R.RewardTypeId
ORDER BY RT.Name, R.Name;