import wikiParser
import xlsxParser
import os
import enums


wikiParser.GetWikipediaData(
    "https://ru.wikipedia.org/wiki/Список_языков_по_количеству_носителей")
xlsxParser.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "data\\countries.xlsx"), 
    enums.DataType.COUNTRIES)
xlsxParser.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "data\\regions.xlsx"), 
    enums.DataType.REGIONS)
xlsxParser.GetXLSXData(
    os.path.join(os.path.dirname(__file__), "data\\cities.xlsx"), 
    enums.DataType.CITIES)