select Id,CONVERT(varchar, JourneyStart,103),CONVERT(varchar, JourneyEnd,103) from Journeys
where Purpose = 'Military' 
order by JourneyStart  asc

