create table if not exists app_error_logs(
	id			serial			primary key,
	message		text not null,
	source 		text not null,
	stack_trace text not null,
	date		timestamp default current_timestamp not null
);