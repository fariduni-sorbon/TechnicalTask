Use AcademySummer;

create Table Clients
(
	Id int identity primary key,
	Balls int not null,
	TelephoneNumber int not null,
	ClientType nvarchar(100) not null,
	Gender nvarchar(100) not null,
	MaritalStatus nvarchar(100) not null,
	Age int not null,
	Nationality nvarchar(100) not null
)


Create Table ApplicationForm
(
	Id int identity primary key,
	Balls int null,
	ClientsId int references Clients(Id),
	CreatedAt  datetime not null,
	CreditAmount int not null,
	LoanAmount int not null,
	CreditStory  int not null,
	CreditDelay int not null,
	CreditTarget nvarchar(100) not null,
	CreditTerm int not null
)

Create Table Credits
(
	Id int identity primary key,
	ClientsId int references Clients(Id),
	CreatedAt datetime  null,
	MonthlyPayment float not null,
	Term int not null
)
