IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Provinces] (
    [ProvinceId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_Provinces] PRIMARY KEY ([ProvinceId])
);

GO

CREATE TABLE [Cities] (
    [CityId] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [ProvinceId] int NOT NULL,
    CONSTRAINT [PK_Cities] PRIMARY KEY ([CityId]),
    CONSTRAINT [FK_Cities_Provinces_ProvinceId] FOREIGN KEY ([ProvinceId]) REFERENCES [Provinces] ([ProvinceId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Cities_ProvinceId] ON [Cities] ([ProvinceId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20190813005831_EFCoreInitial', N'2.2.6-servicing-10079');

GO

