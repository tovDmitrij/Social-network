import os
import parsers.enums as enums


print(enums.Databases.Dictionary.value)


ABS_PATH = os.path.dirname(__file__)

'''
import parsers.browserParser as browser
import parsers.xlsxParser as xlsx
import parsers.jsonParser as json
browser.GetLanguagesData("https://ru.wikipedia.org/wiki/Список_языков_по_количеству_носителей")
#browser.GetUniversitiesData("https://base.garant.ru/70480868/53f89421bbdaf741eb2d1ecc4ddb4c33/")
xlsx.GetXLSXData(os.path.join(ABS_PATH, "parsers\\data\\countries.xlsx"), enums.DataType.COUNTRIES)
xlsx.GetXLSXData(os.path.join(ABS_PATH, "parsers\\data\\regions.xlsx"), enums.DataType.REGIONS)
xlsx.GetXLSXData(os.path.join(ABS_PATH, "parsers\\data\\cities.xlsx"), enums.DataType.CITIES)
json.InsertData(os.path.join(ABS_PATH, "parsers\\data\\db_baseInfo.json"))
#json.GrantPermissions(os.path.join(ABS_PATH, "parsers\\data\\permissions\\db_user_default.json"),"user_default")
'''