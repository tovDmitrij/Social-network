insert into app_user_roles(name, can_ban_everything, can_assign_roles)
	values('default', 0, 0);
insert into app_user_roles(name, can_ban_everything, can_assign_roles)
	values('moderator', 1, 0);
insert into app_user_roles(name, can_ban_everything, can_assign_roles)
	values('admin', 1, 1);

insert into users(login, password) values('admin', 'admin')