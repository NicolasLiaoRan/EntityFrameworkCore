IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Companies] (
    [CompanyId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [EstablishTime] datetime2 NOT NULL,
    [LegalPerson] nvarchar(max) NULL,
    CONSTRAINT [PK_Companies] PRIMARY KEY ([CompanyId])
);

GO

CREATE TABLE [Countries] (
    [CountryId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY ([CountryId])
);

GO

CREATE TABLE [Provinces] (
    [ProvinceId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [Population] int NOT NULL,
    CONSTRAINT [PK_Provinces] PRIMARY KEY ([ProvinceId])
);

GO

CREATE TABLE [Departments] (
    [DepartmentId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [CompanyId] int NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentId]),
    CONSTRAINT [FK_Departments_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([CompanyId]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Presidents] (
    [PresidentId] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [Birthday] datetime2 NOT NULL,
    [Gender] int NOT NULL,
    [CountryId] int NOT NULL,
    CONSTRAINT [PK_Presidents] PRIMARY KEY ([PresidentId]),
    CONSTRAINT [FK_Presidents_Countries_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [Countries] ([CountryId]) ON DELETE CASCADE
);

GO

CREATE TABLE [Cities] (
    [CityId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [AreaCode] nvarchar(max) NULL,
    [ProvinceId] int NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([CityId]),
    CONSTRAINT [FK_Cities_Provinces_ProvinceId] FOREIGN KEY ([ProvinceId]) REFERENCES [Provinces] ([ProvinceId]) ON DELETE CASCADE
);

GO

CREATE TABLE [CompanyDepartments] (
    [CompanyId] int NOT NULL,
    [DepartmentId] int NOT NULL,
    CONSTRAINT [PK_CompanyDepartments] PRIMARY KEY ([CompanyId], [DepartmentId]),
    CONSTRAINT [FK_CompanyDepartments_Companies_CompanyId] FOREIGN KEY ([CompanyId]) REFERENCES [Companies] ([CompanyId]) ON DELETE CASCADE,
    CONSTRAINT [FK_CompanyDepartments_Departments_DepartmentId] FOREIGN KEY ([DepartmentId]) REFERENCES [Departments] ([DepartmentId]) ON DELETE CASCADE
);

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProvinceId', N'Name', N'Population') AND [object_id] = OBJECT_ID(N'[Provinces]'))
    SET IDENTITY_INSERT [Provinces] ON;
INSERT INTO [Provinces] ([ProvinceId], [Name], [Population])
VALUES (1, N'四川', 10000000);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'ProvinceId', N'Name', N'Population') AND [object_id] = OBJECT_ID(N'[Provinces]'))
    SET IDENTITY_INSERT [Provinces] OFF;

GO

CREATE INDEX [IX_Cities_ProvinceId] ON [Cities] ([ProvinceId]);

GO

CREATE INDEX [IX_CompanyDepartments_DepartmentId] ON [CompanyDepartments] ([DepartmentId]);

GO

CREATE INDEX [IX_Departments_CompanyId] ON [Departments] ([CompanyId]);

GO

CREATE UNIQUE INDEX [IX_Presidents_CountryId] ON [Presidents] ([CountryId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190814113200_EfCoreInitialSeed', N'2.2.6-servicing-10079');

GO

