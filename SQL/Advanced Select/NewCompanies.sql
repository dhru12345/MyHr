select
   c.company_code,c.founder,
   (select count(distinct lead_manager_code) from Lead_Manager  lm where c.company_code=lm.company_code),
   (select count(distinct senior_manager_code) from Senior_Manager  sm where c.company_code=sm.company_code),
   (select count(distinct manager_code) from Manager  m where c.company_code=m.company_code),
   (select count(distinct employee_code) from Employee  e where c.company_code=e.company_code)
from Company c
order by c.company_code asc;
