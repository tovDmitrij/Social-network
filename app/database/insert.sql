insert into app_user_roles(name, tag) values('Пользователь', 'default');
select* from app_user_roles;
select* from users;



select* from family_statuses
insert into family_statuses(name, tag) 
select 'fs_name' || trunc(random()*1000), 'fs_tag' || trunc(random()*1000)
from generate_series(1, 10);