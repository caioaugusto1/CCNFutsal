create database colacomnois_;

use colacomnois_;

create table CCN_Logins(
	Id int auto_increment NOT NULL primary key,
	Email varchar(30) NOT NULL,
	Nome varchar(30) NOT NULL,
	SobreNome varchar(30) NOT NULL,
	Senha varchar(50) NOT NULL,
	Data_Inclusao datetime NOT NULL
);

CREATE TABLE CCN_Jogadores(
	Id int Auto_Increment NOT NULL primary key,
	Nome varchar(100) NOT NULL,
	RG varchar(12) NOT NULL,
	Data_Nascimento datetime NOT NULL,
	Data_Admissao datetime NOT NULL,
	Data_Demissao datetime NULL,
	Comissao bit NOT NULL
    );
    
    
    CREATE TABLE CCN_Despesas(
	Id int Auto_Increment NOT NULL primary key,
	Nome varchar(100) NOT NULL,
	Valor decimal(18, 0) NOT NULL,
	Data_Vencimento datetime NOT NULL,
	Data_Pagamento datetime NULL,
	Status char(1) NOT NULL,
	Observacao varchar(200) NULL
    );
    

CREATE TABLE CCN_Rateios(
	Id int AUTO_INCREMENT NOT NULL primary key,
	IdJogador int NOT NULL,
    IdRecebedor int NOT NULL,
	IdDespesa int NOT NULL,
	Valor decimal(18, 0) NOT NULL,
	Data_Pagamento datetime(3) NOT NULL,
    
    index CCN_Jogadores(IdJogador), foreign key (IdJogador) References CCN_Jogadores(Id),
	index CCN_Jogadores(IdRecebedor), foreign key (IdRecebedor) References CCN_Jogadores(Id),
    index CCN_Despesas(IdDespesa), foreign key (IdDespesa) References CCN_Despesas(Id)
   
);


CREATE TABLE CCN_Adversarios(
	Id int AUTO_INCREMENT NOT NULL primary key,
	Nome varchar(50) NOT NULL,
	Responsavel varchar(30) NOT NULL,
	Telefone varchar(15) NOT NULL,
	Nota char(1) NOT NULL,
	Observacao varchar(250) NOT NULL
);


CREATE TABLE CCN_Jogos(
	Id int AUTO_INCREMENT NOT NULL primary key,
	Quadro char(1) NOT NULL,
	Data date NOT NULL,
	ResultadoColaComNois int NOT NULL,
	ResultadoAdversario int NOT NULL,
	Mandante Tinyint NOT NULL,
	Referente char(1) NOT NULL,
	Observacao varchar(250) NOT NULL,
	IdAdversario int NOT NULL,
    
    foreign key (IdAdversario) references CCN_Adversarios(Id)
);

Alter table CCN_Rateios add constraint foreign key (IdRecebedor) REFERENCES CCN_Jogadores(Id)