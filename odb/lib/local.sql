DROP TABLE CUSTOMERS;

create table customers(
  first_name char(20) DEFAULT NULL,
  last_name char(30) DEFAULT NULL,
  city char(50) DEFAULT NULL,
  email VARCHAR2(255) DEFAULT NULL,
  phone varchar2(20) default null,
  customer_id NUMBER(20, 0) NOT NULL primary key,

  Constraint unique_email Unique (email)

);

CREATE TABLE shops (
  city char(20) unique,
  shop_id NUMBER(10, 0) NOT NULL primary key
);
INSERT ALL
  INTO shops VALUES ('Bydgoszcz',8)
  INTO shops VALUES ('Gdañsk',6)
  INTO shops VALUES ('Katowice',10)
  INTO shops VALUES ('Kraków',2)
  INTO shops VALUES ('Lublin',9)
  INTO shops VALUES ('Poznañ',5)
  INTO shops VALUES ('Szczecin',7)
  INTO shops VALUES ('Warszawa',1)
  INTO shops VALUES ('Wroc³aw',4)
  INTO shops VALUES ('£ódŸ',3)
select 1 from dual;

Drop Table order_status;
DROP TABLE orders;
DROP TABLE Stock;
CREATE TABLE stock (
  item_name VARCHAR2(15) DEFAULT NULL,
  category VARCHAR2(15) DEFAULT NULL,
  quantity NUMBER(10, 0)  DEFAULT NULL,
  price DECIMAL(24) DEFAULT NULL,
  shop_id NUMBER(10, 0)  DEFAULT NULL,
  item_id NUMBER(10, 0)  NOT NULL primary key,
  -- PRIMARY KEY ("item_id"),
  -- KEY "shop_id" ("shop_id"),
  CONSTRAINT stock_ibfk_1 FOREIGN KEY (shop_id) REFERENCES shops (shop_id)
  );
CREATE TABLE ORDERS (
  order_id NUMBER(10, 0)  NOT NULL primary key,
  customer_id NUMBER(10, 0)  DEFAULT NULL,
  item_id NUMBER(10, 0)  DEFAULT NULL,
 -- PRIMARY KEY (order_id),
 -- KEY "orders_ibfk_1" ("customer_id"),
 -- KEY "orders_ibfk_2" ("item_id"),
  CONSTRAINT orders_ibfk_1 FOREIGN KEY (customer_id) REFERENCES customers (customer_id),
  CONSTRAINT orders_ibfk_2 FOREIGN KEY (item_id) REFERENCES stock (item_id)
); 
CREATE TABLE order_status
( 
status varchar2(20 char) not null,

order_date date not null,

order_id NUMBER(10) not null
    CONSTRAINT uint_order_id check (order_id > 0),

status_id NUMBER(10) not null,
    CONSTRAINT uint_status_id check (status_id > 0),    
    CONSTRAINT fk_order_status FOREIGN KEY (order_id) REFERENCES orders(order_id)
);
INSERT INTO order_status VALUES ('Order Created','2016-12-08 00:00:00',2443,1);
INSERT INTO order_status VALUES ('Order Created','2016-12-08',2443,1);
select * from order_status;
delete from order_status where status_id = 1;




select count(*) from customers;
select count(*) from shops;
select count(*) from stock;
select count(*) from orders;
select count(*) from order_status;