import psycopg2


DATABASE_CONNECTION = psycopg2.connect(
    dbname='social_network', 
    user='postgres', 
    password='123456', 
    host='localhost')
DATABASE_CURSOR = DATABASE_CONNECTION.cursor()