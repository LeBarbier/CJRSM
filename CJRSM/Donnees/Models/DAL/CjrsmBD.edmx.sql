
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/22/2017 13:43:25
-- Generated from EDMX file: L:\CJRSM\CJRSM\Donnees\Models\DAL\CjrsmBD.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MembreActivite_Membre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MembreActivite] DROP CONSTRAINT [FK_MembreActivite_Membre];
GO
IF OBJECT_ID(N'[dbo].[FK_MembreActivite_Activite]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MembreActivite] DROP CONSTRAINT [FK_MembreActivite_Activite];
GO
IF OBJECT_ID(N'[dbo].[FK_MembreJeux]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[JeuxSet] DROP CONSTRAINT [FK_MembreJeux];
GO
IF OBJECT_ID(N'[dbo].[FK_MembreLivres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LivresSet] DROP CONSTRAINT [FK_MembreLivres];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[MembreSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MembreSet];
GO
IF OBJECT_ID(N'[dbo].[JeuxSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JeuxSet];
GO
IF OBJECT_ID(N'[dbo].[LivresSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LivresSet];
GO
IF OBJECT_ID(N'[dbo].[ActiviteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActiviteSet];
GO
IF OBJECT_ID(N'[dbo].[MembreActivite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MembreActivite];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'MembreSet'
CREATE TABLE [dbo].[Membre] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NoDossier] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'JeuxSet'
CREATE TABLE [dbo].[Jeux] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [NbrJoueur] nvarchar(max)  NOT NULL,
    [Temps] nvarchar(max)  NOT NULL,
    [MembreId] int  NOT NULL
);
GO

-- Creating table 'LivresSet'
CREATE TABLE [dbo].[Livres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [MembreId] int  NOT NULL
);
GO

-- Creating table 'ActiviteSet'
CREATE TABLE [dbo].[Activite] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [MembreInscrit] nvarchar(max)  NOT NULL,
    [NbrMembreMaximum] nvarchar(max)  NOT NULL,
    [Jour] nvarchar(max)  NOT NULL,
    [DateDebut] nvarchar(max)  NOT NULL,
    [DateFin] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MembreActivite'
CREATE TABLE [dbo].[MembreActivite] (
    [Membre_Id] int  NOT NULL,
    [Activite_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'MembreSet'
ALTER TABLE [dbo].[Membre]
ADD CONSTRAINT [PK_Membre]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JeuxSet'
ALTER TABLE [dbo].[Jeux]
ADD CONSTRAINT [PK_Jeux]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LivresSet'
ALTER TABLE [dbo].[Livres]
ADD CONSTRAINT [PK_Livres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActiviteSet'
ALTER TABLE [dbo].[Activite]
ADD CONSTRAINT [PK_Activite]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Membre_Id], [Activite_Id] in table 'MembreActivite'
ALTER TABLE [dbo].[MembreActivite]
ADD CONSTRAINT [PK_MembreActivite]
    PRIMARY KEY CLUSTERED ([Membre_Id], [Activite_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Membre_Id] in table 'MembreActivite'
ALTER TABLE [dbo].[MembreActivite]
ADD CONSTRAINT [FK_MembreActivite_Membre]
    FOREIGN KEY ([Membre_Id])
    REFERENCES [dbo].[MembreSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Activite_Id] in table 'MembreActivite'
ALTER TABLE [dbo].[MembreActivite]
ADD CONSTRAINT [FK_MembreActivite_Activite]
    FOREIGN KEY ([Activite_Id])
    REFERENCES [dbo].[ActiviteSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembreActivite_Activite'
CREATE INDEX [IX_FK_MembreActivite_Activite]
ON [dbo].[MembreActivite]
    ([Activite_Id]);
GO

-- Creating foreign key on [MembreId] in table 'JeuxSet'
ALTER TABLE [dbo].[Jeux]
ADD CONSTRAINT [FK_MembreJeux]
    FOREIGN KEY ([MembreId])
    REFERENCES [dbo].[Membre]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembreJeux'
CREATE INDEX [IX_FK_MembreJeux]
ON [dbo].[Jeux]
    ([MembreId]);
GO

-- Creating foreign key on [MembreId] in table 'LivresSet'
ALTER TABLE [dbo].[Livres]
ADD CONSTRAINT [FK_MembreLivres]
    FOREIGN KEY ([MembreId])
    REFERENCES [dbo].[Membre]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembreLivres'
CREATE INDEX [IX_FK_MembreLivres]
ON [dbo].[Livres]
    ([MembreId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------