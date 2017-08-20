create table ccn_logins(
	Id int auto_increment NOT NULL primary key,
	Email varchar(30) NOT NULL,
	Nome varchar(30) NOT NULL,
	SobreNome varchar(30) NOT NULL,
	Senha varchar(50) NOT NULL,
	Data_Inclusao datetime NOT NULL
);

CREATE TABLE ccn_jogadores(
	Id int Auto_Increment NOT NULL primary key,
	Nome varchar(100) NOT NULL,
	RG varchar(12) NOT NULL,
	Data_Nascimento datetime NOT NULL,
	Data_Admissao datetime NOT NULL,
	Data_Demissao datetime NULL,
	Comissao bit NOT NULL
    );
    
    
    CREATE TABLE ccn_despesas(
	Id int Auto_Increment NOT NULL primary key,
	Nome varchar(100) NOT NULL,
	Valor decimal(18, 0) NOT NULL,
	Data_Vencimento datetime NOT NULL,
	Data_Pagamento datetime NULL,
	Status char(1) NOT NULL,
	Observacao varchar(200) NULL
    );
    

CREATE TABLE ccn_rateios(
	Id int AUTO_INCREMENT NOT NULL primary key,
	IdJogador int NOT NULL,
    IdRecebedor int NOT NULL,
	IdDespesa int NOT NULL,
	Valor decimal(18, 0) NOT NULL,
	Data_Pagamento datetime(3) NOT NULL,
    
    index ccn_jogadores(IdJogador), foreign key (IdJogador) References ccn_jogadores(Id),
    index ccn_despesas(IdDespesa), foreign key (IdDespesa) References ccn_despesas(Id)
   
);


CREATE TABLE ccn_adversarios(
	Id int AUTO_INCREMENT NOT NULL primary key,
	Nome varchar(50) NOT NULL,
	Responsavel varchar(30) NOT NULL,
	Telefone varchar(15) NOT NULL,
	Nota char(1) NOT NULL,
	Observacao varchar(250) NOT NULL
);


CREATE TABLE ccn_jogos(
	Id int AUTO_INCREMENT NOT NULL primary key,
	Quadro char(1) NOT NULL,
	Data date NOT NULL,
	ResultadoColaComNois int NOT NULL,
	ResultadoAdversario int NOT NULL,
	Mandante Tinyint NOT NULL,
	Referente char(1) NOT NULL,
	Observacao varchar(250) NOT NULL,
	IdAdversario int NOT NULL,
    
    foreign key (IdAdversario) references ccn_adversarios(Id)
);

Alter table ccn_rateios add constraint foreign key (IdRecebedor) REFERENCES ccn_jogadores(Id)