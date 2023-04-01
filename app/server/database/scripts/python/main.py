import parsers.browserParser as browser
import parsers.xlsxParser as xlsx
import parsers.jsonParser as json
import os
import enums


ABS_PATH = os.path.dirname(__file__)


browser.GetLanguagesData(
    "https://ru.wikipedia.org/wiki/Список_языков_по_количеству_носителей")
browser.GetUniversitiesData(
    "https://base.garant.ru/70480868/53f89421bbdaf741eb2d1ecc4ddb4c33/")

xlsx.GetXLSXData(
    os.path.join(ABS_PATH, "parsers\\data\\countries.xlsx"), 
    enums.DataType.COUNTRIES)
xlsx.GetXLSXData(
    os.path.join(ABS_PATH, "parsers\\data\\regions.xlsx"), 
    enums.DataType.REGIONS)
xlsx.GetXLSXData(
    os.path.join(ABS_PATH, "parsers\\data\\cities.xlsx"), 
    enums.DataType.CITIES)

json.InsertData(
    os.path.join(ABS_PATH, "parsers\\data\\db_baseInfo.json"))


json.GrantPermissions(
    os.path.join(ABS_PATH, "parsers\\data\\permissions\\db_user_default.json"),
    "user_default")

json.GrantPermissions(
    os.path.join(ABS_PATH, "parsers\\data\\permissions\\db_user_default.json"),
    "user_moderator")
json.GrantPermissions(
    os.path.join(ABS_PATH, "parsers\\data\\permissions\\db_user_moderator.json"),
    "user_moderator")

json.GrantPermissions(
    os.path.join(ABS_PATH, "parsers\\data\\permissions\\db_user_default.json"),
    "user_admin")
json.GrantPermissions(
    os.path.join(ABS_PATH, "parsers\\data\\permissions\\db_user_moderator.json"),
    "user_admin")
json.GrantPermissions(
    os.path.join(ABS_PATH, "parsers\\data\\permissions\\db_user_admin.json"),
    "user_admin")