create table app_logs(
	cause	nvarchar(max) not null,
	place	nvarchar(max) not null,
	text	nvarchar(max) not null,
	date	datetimeoffset not null
);

create table app_rule_categories(
	id		integer identity(1,1)	primary key,
	title	nvarchar(max) not null
);

create table app_rule_paragraph(
	id		integer identity(1,1)	primary key,
	text	nvarchar(max) not null,
	penalty nvarchar(max) not null
);

create table app_rule_reasons(
	id				integer identity(1,1)	primary key,
	category_id		integer not null		foreign key references app_rule_categories(id),
	paragraph_id	integer	not null		foreign key	references app_rule_paragraph(id)
);

create table app_user_roles(
	id					integer identity(1,1)	primary key,
	name				nvarchar(max) not null,
	can_ban_everything	bit not null,
	can_assign_roles	bit not null
);

create table users(
	id					integer identity(1,1)		primary key,
	role_id				integer default 1 not null	foreign key references app_user_roles(id),
	login				nvarchar(max) not null,
	password			nvarchar(max) not null,
	registration_date	datetimeoffset not null,
);

create table user_settings_main(
	user_id				integer			primary key		foreign key references users(id),
	profile_is_private	bit not null
);

create table user_settings_notes(
	user_id						integer			primary key		foreign key references users(id),
	friends_can_create			bit not null,
	friends_can_comment			bit not null,
	not_friends_can_create		bit not null,
	not_friends_can_comment		bit not null
);

create table user_settings_messages(
	user_id										integer			primary key		foreign key references users(id),
	not_friends_can_write						bit not null,
	not_friends_can_invite_into_conversation	bit not null
);

create table groups(
	id				integer identity(1,1)	primary key,
	creation_date	datetimeoffset not null
);

