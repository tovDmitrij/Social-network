import pyodbc

CONNECTION_STRING = """
    Driver=SQL SERVER;
    Server=DESKTOP-5RRMH4H;
    Database=social-network;
    Trusted_Connection=yes;"""
DATABASE_CONNECTION = pyodbc.connect(CONNECTION_STRING)
DATABASE_CURSOR = DATABASE_CONNECTION.cursor()