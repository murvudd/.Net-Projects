select table_name, TABLE_TYPE, engine
from information_schema.TABLES 
where TABLE_SCHEMA = 'eshop'
order by TABLE_NAME;

insert into shops (city) values ('Warszawa');
select * from shops order by shop_id;
select * from stock;
select * from customers order by customer_id;
select count(*) from customers;
truncate table shops;

-- SELECT (data_length+index_length)/power(1024,3) tablesize
SELECT (data_length+index_length)/power(1024,3) tablesize
FROM information_schema.tables
WHERE table_schema='eshopinnodb' and table_name='customers';

DROP database eshop;
Create database eshopInnoDB;
use eshopInnoDB;

CREATE TABLE `shops` (
  `city` char(20) UNIQUE,
  `shop_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `orders` (
  `order_id` int(10) unsigned  AUTO_INCREMENT,
  `custm_id` int(10) unsigned ,
  `item_id` int(10) unsigned ,
  PRIMARY KEY (`order_id`)
  ) ENGINE=InnoDB AUTO_INCREMENT=10001 DEFAULT CHARSET=utf8;
ALTER TABLE `orders` 
	add CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`custm_id`) REFERENCES `customers` (`customer_id`),
	add CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `stock` (`item_id`);

	
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
  `status` varchar(20) ,
  `order_date` datetime ,
  `order_id` int(10) unsigned ,
  `status_id` int(10) unsigned AUTO_INCREMENT unique
  -- UNIQUE KEY `status_id` (`status_id`),
  -- KEY `order_id` (`order_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

drop table `customers`;
CREATE TABLE `customers` (
  `first_name` char(20) ,
  `last_name` char(30) ,
  `city` char(20) ,
  `email` varchar(60) ,
  `phone` varchar(20) ,
  `customer_id` int(10) unsigned AUTO_INCREMENT,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;



alter table `order_status` 
add CONSTRAINT `order_status_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`);

alter table `stock`
	add CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`shop_id`) REFERENCES `shops` (`shop_id`);

ALTER TABLE `orders` 
	add CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`custm_id`) REFERENCES `customers` (`customer_id`),
	add CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `stock` (`item_id`);
