from bs4 import BeautifulSoup
from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager
import re
import json




 
# Data to be written
dictionary = {
    "name": "sathiyajith",
    "rollno": 56,
    "cgpa": 8.6,
    "phonenumber": "9976770500"
}
 
# Serializing json
json_object = json.dumps(dictionary, indent=4)
 
# Writing to sample.json
with open("sample.json", "w") as outfile:
    outfile.write(json_object)




DRIVER = webdriver.Chrome(ChromeDriverManager().install())


def GetLanguagesData(request: str):
    '''
    Получение информации о мировых языках из Википедии

    request - ссылка на страницу
    '''
    DRIVER.get(request)
    SOUP = BeautifulSoup(DRIVER.page_source, 'lxml')
    REGEX_PATTERN = r'\b[а-яА-Я]+\s(язык)\b'
    DATA = SOUP.find_all('a')
    sql = ""
    dictionary = {
        "data": [
            "tableName": "languages",
            "attributes": [
                "name"
            ],
            "values": [
                1
            ]
        ]
    }
    
    for item in DATA:
        try:
            langName = item.get('title')
            if len(re.findall(REGEX_PATTERN, langName)) != 0:
                currentItem = {
                    "tableName": "languages",
                    "attributes": [
                        "name"
                    ],
                    "values": [
                        langName
                    ]
                }
                dictionary["data"].append()
        except Exception as e:
            print(f"\033[91m>>>{e}\033[0m")