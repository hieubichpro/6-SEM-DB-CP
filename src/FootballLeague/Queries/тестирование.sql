create or replace function test_get_table()
returns void as
$$
begin
	drop table if exists expected_res;
	create temp table if not exists expected_res
	(
		name varchar(64),
		allgames int,
		games int,
		wins int,
		draws int,
		loses int,
		goals int,
		losts int,
		diff int,
		points int
	);
	
	insert into expected_res values
	('Atalanta',	10,	10,	6,	0,	4,	59,	44,	15,	18),
	('Sevilla',	10,	10,	5,	3,	2,	56,	42,	14,	18),
	('Luton',	10,	10,	5,	1,	4,	67,	54,	13,	16),
	('Villareal',	10,	10,	4,	2,	4,	50,	48,	2,	14),
	('Real Madrid',	10,	10,	4,	1,	5,	38,	55,	-17,	13),
	('Man UTD',	10,	10,	1,	3,	6,	42,	69,	-27,	6);
	
	call auto_compare(5);
	
	truncate expected_res;
	insert into expected_res values
	('Atalanta',	6,	4,	2,	1,	1,	22,	21,	1,	7),
	('Villareal',	6,	3,	2,	0,	1,	25,	20,	5,	6),
	('Sevilla',	6,	3,	1,	1,	1,	18,	16,	2,	4),
	('Aston Villa',	6,	2,	0,	0,	2,	11,	19,	-8,	0);
	
	call auto_compare(4);
	
	truncate expected_res;
	insert into expected_res values
	('Arsenal',	6,	0,	0,	0,	0,	0,	0,	0,	0),
	('Aston Villa',	6,	0,	0,	0,	0,	0,	0,	0,	0),
	('Luton',	6,	0,	0,	0,	0,	0,	0,	0,	0),
	('Real Madrid',	6,	0,	0,	0,	0,	0,	0,	0,	0);
	
	call auto_compare(8);
	
	raise notice 'All tests passed';
end;
$$
language plpgsql;

select test_get_table();

create or replace procedure auto_compare(id_ int)
language plpgsql
as
$$
declare
	rec RECORD;
begin
	for rec in (select * from expected_res 
				except 
				select * from get_table_league(id_))
	loop
		raise exception 'Test failed: Unexpected result %', rec;
	end loop;
	raise notice 'Tess passed';
end;
$$


CREATE OR REPLACE FUNCTION test_trigger()
RETURNS void AS $$
DECLARE
    rec RECORD;
BEGIN
select rating from leagues where id in (5, 8, 9);
    INSERT INTO feedbacks(grade, id_user, id_league) VALUES (3, 100, 5);
	INSERT INTO feedbacks(grade, id_user, id_league) VALUES (5, 100, 8);
	INSERT INTO feedbacks(grade, id_user, id_league) VALUES (1, 100, 9);

    -- Проверяем результаты
    FOR rec IN (SELECT id, rating FROM leagues WHERE (id, rating) NOT IN ((5, 2.24), (8, 3), (9, 1))) LOOP
        RAISE EXCEPTION 'Test failed: Unexpected result %', rec;
    END LOOP;

    RAISE NOTICE 'All tests passed';
END;
$$ LANGUAGE plpgsql;

-- Запуск теста
SELECT test_trigger();


select * from feedbacks
-- select * from clubs
-- select * from users where id = 23
-- select * from leagueclub where id_league = 8
-- select * from leagues
-- insert into leagueclub(id_league, id_club) values (8, 1), (8, 3), (8, 4), (8, 5);
-- call auto_fill(4);
-- select * from get_table_league(8);
-- select * from matches where id_league = 4
-- update matches set goal_home_club = null, goal_guess_club = null where id = 255


delete from matches where id_league = 8

create or replace function rotate_teams(full_id int[])
returns int[] 
as
$$
declare
	last_id int;
	size int;
begin
	size := array_length(full_id, 1);
	last_id := full_id[size];
    for i in reverse size..3 loop
        full_id[i] := full_id[i - 1];
    end loop;
	full_id[2] := last_id;
	return full_id;
end;
$$
language plpgsql;


create or replace function create_schedule(id_l int) returns void as $$
declare
    size int;
	ss int;
    start_first_leg date := '2024-05-24';
    start_second_leg date;
	full_id int[];
	id_stadiums int[];
    week int;
    random_index int;
begin
	select array_agg(id_club) into full_id from leagueclub where id_league = id_l;
	size := array_length(full_id, 1);
	select array_agg(id) into id_stadiums from stadiums;
	ss := array_length(id_stadiums, 1);

    start_second_leg := start_first_leg + INTERVAL '7' DAY * (size - 1);

    for week in 1..(size - 1) loop
        call createMatch(id_l, id_stadiums[getRandomNum(ss)], full_id[1], full_id[2], week, start_first_leg);
		call createMatch(id_l, id_stadiums[getRandomNum(ss)], full_id[2], full_id[1], week + size - 1, start_second_leg);

        for i in 0..(size / 2 - 2) loop
			call createMatch(id_l, id_stadiums[getRandomNum(ss)], full_id[3 + i], full_id[size - i], week, start_first_leg);
			call createMatch(id_l, id_stadiums[getRandomNum(ss)], full_id[size - i], full_id[3 + i], week + size - 1, start_second_leg);			
        end loop;

        full_id = rotate_teams(full_id);
        start_first_leg := start_first_leg + INTERVAL '7' day;
        start_second_leg := start_second_leg + INTERVAL '7' day;
    end loop;
