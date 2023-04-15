import json
import codecs
import db_info


def InsertData(path: str):
    '''
    Вставка в базу данных её базовой информации из JSON файла

    path - путь до JSON файла
    '''
    index = 0
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
                    print(f"insert into {tableName}({tableAttributes}) values({tableValues})")
                    db_info.DATABASE_CURSOR.execute(f"insert into {tableName}({tableAttributes}) values({tableValues})")
                    db_info.DATABASE_CONNECTION.commit()
                except Exception as e:
                    print(f"\033[91m>>>{e}\033[0m")

def GrantPermissions(path: str, user: str):
    '''
    Выдача прав для пользователей базы данных

    path - путь до JSON файла

    user - пользователь, к-рому даются права
    '''
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
                print(f"grant {dmlCommand} {attributes} on table {objectName} to {user}")
                db_info.DATABASE_CURSOR.execute(f"\ngrant {dmlCommand} {attributes} on table {objectName} to {user}")
                db_info.DATABASE_CONNECTION.commit()
            except Exception as e:
                print(f"\033[91m>>>{e}\033[0m")
                return