select table_name, TABLE_TYPE, engine
from information_schema.TABLES 
where TABLE_SCHEMA = 'eshop'
order by TABLE_NAME;

insert into shops (city) values ('Warszawa');
select * from shops;
truncate table shops;

SELECT (data_length+index_length)/power(1024,3) tablesize
FROM information_schema.tables
WHERE table_schema='eshop' and table_name='customers';