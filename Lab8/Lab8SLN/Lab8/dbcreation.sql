drop database if exists lab8;
create database lab8;
use lab8;

drop table if exists earthquake;
create table earthquake(
ID int primary key auto_increment,
Rok int,
Miejsce varchar(255),
Kraj varchar(255),
Siła decimal(3,1)
)engine = myisam;
use lab8;
SELECT * FROM earthquake;
insert into earthquake (Rok, Miejsce, Kraj, Siła) values('13','P','POL','9.0');
update earthquake set Siła = '155' where id = 1;