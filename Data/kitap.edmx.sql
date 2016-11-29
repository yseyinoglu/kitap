
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/29/2016 19:22:16
-- Generated from EDMX file: C:\Users\Yasin\Desktop\KitapSatis\Data\kitap.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [kitap];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserTypeUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserSet] DROP CONSTRAINT [FK_UserTypeUser];
GO
IF OBJECT_ID(N'[dbo].[FK_UserSikayet]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SikayetSet] DROP CONSTRAINT [FK_UserSikayet];
GO
IF OBJECT_ID(N'[dbo].[FK_UserKitapİlan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KitapİlanSet] DROP CONSTRAINT [FK_UserKitapİlan];
GO
IF OBJECT_ID(N'[dbo].[FK_UserYorum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[YorumSet] DROP CONSTRAINT [FK_UserYorum];
GO
IF OBJECT_ID(N'[dbo].[FK_KategoriKitapİlan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KitapİlanSet] DROP CONSTRAINT [FK_KategoriKitapİlan];
GO
IF OBJECT_ID(N'[dbo].[FK_KitapDetayKitapİlan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[KitapİlanSet] DROP CONSTRAINT [FK_KitapDetayKitapİlan];
GO
IF OBJECT_ID(N'[dbo].[FK_KitapİlanYorum]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[YorumSet] DROP CONSTRAINT [FK_KitapİlanYorum];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[UserTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserTypeSet];
GO
IF OBJECT_ID(N'[dbo].[SikayetSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SikayetSet];
GO
IF OBJECT_ID(N'[dbo].[KategoriSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KategoriSet];
GO
IF OBJECT_ID(N'[dbo].[KitapDetaySet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KitapDetaySet];
GO
IF OBJECT_ID(N'[dbo].[YorumSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[YorumSet];
GO
IF OBJECT_ID(N'[dbo].[KitapİlanSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KitapİlanSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserTypeId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Mail] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [Avatar] varbinary(max)  NOT NULL
);
GO

-- Creating table 'UserTypeSet'
CREATE TABLE [dbo].[UserTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Yetki] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SikayetSet'
CREATE TABLE [dbo].[SikayetSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Konu] nvarchar(max)  NOT NULL,
    [Açıklama] nvarchar(max)  NOT NULL,
    [Tarih] datetime  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'KategoriSet'
CREATE TABLE [dbo].[KategoriSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KatagoriAdi] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'KitapDetaySet'
CREATE TABLE [dbo].[KitapDetaySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [KitapSayfaNo] nvarchar(max)  NOT NULL,
    [KitapYazari] nvarchar(max)  NOT NULL,
    [KitapYayinTarihi] datetime  NOT NULL,
    [KitapBaskıSayısı] nvarchar(max)  NOT NULL,
    [KitapBoyutu] nvarchar(max)  NOT NULL,
    [KitapDili] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'YorumSet'
CREATE TABLE [dbo].[YorumSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Tarih] datetime  NOT NULL,
    [Verified] bit  NOT NULL,
    [UserId] int  NOT NULL,
    [KitapİlanId] int  NOT NULL
);
GO

-- Creating table 'KitapİlanSet'
CREATE TABLE [dbo].[KitapİlanSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Baslik] nvarchar(max)  NOT NULL,
    [KitapSayfaNo] nvarchar(max)  NOT NULL,
    [KitapFiyat] nvarchar(max)  NOT NULL,
    [KitapTarih] datetime  NOT NULL,
    [UserId] int  NOT NULL,
    [KategoriId] int  NOT NULL,
    [KitapDetayId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserTypeSet'
ALTER TABLE [dbo].[UserTypeSet]
ADD CONSTRAINT [PK_UserTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SikayetSet'
ALTER TABLE [dbo].[SikayetSet]
ADD CONSTRAINT [PK_SikayetSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KategoriSet'
ALTER TABLE [dbo].[KategoriSet]
ADD CONSTRAINT [PK_KategoriSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KitapDetaySet'
ALTER TABLE [dbo].[KitapDetaySet]
ADD CONSTRAINT [PK_KitapDetaySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'YorumSet'
ALTER TABLE [dbo].[YorumSet]
ADD CONSTRAINT [PK_YorumSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'KitapİlanSet'
ALTER TABLE [dbo].[KitapİlanSet]
ADD CONSTRAINT [PK_KitapİlanSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserTypeId] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [FK_UserTypeUser]
    FOREIGN KEY ([UserTypeId])
    REFERENCES [dbo].[UserTypeSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTypeUser'
CREATE INDEX [IX_FK_UserTypeUser]
ON [dbo].[UserSet]
    ([UserTypeId]);
GO

-- Creating foreign key on [UserId] in table 'SikayetSet'
ALTER TABLE [dbo].[SikayetSet]
ADD CONSTRAINT [FK_UserSikayet]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSikayet'
CREATE INDEX [IX_FK_UserSikayet]
ON [dbo].[SikayetSet]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'KitapİlanSet'
ALTER TABLE [dbo].[KitapİlanSet]
ADD CONSTRAINT [FK_UserKitapİlan]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserKitapİlan'
CREATE INDEX [IX_FK_UserKitapİlan]
ON [dbo].[KitapİlanSet]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'YorumSet'
ALTER TABLE [dbo].[YorumSet]
ADD CONSTRAINT [FK_UserYorum]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserYorum'
CREATE INDEX [IX_FK_UserYorum]
ON [dbo].[YorumSet]
    ([UserId]);
GO

-- Creating foreign key on [KategoriId] in table 'KitapİlanSet'
ALTER TABLE [dbo].[KitapİlanSet]
ADD CONSTRAINT [FK_KategoriKitapİlan]
    FOREIGN KEY ([KategoriId])
    REFERENCES [dbo].[KategoriSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KategoriKitapİlan'
CREATE INDEX [IX_FK_KategoriKitapİlan]
ON [dbo].[KitapİlanSet]
    ([KategoriId]);
GO

-- Creating foreign key on [KitapDetayId] in table 'KitapİlanSet'
ALTER TABLE [dbo].[KitapİlanSet]
ADD CONSTRAINT [FK_KitapDetayKitapİlan]
    FOREIGN KEY ([KitapDetayId])
    REFERENCES [dbo].[KitapDetaySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KitapDetayKitapİlan'
CREATE INDEX [IX_FK_KitapDetayKitapİlan]
ON [dbo].[KitapİlanSet]
    ([KitapDetayId]);
GO

-- Creating foreign key on [KitapİlanId] in table 'YorumSet'
ALTER TABLE [dbo].[YorumSet]
ADD CONSTRAINT [FK_KitapİlanYorum]
    FOREIGN KEY ([KitapİlanId])
    REFERENCES [dbo].[KitapİlanSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KitapİlanYorum'
CREATE INDEX [IX_FK_KitapİlanYorum]
ON [dbo].[YorumSet]
    ([KitapİlanId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------