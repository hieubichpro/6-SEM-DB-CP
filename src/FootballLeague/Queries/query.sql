drop table if exists Users;
drop table if exists Matchs;
drop table if exists Clubs;
drop table if exists Stadiums;
drop table if exists Country;
drop table if exists Applications;
drop table if exists Leagues;
drop table if exists Feedback;
drop table if exists LeagueClub;

create table if not exists Users
(
	id serial not null primary key,
	login varchar(30) not null,
	password varchar(30) not null,
	role varchar(20) not null,
	firstname varchar(30) default 'hieu',
	lastname varchar(30) default 'bich',
	age int default 25
);

create table if not exists Countries
(
	id serial not null primary key,
	name varchar(40) not null,
	continent varchar(40) not null
);

create table if not exists Clubs
(
	id serial not null primary key,
	name varchar(50) not null,
	id_user int not null,
	id_country int not null,
	
	foreign key (id_user) references Users(id),
	foreign key (id_country) references Countries(id)
);

create table if not exists Stadiums
(
	id serial not null primary key,
	name varchar(30) not null,
	capacity int not null,
	id_country int not null,
	
	foreign key (id_country) references Countries(id)
);

create table if not exists Leagues
(
	id serial not null primary key,
	name varchar(30) not null,
	rating float,
	id_user int,
	id_country int,
	
	foreign key (id_user) references Users(id),
	foreign key (id_country) references Countries(id)
);

create table if not exists Matches
(
	id serial not null primary key,
	goal_home_club int not null,
	goal_guess_club int not null,
	id_league int not null,
	id_stadium int not null,
	id_home_club int not null,
	id_guess_club int not null,
	
	foreign key (id_league) references Leagues(id),
	foreign key (id_stadium) references Stadiums(id),
	foreign key (id_home_club) references Clubs(id),
	foreign key (id_guess_club) references Clubs(id)
);

create table if not exists Applications
(
	id serial not null primary key,
	created_time timestamp default now(),
	id_league int not null,
	id_club int not null,
	id_user int not null,
	
	foreign key (id_league) references Leagues(id),
	foreign key (id_club) references Clubs(id),
	foreign key (id_user) references Users(id)
);

create table if not exists Feedbacks
(
	id serial not null primary key,
	comment varchar(200),
	grade int not null,
	id_user int not null,
	id_league int not null,
	
	foreign key (id_user) references Users(id),
	foreign key (id_league) references Leagues(id)
);

create table if not exists LeagueClub
(
	id serial not null primary key,
	id_league int not null,
	id_club int not null,
	
	foreign key (id_league) references Leagues(id),
	foreign key (id_club) references Clubs(id)
);