--SELECT R.Name, RT.Name as RewardTypeName FROM [dbo].[Rewards] R
--LEFT OUTER JOIN [dbo].[RewardTypes] RT ON RT.Id = R.RewardTypeId
--ORDER BY RT.Name, R.Name;

SELECT P.Name, DS.Name, MT.Name FROM [dbo].[DropSources] DS
LEFT OUTER JOIN [dbo].[DropSourceTypes] DST ON DST.Id = DS.DropSourceTypeId
LEFT OUTER JOIN [dbo].[MissionTypes] MT ON MT.Id = DS.MissionTypeId
LEFT OUTER JOIN [dbo].[Planets] P ON P.Id = DS.PlanetId
ORDER BY P.Name, DS.Name;