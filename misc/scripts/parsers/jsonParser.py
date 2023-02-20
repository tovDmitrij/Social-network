import json
import codecs
import db_info


def InsertData(path: str):
    '''
    Get information from JSON file

    path - path to the JSON file
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
                    print(f"\ninsert into {tableName}({tableAttributes}) values({tableValues})")
                    db_info.DATABASE_CURSOR.execute(f"insert into {tableName}({tableAttributes}) values({tableValues})")
                    db_info.DATABASE_CONNECTION.commit()
                except Exception as e:
                    print(f">>Error: {e}")

def GrantPermissions(path: str, user: str):
    '''
    Grant a permission for DB users

    path - path to the JSON file

    user - user, who take the permissions
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
                print(f"\ngrant {dmlCommand} {attributes} on table {objectName} to {user}")
                db_info.DATABASE_CURSOR.execute(f"\ngrant {dmlCommand} {attributes} on table {objectName} to {user}")
                db_info.DATABASE_CONNECTION.commit()
            except Exception as e:
                print(f">>Error: {e}")
