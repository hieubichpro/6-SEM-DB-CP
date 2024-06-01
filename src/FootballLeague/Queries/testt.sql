insert into users values(15, 'admin', '1', 'Admin', 'hieu', 'pro', 40, -1)
-- select * from users
update users set id_club = -1 where id = 1
-- select * from users

create table classes
(
	id serial not null primary key,
	name varchar(30)
)

create table students
(
	id serial not null primary key,
	name varchar(30),
	id_class int,
	
	foreign key (id_class) references classes(id)
)

insert into classes(name) values('iu762b')
insert into students(name, id_class) values('hieu', 1);
insert into students(name, id_class) values('dang', 1);
insert into students(name, id_class) values('andrey', 1);

select * from classes
insert into classes(name) values ('iu762b')
delete from classes where id = 1
update classes set id = 1 where id = 2
select * from students s join classes c on s.id_class = c.id

alter table users drop constraint fk_users_clubs

select * from stadiums
select * from countries

select * from users

select * from clubs

update users set id_club = -1 where login = 'hieu'

select * from users where login = 'bich1'

select * from requests
delete from requests where id_user = 14
select * from users where login = 'coach99'

select * from clubs
select * from users

select * from leagues
