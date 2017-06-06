PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS [CarCategories] (
       [CategoryId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [CategoryName] NVARCHAR(32) NULL
);
CREATE UNIQUE INDEX Unq_Category ON [CarCategories]([CategoryName]);

CREATE TABLE IF NOT EXISTS [CarBrands] (
       [BrandId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [BrandName] NVARCHAR(32) NULL
);	
CREATE UNIQUE INDEX Unq_Brand ON [CarBrands]([BrandName]);

CREATE TABLE IF NOT EXISTS [CarModels] (
       [ModelId] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
       [ModelName] NVARCHAR(32) NULL
);		
CREATE UNIQUE INDEX Unq_Model ON [CarModels]([ModelName]);

CREATE TABLE IF NOT EXISTS [Cars] (
       [Id] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
	   [CategoryId] INTEGER NOT NULL,
	   [BrandId] INTEGER NOT NULL,
	   [ModelId] INTEGER NOT NULL,
	   [Details] TEXT NULL,
       [IsTaken] INTEGER DEFAULT 0 CHECK([IsTaken] IN (0,1)),
	   FOREIGN KEY ([CategoryId]) REFERENCES [CarCategories] ([CategoryId]),
	   FOREIGN KEY ([BrandId]) REFERENCES [CarBrands] ([BrandId]),
	   FOREIGN KEY ([ModelId]) REFERENCES [CarModels] ([ModelId])
);