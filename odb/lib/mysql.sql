use eshopinnodb;

select count(customer_id) from customers where customer_id = 1984;
select count(*) from customers where customer_id = 1984;
select email from customers where customer_id = 1984;


create user if not exists ''@'localhost' IDENTIFIED BY 'password';
select * from mysql.user;
drop user if exists 'user1'@'localhost';
show grants for 'janek'@'localhost';
GRANT SELECT, INSERT, DELETE ON eshopinnodb.tb_Users TO 'jeffrey'@'localhost';
grant select, insert on eshopinnodb.orders to 'jeffrey'@'localhost';
grant select, insert, delete on eshopinnodb.customers to 'jeffrey'@'localhost';

select table_name, TABLE_TYPE, engine
from information_schema.TABLES 
where TABLE_SCHEMA = 'eshop'
order by TABLE_NAME;

select count(*) Noofcolumns from SYSCOLUMNS where id=(select id from SYSOBJECTS where name='customers');

SELECT COUNT(*)
  FROM INFORMATION_SCHEMA.COLUMNS
 WHERE table_catalog = 'eshopinnodb' -- the database
   AND table_name = 'customers'
   ;
-- SELECT (data_length+index_length)/power(1024,3) tablesize
SELECT (data_length+index_length)/power(1024,3) tablesize
FROM information_schema.tables
WHERE table_schema='eshopinnodb' and table_name='order_status';



-- SELECT (data_length+index_length)/power(1024,3) tablesize
SELECT (data_length+index_length)/power(1024,3) tablesize
FROM information_schema.tables
WHERE table_schema='eshopinnodb' and table_name='customers';

select max(customer_id) from customers;

DROP database eshopinnodb;
Create database eshopInnoDB;
use eshopInnoDB;

-- a;
CREATE TABLE `shops` (
  `city` char(20) UNIQUE,
  `shop_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `orders` (
  `order_id` int(10) unsigned  AUTO_INCREMENT,
  `customer_id` int(10) unsigned ,
  `item_id` int(10) unsigned ,
  PRIMARY KEY (`order_id`)
  ) ENGINE=InnoDB AUTO_INCREMENT=10001 DEFAULT CHARSET=utf8;


	
CREATE TABLE `stock` (
  `item_name` varchar(15) ,
  `category` varchar(15) ,
  `quantity` int(10) unsigned ,
  `price` decimal(6,2) ,
  `shop_id` int(10) unsigned ,
  `item_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`item_id`),
  KEY `shop_id` (`shop_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `order_status` (
  `status` varchar(255) ,
  `status_changed` datetime ,
  `order_id` int(10) unsigned ,
  `status_id` int(10) unsigned AUTO_INCREMENT unique
  -- UNIQUE KEY `status_id` (`status_id`),
  -- KEY `order_id` (`order_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `customers` (
  `first_name` char(20) ,
  `last_name` char(30) ,
  `city` char(50) ,
  `email` varchar(255) unique,
  `phone` varchar(20) ,
  `customer_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



alter table `order_status` 
add CONSTRAINT `order_status_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`);

alter table `stock`
	add CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`shop_id`) REFERENCES `shops` (`shop_id`);

ALTER TABLE `orders` 
	add CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`customer_id`),
	add CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `stock` (`item_id`);







SELECT FILE_NAME, BYTES FROM DBA_DATA_FILES WHERE TABLESPACE_NAME = 'LEGAL_DATA';