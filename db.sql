use Scales;

create table [Users] 
(
	id int Identity(1,1) primary key,
	[login] varchar(15),
	[password] varchar(20)
)

create table Categories
(
	id int Identity(1,1) primary key,
	[name] varchar(40) unique
)

create table Products
(
	id int Identity(1,1) primary key,
	category_id int,
	[name] varchar(70),
	[description] varchar(300),
	foreign key (category_id) references Categories(id)
)

create table Prices
(
	id int Identity(1,1) primary key,
	product_id int,
	datein date,
	dateout date,
	[value] decimal(5,2),
	foreign key (product_id) references Products(id)
)

create table Cart 
(
	id int,
	product_id int,
	foreign key (id) references [Users](id),
	foreign key (product_id) references Products(id) 
)