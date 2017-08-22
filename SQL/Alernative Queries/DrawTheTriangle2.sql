declare @icount   int;
select @icount=1;
while(@icount<=20)
begin
 
  select replicate('* ',@icount);
  select @icount=@icount+1;
end;