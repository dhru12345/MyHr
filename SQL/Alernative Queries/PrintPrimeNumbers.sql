-- Oracle
SELECT LISTAGG(prime_number,'&') WITHIN GROUP (ORDER BY prime_number) AS NUMBERS
FROM(    
    select l prime_number
from (select level l from dual connect by level <= 1000)
, (select level m from dual connect by level <= 1000)
where m<=l
group by l
having count(case l/m when trunc(l/m) then 'Y' end) = 2);