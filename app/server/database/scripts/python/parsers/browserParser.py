from bs4 import BeautifulSoup
from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager
import re
import db_info


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
    
    for item in DATA:
        try:
            langName = item.get('title')
            if len(re.findall(REGEX_PATTERN, langName)) != 0:
                langName = langName[0:langName.find(' ')]
                db_info.DATABASE_CURSOR.execute(f"select count(*) from languages where name='{langName}'")
                if (db_info.DATABASE_CURSOR.fetchone()[0] >= 1):
                    continue

                sql = f"insert into languages(name) values('{langName}')"
                print(sql)
                db_info.DATABASE_CURSOR.execute(sql)
                db_info.DATABASE_CONNECTION.commit()
        except Exception as e:
            print(f"\033[91m>>>{e}\033[0m")

def GetUniversitiesData(request: str):
    '''
    !!!NOT COMPLETED!!! Получение информации об университетах с сайта https://base.garant.ru/

    request - ссылка на страницу
    '''
    DRIVER.get(request)
    SOUP = BeautifulSoup(DRIVER.page_source, 'lxml')
    DATA = SOUP.find_all('p', 's_16')
    for item in DATA:
        print(f"{item}")