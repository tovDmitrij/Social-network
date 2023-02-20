create user user_default with password 'jwu7iSQ';
revoke all privileges on database social_network from user_default;

create user user_moderator with password 'g2Wu18x';
revoke all privileges on database social_network from user_moderator;

create user user_admin with password '52iJs*x';
revoke all privileges on database social_network from user_admin;