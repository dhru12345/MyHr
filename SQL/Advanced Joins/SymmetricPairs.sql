select
f1.x,f1.y
from functions f1, functions f2
where f1.x=f2.y and f1.y=f2.x and f1.x<f1.y
union
select x,y from functions where x=y group by x,y having count(x)>1
order by x asc

