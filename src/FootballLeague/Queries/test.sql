insert into users values
(1, 'hieu', '1', 'footballer');

insert into users values
(2, 'bich', '2', 'coach')

select * from users

insert into users(login, password, role, firstname, lastname, age) values
('hien', '3', 'footballer', '', '', 25);

select * from users where login = 'hieu'

select * from leagues

select * from countries

insert into countries(name, continent) values
('Spain', 'Europe'),
('England', 'Europe'),
('Vietnam', 'Asia'),
('USA', 'America');
insert into countries(name, continent) values
('Russia', 'Europe');
select * from countries

select * from leagues

select * from clubs

select * from users

select cl.id, cl.name, u.firstname, u.lastname, c.name from clubs cl join users u on cl.id_user = u.id
			join countries c on cl.id_country = c.id;
			
alter table leagues drop column id_country
select * from leagues

select * from clubs
alter table clubs drop column id_user

select * from clubs

select * from users
select * from clubs

select * from userclub

insert into userclub(id_user, id_club)
values
(2, 1),
(3, 2),
(2, 3),
(1, 4),
(1, 5)

select c.id, c.name as Name_Club, u.firstname || ' ' || u.lastname as Creator, ct.name
from clubs c join userclub uc on c.id = uc.id_club
join users u on uc.id_user = u.id
join countries ct on c.id_country = ct.id;

select * from clubs;

select id from clubs where name = 'HCMCity'

select * from userclub

select * from users

delete from clubs where name = 'bk'

select distinct u.firstname || ' ' || u.lastname as fullname, c.name
from users u join userclub uc on u.id = uc.id_user
join clubs c on uc.id_club = c.id
where role = 'Footballer';


select * from users

select * from countries

insert into countries(name, continent) values
('Spain', 'Europe'),
('England', 'Europe'),
('Vietnam', 'Asia'),
('USA', 'America');

delete from clubs where id = 2

select * from clubs
select * from users
select c.id, c.name as Name_Club, u.firstname || ' ' || u.lastname as Creator, ct.name
                          from clubs c
                          join users u on u.id_club = c.id
                          join countries ct on c.id_country = ct.id;
						  
update users set id_club = 3 where id = 5

select u.firstname || ' ' || u.lastname as Fullname_Footballer, u.age, c.name as Name_Club
from users u join clubs c
on u.id_club = c.id
where role = 'Footballer'

select * from countries

select * from stadiums

insert into stadiums(name, capacity, id_country) values
('Old Transford', 70000, 2),
('Camp Nou', 75000, 1);

select s.id, s.name, s.capacity, c.name as country
from stadiums s join countries c on s.id_country = c.id

select * from countries

select * from requests