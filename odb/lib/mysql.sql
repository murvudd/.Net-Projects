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

DROP database eshop;
Create database eshop;
use eshop;

CREATE TABLE `shops` (
  `city` char(20) NOT NULL UNIQUE,
  `shop_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`shop_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `orders` (
  `order_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `custm_id` int(10) unsigned NOT NULL,
  `item_id` int(10) unsigned NOT NULL,
  PRIMARY KEY (`order_id`) -- ,
   -- KEY `custm_id` (`custm_id`),
   -- KEY `item_id` (`item_id`),
  
) ENGINE=InnoDB AUTO_INCREMENT=10001 DEFAULT CHARSET=utf8;

	
CREATE TABLE `stock` (
  `item_name` varchar(15) NOT NULL,
  `category` varchar(15) NOT NULL,
  `quantity` int(10) unsigned NOT NULL,
  `price` decimal(6,2) NOT NULL,
  `shop_id` int(10) unsigned NOT NULL,
  `item_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`item_id`),
  KEY `shop_id` (`shop_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `order_status` (
  `status` varchar(20) NOT NULL,
  `order_date` datetime NOT NULL,
  `order_id` int(10) unsigned NOT NULL,
  `status_id` int(10) unsigned NOT NULL AUTO_INCREMENT unique
  -- UNIQUE KEY `status_id` (`status_id`),
  -- KEY `order_id` (`order_id`)
  
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

CREATE TABLE `customers` (
  `first_name` char(20) DEFAULT NULL,
  `last_name` char(30) DEFAULT NULL,
  `city` char(20) DEFAULT NULL,
  `email` varchar(60) DEFAULT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `customer_id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`customer_id`)
) ENGINE=InnoDB AUTO_INCREMENT=1111121 DEFAULT CHARSET=utf8;



alter table `order_status` add
	CONSTRAINT `order_status_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`);

alter table `stock`
	add CONSTRAINT `stock_ibfk_1` FOREIGN KEY (`shop_id`) REFERENCES `shops` (`shop_id`);

ALTER TABLE `orders` 
	add CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`custm_id`) REFERENCES `customers` (`customer_id`),
	add CONSTRAINT `orders_ibfk_2` FOREIGN KEY (`item_id`) REFERENCES `stock` (`item_id`);
