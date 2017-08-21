select 
s1.name
from 
students s1,friends f1,packages p1,packages p2
where s1.id=f1.id and s1.id=p1.id and
f1.friend_id=p2.id
and p1.salary<p2.salary
order by p2.salary