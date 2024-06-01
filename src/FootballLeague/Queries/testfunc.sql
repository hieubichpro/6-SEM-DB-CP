drop table if exists matchtest;
create table if not exists matchtest
(
	id serial not null primary key,
	id_home int,
	id_guest int,
	goal_home int,
	goal_guest int
);

drop table if exists clubtest;
create table if not exists clubtest
(
	id serial not null primary key,
	name varchar(32)
);

insert into clubtest(name) values ('Chelsea'), ('MU'), ('MC'), ('Arsenal'), ('Brighton');
select * from clubtest;
insert into matchtest(id_home, id_guest) values
(1, 3),
(2, 4),
(1, 2),
(2, 5),
(3, 5),
(2, 3)

update matchtest set goal_home = 3, goal_guest = 1 where id = 4
select * from matchtest

drop table if exists home_count

create temp table if not exists matchclone
(
	id serial not null primary key,
	id_home int,
	id_guest int,
	goal_home int,
	goal_guest int
);
insert into matchclone
select * from matchtest where goal_home is not null;

create temp table if not exists home_count(id int, games int, wins int, draws int, loses int, goals int, losts int);
insert into home_count(id, games, wins, draws, loses, goals, losts)
select c.id, count(*),
sum(case when m.goal_home > m.goal_guest then 1 else 0 end),
sum(case when m.goal_home = m.goal_guest then 1 else 0 end),
sum(case when m.goal_home < m.goal_guest then 1 else 0 end),
sum(m.goal_home),
sum(m.goal_guest)
from clubtest c join matchtest m on c.id = m.id_home
where m.goal_home is not null
group by c.id

create temp table if not exists guest_count(id int, games int, wins int, draws int, loses int, goals int, losts int);
insert into guest_count(id, games, wins, draws, loses, goals, losts)
select c.id, count(*) as game,
sum(case when m.goal_home < m.goal_guest then 1 else 0 end) as wins,
sum(case when m.goal_home = m.goal_guest then 1 else 0 end) as draws,
sum(case when m.goal_home > m.goal_guest then 1 else 0 end) as loses,
sum(m.goal_guest) as goals,
sum(m.goal_home) as loses
from clubtest c join matchtest m on c.id = m.id_guest
where m.goal_home is not null
group by c.id