end;
$$
language plpgsql;

select create_schedule(13);
select * from matches where id_league = 13 order by week;
delete from matches where id_league =13;

select id_club from leagueclub where id_league = 13;
select * from tmptest
select * from leagueclub where id_league = 13
select * from clubs
insert into leagueclub(id_league, id_club) values (13, 4), (13, 5), (13, 6), (13, 7); 
select rotate_teams();
truncate tmptest
select * from tmptest
select count(*) from tmptest


create or replace procedure createMatch(idLeague int, idStadium int, idHome int, idGuest int, week int, timestart date)
language plpgsql
as
$$
begin
	insert into matches(id_league, id_stadium, id_home_club, id_guess_club, week, timestart) values
	(idLeague, idStadium, idHome, idGuest, week, timestart);
end;
$$

insert into tmptest(id_team) values(select id_team from tmp_test where id = 3);

create or replace procedure testt()
language plpgsql
as
$$
declare
	full_id int[];
	start_first_leg date := '2024-05-24';
    start_second_leg date;
begin
-- 	select array_agg(id_club) into full_id from leagueclub where id_league = 13;
-- 	FOR i IN 1..4 LOOP
-- 		raise notice 'element %', full_id[getRandomNum(4)];
-- 	END LOOP;
 	start_second_leg := start_first_leg + INTERVAL '7' DAY * (size - 1);
	select * from clubs;
	raise notice 'aa % %', start_first_leg, start_second_leg;
end;
$$

call testt();

create or replace function getRandomNum(max_ int)
returns int
as
$$
begin
	return floor(random() * max_ + 1)::int;
end;
$$
language plpgsql;

select getRandomNum(6);

select * from leagueclub

create table if not exists tabtest
(
	id_league int,
	id_team int
);

create or replace procedure autof()
language plpgsql
as
$$
declare
	id_league int := 1;
	id_team int := 1;
	cl int := 1;
begin
	for i in 1..10 loop
		cl := 10 * i;
		for j in 1..cl loop
			insert into tabtest values (i, j);
		end loop;
	end loop;
end;
$$

insert into tabtest values (0, 1);
insert into tabtest values (0, 2);
select * from tabtest where id_league = 0;

call autof();
select * from tabtest

CREATE OR REPLACE FUNCTION example_function()
RETURNS void AS $$
DECLARE
    start_time timestamp;
    end_time timestamp;
    elapsed_time interval;
BEGIN
	for id in 0..10 loop
		-- Запоминаем начальное время
		start_time := clock_timestamp();

		perform test_schedule(id);

		-- Запоминаем конечное время
		end_time := clock_timestamp();

		-- Вычисляем время выполнения
		elapsed_time := end_time - start_time;

		-- Выводим время выполнения
		RAISE NOTICE 'Elapsed time: %', EXTRACT(epoch FROM elapsed_time) * 1000;
	end loop;
END;
$$ LANGUAGE plpgsql;

select example_function();

create or replace function test_schedule(id_l int) returns void as $$
declare
    size int;
	ss int;
    start_first_leg date := '2024-05-24';
    start_second_leg date;
	full_id int[];
	id_stadiums int[];
    week int;
    random_index int;
begin
	select array_agg(id_team) into full_id from tabtest where id_league = id_l;
	size := array_length(full_id, 1);
	select array_agg(id) into id_stadiums from stadiums;
	ss := array_length(id_stadiums, 1);

    start_second_leg := start_first_leg + INTERVAL '7' DAY * (size - 1);

    FOR week IN 1..(size - 1) LOOP
        call createMatchTest(id_l, id_stadiums[getRandomNum(ss)], full_id[1], full_id[2], week, start_first_leg);
		call createMatchTest(id_l, id_stadiums[getRandomNum(ss)], full_id[2], full_id[1], week + size - 1, start_second_leg);

        FOR i IN 0..(size / 2 - 2) LOOP
			call createMatchTest(id_l, id_stadiums[getRandomNum(ss)], full_id[3 + i], full_id[size - i], week, start_first_leg);
			call createMatchTest(id_l, id_stadiums[getRandomNum(ss)], full_id[size - i], full_id[3 + i], week + size - 1, start_second_leg);			
        END LOOP;

        full_id = rotate_teams(full_id);
        start_first_leg := start_first_leg + INTERVAL '7' DAY;
        start_second_leg := start_second_leg + INTERVAL '7' DAY;
    END LOOP;
END;
$$ LANGUAGE plpgsql;


create or replace procedure createMatchTest(idLeague int, idStadium int, idHome int, idGuest int, week int, timestart date)
language plpgsql
as
$$
begin
	insert into mtest(id_league, id_stadium, id_home_club, id_guess_club, week, timestart) values
	(idLeague, idStadium, idHome, idGuest, week, timestart);
end;
$$

create table mtest
(
	homegoal int,
	guestgoal int,
	id_league int,
	id_stadium int,
	id_home_club int,
	id_guess_club int,
	week int,
	timestart varchar(100)
);