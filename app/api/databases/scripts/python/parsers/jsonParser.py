import json
import codecs
from db import ExecuteScript
import enums


def InsertData(path: str, db: enums.Databases):
    '''
    Вставка в базу данных информации из JSON файла

    path - путь до JSON файла

    db - в какую БД будут вставляться данные
    '''
    index = 0
    sql = ""
    with codecs.open(path, 'r', encoding="utf-8") as FILE:
        FILE_DATA = json.load(FILE)
        for table in FILE_DATA["data"]:
            tableName = table['tableName']

            tableAttributes = ""
            index = 0
            for attribute in table['attributes']:
                tableAttributes += attribute
                index += 1
                if len(table['attributes']) != index:
                    tableAttributes += ','

            for values in table['values']:
                tableValues = ""
                index = 0
                for item in values:
                    tableValues += f"'{item}'"
                    index += 1
                    if len(values) != index:
                        tableValues += ','

                try:
                    sql = f"insert into {tableName}({tableAttributes}) values({tableValues})"
                    print(sql)
                    ExecuteScript(sql, db.value)
                except Exception as e:
                    print(f"\033[91m>>>{e}\033[0m")

def GrantPermissions(path: str, user: str, db: enums.Databases):
    '''
    Выдача прав для пользователей базы данных

    path - путь до JSON файла

    user - пользователь, к-рому даются права

    db - в какой БД будут выдаваться права
    '''
    sql = ""
    with codecs.open(path, 'r', encoding="utf-8") as FILE:
        FILE_DATA = json.load(FILE)
        for table in FILE_DATA["data"]:
            dmlCommand = table["dmlCommand"]
            objectName = table["objectName"]
            
            attributes = ""
            if "attributes" in table:
                attributes += "("
                index = 0
                for item in table["attributes"]:
                    attributes += item
                    index += 1
                    if len(table["attributes"]) != index:
                        attributes += ','
                attributes += ")"

            try:
                sql = f"grant {dmlCommand} {attributes} on table {objectName} to {user}"
                print(sql)
                ExecuteScript(sql, db.value)
            except Exception as e:
                print(f"\033[91m>>>{e}\033[0m")
                return