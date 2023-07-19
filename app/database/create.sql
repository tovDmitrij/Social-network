create table if not exists app_rules(
	id 		serial 			primary key,
	title 	text not null,
	text 	text not null,
	penalty text not null
); create index on app_rules(id);

create table if not exists app_user_roles(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on app_user_roles(id); create index on app_user_roles(tag);

create table if not exists users(
	id			serial				primary key,
	role_id		integer 			references app_user_roles(id),
	email		text not null,
	password	text not null,
	date		decimal not null
); create index on users(id); create index on users(email, password);

create table if not exists user_tokens(
	user_id 	integer 			primary key references users(id),
	token 		text not null,
	create_date decimal not null,
	expire_date decimal not null
); create index on user_tokens(user_id);

create table if not exists user_settings(
    user_id                                     integer             primary key references users(id),
    profile_is_private                          boolean not null,
    friends_can_create_notes                    boolean not null,
    friends_can_comment_notes                   boolean not null,
    not_friends_can_create_notes                boolean not null,
    not_friends_can_comment_notes               boolean not null,
    not_friends_can_write_msg                   boolean not null,
    not_friends_can_invite_into_conversation    boolean not null
); create index on user_settings(user_id);

create table if not exists life_position_types(
	id		serial			primary key,
	name	text not null,
    tag     text not null
); create index on life_position_types(id); create index on life_position_types(tag);

create table if not exists life_positions(
	id		serial				primary key,
	type_id	integer not null 	references life_position_types(id),
	name	text not null,
    tag     text not null
); create index on life_positions(id); create index on life_positions(type_id); create index on life_positions(tag);

create table if not exists user_life_positions(
	id					serial				primary key,
	user_id				integer not null	references users(id),
	life_position_id	integer not null	references life_positions(id),
	date				decimal not null
); create index on user_life_positions(user_id);

create table if not exists family_statuses(
	id		serial					primary key,
	name	text not null,
	tag		text not null
); create index on family_statuses(id); create index on family_statuses(tag);

create table if not exists countries(
	id		integer			primary key,
	name	text not null,
	tag		text not null
); create index on countries(id); create index on countries(tag);

create table if not exists regions(
	id			integer				primary key,
	country_id	integer not null	references countries(id),
	name		text not null,
	tag			text not null
); create index on regions(id); create index on regions(country_id); create index on regions(tag);

create table if not exists cities(
	id			integer				primary key,
	region_id 	integer not null	references regions(id),
	name		text not null,
	tag			text not null
); create index on cities(id); create index on cities(region_id); create index on cities(tag);

create table if not exists user_base_info(
	user_id				integer			primary key	references users(id),
	family_status_id	integer			references family_statuses(id),
	city_id				integer			references cities(id),
	surname				text not null,
	name				text not null,
	patronymic			text,
	avatar				text,
	status				text,
	birthdate			decimal
); create index on user_base_info(user_id);

create table if not exists user_careers(
	id				serial				primary key,
	user_id			integer not null	references users(id),
	city_id			integer not null	references cities(id),
	company			text not null,
	job				text,
	date_from		decimal,
	date_to			decimal
); create index on user_careers(user_id);

create table if not exists user_military(
	id				serial				primary key,
	user_id 		integer not null	references users(id),
	country_id 		integer not null	references countries(id),
	military_unit 	text not null,
	date_from 		decimal,
	date_to 		decimal
); create index on user_military(user_id);

create table if not exists languages(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on languages(id); create index on languages(tag);

create table if not exists user_languages(
	id 				serial 				primary key,
	user_id			integer not null	references users(id),
	language_id		integer not null	references languages(id),
	date 			decimal not null
); create index on user_languages(user_id);

create table if not exists study_degrees(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on study_degrees(id); create index on study_degrees(tag);

create table if not exists study_forms(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on study_forms(id); create index on study_forms(tag);

create table if not exists study_directions(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on study_directions(id); create index on study_directions(tag);

create table if not exists study_faculties(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on study_faculties(id); create index on study_faculties(tag);

create table if not exists faculty_directions(
	faculty_id		integer	not null	references study_faculties(id),
	direction_id	integer	not null	references study_directions(id)
); create index on faculty_directions(faculty_id, direction_id);

create table if not exists universities(
	id			serial				primary key,
	city_id		integer not null	references cities(id),
	name		text not null,
	tag			text not null
); create index on universities(id); create index on universities(city_id); create index on universities(tag);

create table if not exists university_faculties(
	university_id	integer not null	references universities(id),
	faculty_id		integer	not null	references study_faculties(id)
); create index on university_faculties(university_id, faculty_id);

create table if not exists user_universities(
	id				serial				primary key,
	user_id			integer not null	references users(id),
	univercity_id	integer not null	references universities(id),
	degree_id		integer				references study_degrees(id),
	direction_id	integer				references study_directions(id),
	study_form_id	integer				references study_forms(id),
	date_from		decimal,
	date_to			decimal
); create index on user_universities(user_id);

create table if not exists user_banlists(
	id 				serial 				primary key,
	user_id_from 	integer not null 	references users(id),
	user_id_to 		integer not null 	references users(id),
	date 			decimal not null
); create index on user_banlists(user_id_from); create index on user_banlists(user_id_to);

create table if not exists user_friend_requests(
	id 				serial 				primary key,
	user_id_from 	integer not null 	references users(id),
	user_id_to 		integer not null 	references users(id),
	date 			decimal not null
); create index on user_friend_requests(user_id_from); create index on user_friend_requests(user_id_to);

create table if not exists friend_roles(
	id 		serial 			primary key,
	name 	text not null,
	tag 	text not null
); create index on friend_roles(id); create index on friend_roles(tag);

create table if not exists user_friends(
	id 				serial 				primary key,
	user_id 		integer not null 	references users(id),
	friend_id 		integer not null 	references users(id),
	friend_role_id 	integer 			references friend_roles(id),
	date 			decimal not null
); create index on user_friends(user_id); create index on user_friends(friend_id);

create table if not exists conversation_types(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on conversation_types(id); create index on conversation_types(tag);

create table if not exists conversations(
	id 		serial 				primary key,
	type_id integer not null 	references conversation_types(id),
	name 	text not null,
	avatar 	text,
	date 	decimal not null
); create index on conversations(id);

create table if not exists conversation_member_roles(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on conversation_member_roles(id); create index on conversation_member_roles(tag);

create table if not exists conversation_members(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	user_id 		integer not null 	references users(id),
	role_id 		integer not null 	references conversation_member_roles(id),
	date			decimal not null
); create index on conversation_members(conversation_id); create index on conversation_members(user_id);

create table if not exists conversation_requests(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	user_id 		integer not null 	references users(id),
	member_id 		integer not null 	references users(id),
	date			decimal not null
); create index on conversation_requests(conversation_id); create index on conversation_requests(user_id);

create table if not exists conversation_banlists(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	member_id 		integer not null 	references users(id),
	moderator_id	integer not null 	references users(id),
	rule_id			integer not null 	references app_rules(id),
	text			text not null,
	date_from		decimal not null,
	date_to			decimal not null
); create index on conversation_banlists(conversation_id);

create table if not exists conversation_messages(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	member_id 		integer not null 	references users(id),
	text			text not null,
	date			decimal not null
); create index on conversation_messages(conversation_id);

create table if not exists conversation_files(
	id 			serial 				primary key,
	message_id 	integer not null 	references conversation_messages(id),
	file 		text not null
); create index on conversation_files(message_id);

create table if not exists groups(
	id 			serial 			primary key,
	name 		text not null,
	description text,
	website 	text,
	date 		decimal not null
); create index on groups(id);

create table if not exists group_settings(
	group_id 						integer not null references groups(id),
	group_is_private 				boolean not null,
	members_can_create_notes 		boolean not null,
	members_can_comment_notes 		boolean not null,
	not_members_can_create_notes 	boolean not null,
	not_members_can_comment_notes 	boolean not null
); create index on group_settings(group_id);

create table if not exists user_groups(
	id 			serial 				primary key,
	group_id 	integer not null 	references groups(id),
	user_id 	integer not null 	references users(id),
	date 		decimal not null
); create index on user_groups(user_id); create index on user_groups(group_id);

create table if not exists group_member_roles(
	id		serial			primary key,
	name	text not null,
	tag		text not null
); create index on group_member_roles(id); create index on group_member_roles(tag);

create table if not exists group_members(
	id 			serial 				primary key,
	group_id 	integer not null 	references groups(id),
	user_id 	integer not null 	references users(id),
	role_id 	integer not null 	references group_member_roles(id),
	date 		decimal not null
); create index on group_members(group_id); create index on group_members(user_id);

create table if not exists group_requests(
	id 			serial 				primary key,
	group_id 	integer not null 	references groups(id),
	user_id 	integer not null 	references users(id),
	date 		decimal not null
); create index on group_requests(group_id); create index on group_requests(user_id);

create table if not exists group_banlists(
	id 				serial 				primary key,
	group_id 		integer not null 	references groups(id),
	member_id 		integer not null 	references users(id),
	moderator_id	integer not null 	references users(id),
	rule_id			integer not null 	references app_rules(id),
	text			text not null,
	date_from		decimal not null,
	date_to			decimal not null
); create index on group_banlists(group_id);

create table if not exists notes(
	id 		serial 				primary key,
	user_id integer not null 	references users(id),
	text 	text not null,
	date 	decimal not null
); create index on notes(id);

create table if not exists user_notes(
	note_id 		integer not null references notes(id),
	page_id 		integer not null references users(id),
	is_commentable 	boolean not null
); create index on user_notes(note_id, page_id);

create table if not exists group_notes(
	note_id 		integer not null references notes(id),
	group_id 		integer not null references groups(id),
	is_admin 		boolean not null,
	is_commentable 	boolean not null
); create index on group_notes(note_id, group_id);

create table if not exists group_topics(
	topic_id 		integer not null references notes(id),
	group_id 		integer not null references groups(id),
	title 			text not null,
	is_commentable 	boolean not null
); create index on group_topics(topic_id, group_id);

create table if not exists user_comments(
	id 		serial 				primary key,
	user_id integer not null 	references users(id),
	text 	text not null,
	date	decimal not null
); create index on user_comments(user_id);

create table if not exists comment_files(
	id 			serial 				primary key,
	comment_id 	integer not null 	references user_comments(id),
	file 		text not null
); create index on comment_files(comment_id);

create table if not exists comment_notes(
	note_id 	integer not null references notes(id),
	comment_id 	integer not null references user_comments(id)
); create index on comment_notes(note_id, comment_id);

create table if not exists comment_responses(
	comment_id_from integer not null references user_comments(id),
	comment_id_to 	integer not null references user_comments(id)
); create index on comment_responses(comment_id_from, comment_id_to);

create table if not exists user_reactions(
	id 			serial primary key,
	user_id 	integer not null references users(id),
	reaction 	boolean not null
); create index on user_reactions(user_id);

create table if not exists comment_reactions(
	comment_id 	integer not null references user_comments(id),
	reaction_id integer not null references user_reactions(id)
); create index on comment_reactions(comment_id, reaction_id);

create table if not exists note_reactions(
	note_id 	integer not null references notes(id),
	reaction_id integer not null references user_reactions(id)
); create index on note_reactions(note_id, reaction_id);

create table if not exists app_ban_requests(
	id 		serial 				primary key,
	user_id integer not null,
	text	text not null,
	date 	decimal not null
); create index on app_ban_requests(id); create index on app_ban_requests(user_id);

create table if not exists app_user_banlists(
	id 				serial 				primary key,
	user_id 		integer not null 	references users(id),
	moderator_id 	integer not null 	references users(id),
	rule_id 		integer not null 	references app_rules(id),
	text 			text not null,
	date_from 		decimal not null,
	date_to 		decimal not null
); create index on app_user_banlists(moderator_id); create index on app_user_banlists(user_id);

create table if not exists app_group_banlists(
	id 				serial 				primary key,
	group_id 		integer not null 	references groups(id),
	moderator_id 	integer not null 	references users(id),
	rule_id 		integer not null 	references app_rules(id),
	text 			text not null,
	date_from 		decimal not null,
	date_to 		decimal not null
);  create index on app_group_banlists(moderator_id); create index on app_group_banlists(group_id);

create table if not exists app_conversation_banlists(
	id 				serial 				primary key,
	conversation_id integer not null 	references conversations(id),
	moderator_id 	integer not null 	references users(id),
	rule_id 		integer not null 	references app_rules(id),
	text 			text not null,
	date_from 		decimal not null,
	date_to 		decimal not null
);  create index on app_conversation_banlists(moderator_id); create index on app_conversation_banlists(conversation_id);