create table conversation_types(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table conversations(
	id				integer identity(1,1)	primary key,
	type_id			integer not null		foreign key references conversation_types(id),
	creation_date	datetimeoffset not null
);

create table app_user_banlists(
	id				integer identity(1,1)		primary key,
	user_id			integer	not null			foreign key references users(id),
	moderator_id	integer	not null			foreign key references users(id),
	reason_id		integer	not null			foreign key references app_rule_reasons(id),
	date_from		datetimeoffset not null,
	date_to			datetimeoffset not null
);

create table app_group_banlists(
	id				integer identity(1,1)		primary key,
	group_id		integer	not null			foreign key references groups(id),
	moderator_id	integer	not null			foreign key	references users(id),
	reason_id		integer	not null			foreign key references app_rule_reasons(id),
	date_from		datetimeoffset not null,
	date_to			datetimeoffset not null
);

create table attitude_to_alcohol(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table attitude_to_smoking(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table main_things_in_people(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table main_things_in_life(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table world_outlook(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table political_preferences(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table user_life_positions(
	user_id		integer			primary key foreign key	references users(id),
	pp_id		integer			foreign key references political_preferences(id),
	wo_id		integer			foreign key	references world_outlook(id),
	mtl_id		integer			foreign key references main_things_in_life(id),
	mtp_id		integer			foreign key	references main_things_in_people(id),
	ats_id		integer			foreign key	references attitude_to_smoking(id),
	ata_id		integer			foreign key	references attitude_to_alcohol(id),
	inspire		nvarchar(max)
);

create table languages(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table user_profile_languages(
	user_id			integer		foreign key references users(id),
	language_id		integer		foreign key references languages(id),
	primary key(user_id, language_id)
);

create table family_statuses(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table countries(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table districts(
	id			integer identity(1,1)	primary key,
	country_id	integer not null		foreign key references countries(id),
	name		nvarchar(max) not null 
);

create table cities(
	id			integer identity(1,1)	primary key,
	district_id integer not null		foreign key references districts(id),
	name		nvarchar(max) not null
);

create table user_profile_main_info(
	user_id				integer					primary key		foreign key references users(id),
	family_status_id	integer					foreign key references family_statuses(id),
	city_id				integer					foreign key references cities(id),
	surname				nvarchar(max) not null,
	name				nvarchar(max) not null,
	patronymic			nvarchar(max),
	avatar				varbinary,
	status				nvarchar(max),
	birthdate			date
);

create table user_profile_career(
	user_id			integer			foreign key references users(id),
	city_id			integer			foreign key references cities(id),
	date_from		date,
	company_name	nvarchar(max),
	job				nvarchar(max),
	date_to			date,
	primary key(user_id, date_from)
);

create table user_profile_military_services(
	user_id integer foreign key references users(id),
	date_from date,
	country_id integer foreign key references countries(id),
	military_unit nvarchar(max),
	date_to date,
	primary key(user_id, date_from)
);

create table study_degrees(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table study_forms(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table study_directions(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null	
);

create table study_faculties(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null	
);

create table faculty_directions(
	faculty_id		integer		foreign key references study_faculties(id),
	direction_id	integer		foreign key references study_directions(id),
	primary key(faculty_id, direction_id)
);

create table universities(
	id			integer identity(1,1)	primary key,
	city_id		integer not null		foreign key references cities(id),
	name		nvarchar(max) not null
);

create table university_faculties(
	university_id	integer		foreign key references universities(id),
	faculty_id		integer		foreign key references study_faculties(id),
	primary key(university_id, faculty_id)
);

create table user_profile_universities(
	user_id			integer		foreign key references users(id),
	univercity_id	integer		foreign key references universities(id),
	degree_id		integer		foreign key references study_degrees(id),
	direction_id	integer		foreign key references study_directions(id),
	study_form_id	integer		foreign key references study_forms(id),
	date_from		date,
	date_to			date,
	primary key(user_id, univercity_id, degree_id, direction_id) 
);

create table conversation_member_roles(
	id					integer identity(1,1)	primary key,
	name				nvarchar(max) not null,
	can_ban_members		bit not null,
	can_assign_roles	bit not null
);

create table conversation_members(
	conversation_id		integer				foreign key references conversations(id),
	user_id				integer				foreign key references users(id),
	role_id				integer not null	foreign key references conversation_member_roles(id),
	primary key(conversation_id, user_id)
);

create table conversation_member_requests(
	conversation_id		integer						foreign key references conversations(id),
	user_id_from		integer						foreign key references users(id),
	user_id_to			integer						foreign key references users(id),
	date				datetimeoffset not null,
	primary key(conversation_id, user_id_from, user_id_to)
);

create table messages(
	id			integer	identity(1,1)	primary key,
	user_id		integer not null		foreign key references users(id),
	text		nvarchar(max) not null,
	date		datetimeoffset not null
);

create table conversation_messages(
	conversation_id		integer		foreign key references conversations(id),
	message_id			integer		foreign key references messages(id),
	primary key(conversation_id, message_id)
);

create table friend_roles(
	id		integer identity(1,1)	primary key,
	name	nvarchar(max) not null
);

create table user_friend_lists(
	page_owner_id	integer						foreign key references users(id),
	friend_id		integer						foreign key references users(id),
	friend_role_id	integer not null			foreign key references friend_roles(id),
	date			datetimeoffset not null,
	primary key(page_owner_id, friend_id)
);

create table user_friend_requests(
	user_id_from	integer					foreign key references users(id),
	user_id_to		integer					foreign key references users(id),
	date			datetimeoffset not null,
	primary key (user_id_from, user_id_to)
);

create table user_group_lists(
	group_id	integer					foreign key references groups(id),
	user_id		integer					foreign key references users(id),
	date		datetimeoffset not null,
	primary key(group_id, user_id)
);

create table user_banlists(
	user_id_ban_from	integer					foreign key references users(id),
	user_id_ban_to		integer					foreign key references users(id),
	date				datetimeoffset not null,
	primary key(user_id_ban_from, user_id_ban_to)
);

create table user_comments(
	id			integer identity(1,1)	primary key,
	user_id		integer not null		foreign key references users(id),
	text		nvarchar(max) not null,
	date		datetimeoffset not null
);

create table user_comment_responses(
	comment_id_from		integer		foreign key references user_comments(id),
	comment_id_to		integer		foreign key references user_comments(id),
	primary key(comment_id_from, comment_id_to)
);

create table user_notes(
	id				integer identity(1,1)	primary key,
	page_owner_id	integer not null		foreign key references users(id),
	user_id			integer not null		foreign key references users(id),
	rating			integer not null,
	text			nvarchar(max) not null,
	date			datetimeoffset not null
);

create table user_note_comments(
	note_id		integer		foreign key references user_notes(id),
	comment_id	integer		foreign key references user_comments(id),
	primary key(note_id, comment_id)
);

create table group_banlists(
	id				integer identity(1,1)		primary key,
	group_id		integer not null			foreign key references groups(id),
	user_id			integer not null			foreign key references users(id),
	moderator_id	integer not null			foreign key references users(id),
	date_from		datetimeoffset not null,
	date_to			datetimeoffset not null
);

create table group_member_requests(
	group_id	integer					foreign key references groups(id),
	user_id		integer					foreign key references users(id),
	date		datetimeoffset not null,
	primary key(group_id, user_id)
);

create table group_main_info(
	group_id		integer					primary key		foreign key references groups(id),
	name			nvarchar(max) not null,
	description		nvarchar(max),
	website_link	nvarchar(max)
);

create table group_member_roles(
	id							integer identity(1,1)	primary key,
	name						nvarchar(max) not null,
	can_create_notes_by_group	bit not null,
	can_create_topics			bit not null,
	can_ban_users				bit not null,
	can_delete_comments			bit not null,
	can_delete_user_notes		bit not null
);

create table group_members(
	group_id		integer				foreign key references groups(id),
	user_id			integer				foreign key references users(id),
	user_role_id	integer not null	foreign key references group_member_roles(id),
	primary key(group_id, user_id)
);

create table group_notes(
	id				integer	identity(1,1)		primary key,
	group_id		integer not null			foreign key references groups(id),
	user_id			integer not null			foreign key references users(id),
	rating			integer not null,
	text			nvarchar(max) not null,
	date			datetimeoffset not null,
	is_admin		bit default 0 not null,
	is_commentable	bit default 1 not null
);

create table group_note_comments(
	note_id		integer		foreign key references group_notes(id),
	comment_id	integer		foreign key references user_comments(id),
	primary key(note_id, comment_id)
);

create table group_topics(
	id				integer identity(1,1)	primary key,
	group_id		integer not null		foreign key references groups(id),
	title			nvarchar(max) not null,
	is_commentable	bit default 1 not null
);

create table group_topic_comments(
	topic_id	integer		foreign key references group_topics(id),
	comment_id	integer		foreign key references user_comments(id),
	primary key(topic_id, comment_id)
);

create table group_settings_main(
	group_id			integer					primary key		foreign key references groups(id),
	group_is_private	bit default 0 not null
);

create table group_settings_notes(
	group_id					integer					primary key		foreign key references groups(id),
	members_can_create_notes	bit default 1 not null,
	members_can_comments_notes	bit default 1 not null
);