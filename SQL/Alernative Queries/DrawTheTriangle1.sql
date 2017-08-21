declare @icount   int;
select @icount=20;
while(@icount>0)
begin
 
  select replicate('* ',@icount);
  select @icount=@icount-1;
end;