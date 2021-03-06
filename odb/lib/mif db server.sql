drop table customers;
drop table order_status;
drop table orders;
drop table shops;
drop table stock;

drop sequence stock_id;
drop sequence customer_id;
drop sequence shop_id;



create table shops(

	city varchar2(20 char) not null unique,
	shop_id NUMBER primary key
);

CREATE TABLE stock(
	item_name VARCHAR2(20 char),
	category VARCHAR2(15 char) not null,
    
    
	quantity    NUMBER not null
    CONSTRAINT check_qty CHECK (quantity > 0),
      
	price decimal(6,2) 
    CONSTRAINT nn_price NOT NULL 
    CONSTRAINT check_price CHECK (price > 0),

	shop_id NUMBER not null,
    -- CONSTRAINT fk_stock FOREIGN KEY (shops) references shops(shop_id),

	item_id NUMBER primary key

    -- GENERATED ALWAYS as IDENTITY(START with 1 INCREMENT by 1),
    -- CONSTRAINT pk_stock PRIMARY KEY (item_id)
);

CREATE TABLE order_status
( 
    status varchar2(20 char) not null,

	order_date date not null,

	order_id NUMBER(10) not null
		CONSTRAINT uint_order_id check (order_id > 0),

	status_id NUMBER(10) not null,
		CONSTRAINT uint_status_id check (status_id > 0)
    
    /*CONSTRAINT fk_order_status
        FOREIGN KEY (order_id)
        REFERENCES orders(order_id) */
);

create table orders(
	order_id number(10) primary key,
	custm_id number(10),
	item_id number(10)
);

create table customers(
	first_name char(20 char),
	last_name char(30 char),
	city char(50),
	email varchar2(255) Unique,
	phone varchar2(20 char),
	customer_id number(10) primary key 
);


CREATE SEQUENCE stock_id
  START WITH 1
  INCREMENT BY 1
  CACHE 100;

CREATE SEQUENCE customer_id
  START WITH 1
  INCREMENT BY 1
  CACHE 100;

  CREATE SEQUENCE shop_id
  START WITH 1
  INCREMENT BY 1
  CACHE 100;
  
  23819
  
  ORA-00001
  
insert into customers(first_name, last_name, city, email, phone, customer_id)
values ('dupa', 'dupaduap', 'dupowo', 'dupa.dupadupa@dupa.com', 00, customer_id.nextval);
select count(*) from customers;

SELECT FILE_NAME, BYTES FROM DBA_DATA_FILES WHERE TABLESPACE_NAME = 'LEGAL_DATA';

