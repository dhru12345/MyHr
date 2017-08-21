/*
Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/
select 
  ct.contest_id, ct.hacker_id, ct.name,
  sum(total_submissions), sum(total_accepted_submissions), sum(total_views), sum(total_unique_views)
from Contests ct 
    LEFT JOIN Colleges  clg 
        on ct.contest_id=clg.contest_id
    LEFT JOIN Challenges  cl
        on clg.college_id=cl.college_id 
    LEFT JOIN
        (SELECT challenge_id,
                         Sum(total_views)        AS total_views,
                         Sum(total_unique_views) AS total_unique_views
                  FROM   view_stats
                  GROUP  BY challenge_id)  vs
         on cl.challenge_id=vs.challenge_id
    LEFT JOIN  (SELECT challenge_id,
                   Sum(total_submissions)          AS total_submissions,
                   Sum(total_accepted_submissions) AS
                   total_accepted_submissions
                   FROM   submission_stats
                   GROUP  BY challenge_id)  ss
     on cl.challenge_id=ss.challenge_id
group by
    ct.contest_id, ct.hacker_id, ct.name
having (sum(total_submissions)+sum(total_accepted_submissions)+ sum(total_views)+ sum(total_unique_views))!=0
order by ct.contest_id