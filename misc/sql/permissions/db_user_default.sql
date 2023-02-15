--grant
--https://learn.microsoft.com/ru-ru/sql/t-sql/statements/grant-transact-sql?view=sql-server-ver16

--revoke
--https://learn.microsoft.com/ru-ru/sql/t-sql/statements/revoke-object-permissions-transact-sql?view=sql-server-ver16

create application role user_default 
	with password = '1htWu08YW$', 
	default_schema = dbo;

revoke select, update, delete, insert, execute, references 
	on schema::DBO 
	to user_default;

grant select on users to user_default;
grant insert on users to user_default;
grant delete on users to user_default;
grant update on users(password) to user_default;

grant select on user_life_positions to user_default;
grant update user_life_positions(pp_id,) to user_default;