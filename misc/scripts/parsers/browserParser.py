from bs4 import BeautifulSoup
from selenium import webdriver
from webdriver_manager.chrome import ChromeDriverManager
import re
import db_info


DRIVER = webdriver.Chrome(ChromeDriverManager().install())


def GetWikipediaData(request: str):
    '''
    Get information (world languages) from Wikipedia pages

    request - link to specific page
    '''
    DRIVER.get(request)
    SOUP = BeautifulSoup(DRIVER.page_source, 'lxml')
    REGEX_PATTERN = r'\b[а-яА-Я]+\s(язык)\b'
    DATA = SOUP.find_all('a')
    DATA_LENGTH = len(DATA)
    index = 1
    
    for item in DATA:
        print(f">>Iteration: {index} / {DATA_LENGTH}")
        index += 1
        try:
            langName = item.get('title')
            if len(re.findall(REGEX_PATTERN, langName)) != 0:
                langName = langName[0:langName.find(' ')]
                db_info.DATABASE_CURSOR.execute(f"select count(*) from languages where name='{langName}'")
                if (db_info.DATABASE_CURSOR.fetchone()[0] >= 1):
                    continue
                db_info.DATABASE_CURSOR.execute(f"insert into languages(name) values('{langName}')")
                db_info.DATABASE_CONNECTION.commit()
        except Exception as e:
            print(f">>Error: {e}")