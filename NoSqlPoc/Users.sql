create table users (
	userid uuid primary key,
	firstname text,
	lastname text,
	age int,
	city text,
	email text
);

CREATE INDEX user_state
   ON demo.users (lastname);