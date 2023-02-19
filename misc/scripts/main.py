import parsers.browserParser as browser
import parsers.xlsxParser as xlsx
import parsers.jsonParser as json
import os
import enums

'''
browser.GetWikipediaData(
    "https://ru.wikipedia.org/wiki/Список_языков_по_количеству_носителей")
browser.GetGarantData(
    "https://base.garant.ru/70480868/53f89421bbdaf741eb2d1ecc4ddb4c33/")

xlsx.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\countries.xlsx"), 
    enums.DataType.COUNTRIES)
xlsx.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\regions.xlsx"), 
    enums.DataType.REGIONS)
xlsx.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\cities.xlsx"), 
    enums.DataType.CITIES)

json.GetJSONData(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\data.json"))
'''
json.GrantPermissions(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\permissions\\db_user_default.json"),
    "user_default")