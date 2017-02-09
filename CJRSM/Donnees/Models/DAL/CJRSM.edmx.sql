
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/05/2017 11:44:33
-- Generated from EDMX file: L:\CJRSM\CJRSM\Donnees\Models\DAL\CJRSM.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [D75E5];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MembreActivite_Membres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MembreActivite] DROP CONSTRAINT [FK_MembreActivite_Membres];
GO
IF OBJECT_ID(N'[dbo].[FK_MembreActivite_Activites]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MembreActivite] DROP CONSTRAINT [FK_MembreActivite_Activites];
GO
IF OBJECT_ID(N'[dbo].[FK_MembreJeux]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jeux] DROP CONSTRAINT [FK_MembreJeux];
GO
IF OBJECT_ID(N'[dbo].[FK_MembreLivres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Documents] DROP CONSTRAINT [FK_MembreLivres];
GO
IF OBJECT_ID(N'[dbo].[FK_PublicationMembre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publications] DROP CONSTRAINT [FK_PublicationMembre];
GO
IF OBJECT_ID(N'[dbo].[FK_TypeJeux_Types]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TypeJeux] DROP CONSTRAINT [FK_TypeJeux_Types];
GO
IF OBJECT_ID(N'[dbo].[FK_TypeJeux_Jeux]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TypeJeux] DROP CONSTRAINT [FK_TypeJeux_Jeux];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Membres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Membres];
GO
IF OBJECT_ID(N'[dbo].[Jeux]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jeux];
GO
IF OBJECT_ID(N'[dbo].[Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Documents];
GO
IF OBJECT_ID(N'[dbo].[Activites]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activites];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[Publications]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publications];
GO
IF OBJECT_ID(N'[dbo].[MembreActivite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MembreActivite];
GO
IF OBJECT_ID(N'[dbo].[TypeJeux]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeJeux];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Membres'
CREATE TABLE [dbo].[Membres] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NoDossier] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max),
    [Nom] nvarchar(max),
    [Role] nvarchar(max),
    [MDP] nvarchar(max)
);
GO

-- Creating table 'Jeux'
CREATE TABLE [dbo].[Jeux] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Difficulte] int  NOT NULL,
    [NbrJoueurMin] int  NOT NULL,
    [NbrJoueurMax] int  NOT NULL,
    [TempsMin] int  NOT NULL,
    [TempsMax] int  NOT NULL,
    [Disponible] bit  NOT NULL,
    [MembreId] int,
    [DateAjout] date,
    [Membre_Id] int
);
GO

-- Creating table 'Documents'
CREATE TABLE [dbo].[Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Auteur] nvarchar(max)  NOT NULL,
    [Disponible] bit  NOT NULL,
    [DateAjout] datetime  NOT NULL,
    [MembreId] int
);
GO

-- Creating table 'Activites'
CREATE TABLE [dbo].[Activites] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MembreId] nvarchar(max)  NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Jeu] nvarchar(max),
    [Description] nvarchar(max)  NOT NULL,
    [NbrMembreMin] int,
    [NbrMembreMax] int,
    [Jour] int  NOT NULL,
    [HeureDebut] time  NOT NULL,
    [Hebdomadaire] bit  NOT NULL,
    [DateDebut] datetime  NOT NULL,
    [NbrRepetition] int  NOT NULL,
    [Accepte] bit  NOT NULL,
    [Participant] nvarchar(max)
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int  NOT NULL,
    [Etiquette] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Publications'
CREATE TABLE [dbo].[Publications] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [MembreId] nvarchar(max)  NOT NULL,
    [Contenu] nvarchar(max)  NOT NULL,
    [Membre_Id] int  NOT NULL
);
GO

-- Creating table 'MembreActivite'
CREATE TABLE [dbo].[MembreActivite] (
    [Membre_Id] int  NOT NULL,
    [Activite_Id] int  NOT NULL
);
GO

-- Creating table 'TypeJeux'
CREATE TABLE [dbo].[TypeJeux] (
    [Type_Id] int  NOT NULL,
    [Jeux_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Membres'
ALTER TABLE [dbo].[Membres]
ADD CONSTRAINT [PK_Membres]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Jeux'
ALTER TABLE [dbo].[Jeux]
ADD CONSTRAINT [PK_Jeux]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [PK_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Activites'
ALTER TABLE [dbo].[Activites]
ADD CONSTRAINT [PK_Activites]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publications'
ALTER TABLE [dbo].[Publications]
ADD CONSTRAINT [PK_Publications]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Membre_Id], [Activite_Id] in table 'MembreActivite'
ALTER TABLE [dbo].[MembreActivite]
ADD CONSTRAINT [PK_MembreActivite]
    PRIMARY KEY CLUSTERED ([Membre_Id], [Activite_Id] ASC);
GO

-- Creating primary key on [Type_Id], [Jeux_Id] in table 'TypeJeux'
ALTER TABLE [dbo].[TypeJeux]
ADD CONSTRAINT [PK_TypeJeux]
    PRIMARY KEY CLUSTERED ([Type_Id], [Jeux_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Membre_Id] in table 'MembreActivite'
ALTER TABLE [dbo].[MembreActivite]
ADD CONSTRAINT [FK_MembreActivite_Membres]
    FOREIGN KEY ([Membre_Id])
    REFERENCES [dbo].[Membres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Activite_Id] in table 'MembreActivite'
ALTER TABLE [dbo].[MembreActivite]
ADD CONSTRAINT [FK_MembreActivite_Activites]
    FOREIGN KEY ([Activite_Id])
    REFERENCES [dbo].[Activites]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembreActivite_Activites'
CREATE INDEX [IX_FK_MembreActivite_Activites]
ON [dbo].[MembreActivite]
    ([Activite_Id]);
GO

-- Creating foreign key on [Membre_Id] in table 'Jeux'
ALTER TABLE [dbo].[Jeux]
ADD CONSTRAINT [FK_MembreJeux]
    FOREIGN KEY ([Membre_Id])
    REFERENCES [dbo].[Membres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembreJeux'
CREATE INDEX [IX_FK_MembreJeux]
ON [dbo].[Jeux]
    ([Membre_Id]);
GO

-- Creating foreign key on [MembreId] in table 'Documents'
ALTER TABLE [dbo].[Documents]
ADD CONSTRAINT [FK_MembreLivres]
    FOREIGN KEY ([MembreId])
    REFERENCES [dbo].[Membres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembreLivres'
CREATE INDEX [IX_FK_MembreLivres]
ON [dbo].[Documents]
    ([MembreId]);
GO

-- Creating foreign key on [Membre_Id] in table 'Publications'
ALTER TABLE [dbo].[Publications]
ADD CONSTRAINT [FK_PublicationMembre]
    FOREIGN KEY ([Membre_Id])
    REFERENCES [dbo].[Membres]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicationMembre'
CREATE INDEX [IX_FK_PublicationMembre]
ON [dbo].[Publications]
    ([Membre_Id]);
GO

-- Creating foreign key on [Type_Id] in table 'TypeJeux'
ALTER TABLE [dbo].[TypeJeux]
ADD CONSTRAINT [FK_TypeJeux_Types]
    FOREIGN KEY ([Type_Id])
    REFERENCES [dbo].[Types]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Jeux_Id] in table 'TypeJeux'
ALTER TABLE [dbo].[TypeJeux]
ADD CONSTRAINT [FK_TypeJeux_Jeux]
    FOREIGN KEY ([Jeux_Id])
    REFERENCES [dbo].[Jeux]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypeJeux_Jeux'
CREATE INDEX [IX_FK_TypeJeux_Jeux]
ON [dbo].[TypeJeux]
    ([Jeux_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------