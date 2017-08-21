SELECT 
	proj_start_date, proj_end_date 
FROM 
(SELECT start_date AS proj_start_date, 
	(SELECT MIN(end_date) AS proj_end_date FROM PROJECTS pr2 WHERE end_date > pr1.start_date AND 
	 NOT EXISTS (SELECT * FROM PROJECTS WHERE DATEDIFF(DAY, pr2.end_date, end_date) = 1)) 
	 AS proj_end_date FROM PROJECTS pr1 
 WHERE NOT EXISTS 
	(SELECT * FROM PROJECTS WHERE DATEDIFF(DAY, start_date, pr1.start_date) = 1)
 ) AS 
 sorted_data ORDER BY DATEDIFF(DAY, proj_start_date, proj_end_date), proj_start_date;