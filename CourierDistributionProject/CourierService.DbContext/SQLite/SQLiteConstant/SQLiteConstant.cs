using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.DbContext.SQLite.SQLiteConstant
{
    internal static class SQLiteConstant
    {
        internal const string CREATE_DATABASE_QUERY = @"PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS[Categories] (
       [CategoryId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [CategoryName] NVARCHAR(32) UNIQUE NOT NULL
);
CREATE UNIQUE INDEX Unq_Category ON[CarCategories]([CategoryName]);

CREATE TABLE IF NOT EXISTS[Brands] (
       [BrandId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [BrandName] NVARCHAR(32) UNIQUE NOT NULL,
       [CategoryId] INTEGER NOT NULL,
       FOREIGN KEY([CategoryId]) REFERENCES [Categories]([CategoryId])
);	
CREATE UNIQUE INDEX Unq_Brand ON[CarBrands]([BrandName]);

CREATE TABLE IF NOT EXISTS[CarModels] (
       [ModelId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [ModelName] NVARCHAR(32) NULL,
       [BrandId] INTEGER UNIQUE NOT NULL,
       FOREIGN KEY([BrandId]) REFERENCES [Brands]([BrandId])
);		
CREATE UNIQUE INDEX Unq_Model ON[CarModels]([ModelName]);

CREATE TABLE IF NOT EXISTS[Cars] (
       [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [CategoryId] INTEGER NOT NULL,
	   [BrandId] INTEGER NOT NULL,
	   [ModelId] INTEGER NOT NULL,
	   [Details] TEXT NULL,
       [IsTaken] INTEGER DEFAULT 0 CHECK([IsTaken] IN (0,1)),
	   FOREIGN KEY([CategoryId]) REFERENCES[CarCategories] ([CategoryId]),
	   FOREIGN KEY([BrandId]) REFERENCES[CarBrands] ([BrandId]),
	   FOREIGN KEY([ModelId]) REFERENCES[CarModels] ([ModelId])
);";
    }
}
