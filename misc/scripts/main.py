import parsers.browserParser
import parsers.xlsxParser
import parsers.jsonParser
import os
import enums


parsers.browserParser.GetWikipediaData(
    "https://ru.wikipedia.org/wiki/Список_языков_по_количеству_носителей")

parsers.xlsxParser.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\countries.xlsx"), 
    enums.DataType.COUNTRIES)
parsers.xlsxParser.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\regions.xlsx"), 
    enums.DataType.REGIONS)
parsers.xlsxParser.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\cities.xlsx"), 
    enums.DataType.CITIES)

parsers.jsonParser.GetJSONData(
    os.path.join(os.path.dirname(__file__), "parsers\\data\\data.json"))