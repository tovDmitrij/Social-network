import psycopg2


def ExecuteScript (sql: str, db: str):
    '''
    Отправить скрипт в БД

    sql - полная sql-команда

    db - в какую БД выполняется команда
    '''
    DATABASE_CONNECTION = psycopg2.connect(
        dbname=f'db.{db}', 
        user='postgres', 
        password='123456', 
        host='localhost')
    DATABASE_CURSOR = DATABASE_CONNECTION.cursor()
    
    DATABASE_CURSOR.execute(sql)
    DATABASE_CONNECTION.commit()