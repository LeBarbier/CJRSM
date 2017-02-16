
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/15/2017 18:01:07
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

IF OBJECT_ID(N'[dbo].[FK_MembrePublication]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Publication] DROP CONSTRAINT [FK_MembrePublication];
GO
IF OBJECT_ID(N'[dbo].[FK_MembreLocationDocument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationDocument] DROP CONSTRAINT [FK_MembreLocationDocument];
GO
IF OBJECT_ID(N'[dbo].[FK_MembreLocationJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LocationJeu] DROP CONSTRAINT [FK_MembreLocationJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipantsMembre]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Participants] DROP CONSTRAINT [FK_ParticipantsMembre];
GO
IF OBJECT_ID(N'[dbo].[FK_DocumentLocationDocument]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Document] DROP CONSTRAINT [FK_DocumentLocationDocument];
GO
--IF OBJECT_ID(N'[dbo].[FK_TypesTypesJeu]', 'F') IS NOT NULL
--    ALTER TABLE [dbo].[Types] DROP CONSTRAINT [FK_TypesTypesJeu];
--GO
IF OBJECT_ID(N'[dbo].[FK_JeuTypesJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jeu] DROP CONSTRAINT [FK_JeuTypesJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_ActiviteJeuJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActiviteJeu] DROP CONSTRAINT [FK_ActiviteJeuJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_ActiviteActiviteJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActiviteJeu] DROP CONSTRAINT [FK_ActiviteActiviteJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_JeuLocationJeu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jeu] DROP CONSTRAINT [FK_JeuLocationJeu];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipantsActivite]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Participants] DROP CONSTRAINT [FK_ParticipantsActivite];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Membre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Membre];
GO
IF OBJECT_ID(N'[dbo].[Publication]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Publication];
GO
IF OBJECT_ID(N'[dbo].[LocationDocument]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationDocument];
GO
IF OBJECT_ID(N'[dbo].[Document]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Document];
GO
IF OBJECT_ID(N'[dbo].[LocationJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LocationJeu];
GO
IF OBJECT_ID(N'[dbo].[TypesJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypesJeu];
GO
IF OBJECT_ID(N'[dbo].[Types]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Types];
GO
IF OBJECT_ID(N'[dbo].[ActiviteJeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActiviteJeu];
GO
IF OBJECT_ID(N'[dbo].[Activite]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activite];
GO
IF OBJECT_ID(N'[dbo].[Participants]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Participants];
GO
IF OBJECT_ID(N'[dbo].[Jeu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jeu];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Membre'
CREATE TABLE [dbo].[Membre] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NoDossier] nvarchar(max)  NOT NULL,
    [Prenom] nvarchar(max)  NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [Role] nvarchar(max)  NOT NULL,
    [MDP] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Publication'
CREATE TABLE [dbo].[Publication] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Contenu] nvarchar(max)  NOT NULL,
    [NoDossier] nvarchar(max)  NOT NULL,
    [membre_Id] int  NOT NULL
);
GO

-- Creating table 'LocationDocument'
CREATE TABLE [dbo].[LocationDocument] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateEmprunt] datetime  NOT NULL,
    [DateRetour] datetime  NOT NULL,
    [DateEffective] datetime  NOT NULL,
    [NoDossier] nvarchar(max)  NOT NULL,
    [IdDocument] nvarchar(max)  NOT NULL,
    [membre_Id] int  NOT NULL
);
GO

-- Creating table 'Document'
CREATE TABLE [dbo].[Document] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Auteur] nvarchar(max)  NOT NULL,
    [DateAjout] datetime  NOT NULL,
    [IdLocationDocument] nvarchar(max)  NOT NULL,
    [LocationDocumentId_Id] int  NOT NULL
);
GO

-- Creating table 'LocationJeu'
CREATE TABLE [dbo].[LocationJeu] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateEmprunt] datetime  NOT NULL,
    [DateRetour] datetime  NOT NULL,
    [DateEffective] datetime  NOT NULL,
    [NoDossier] nvarchar(max)  NOT NULL,
    [IdJeu] nvarchar(max)  NOT NULL,
    [membre_Id] int  NOT NULL
);
GO

-- Creating table 'TypesJeu'
CREATE TABLE [dbo].[TypesJeu] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdTypes] nvarchar(max)  NOT NULL,
    [IdJeu] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Types'
CREATE TABLE [dbo].[Types] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nom] nvarchar(max)  NOT NULL,
    [IdTypesJeu] nvarchar(max)  NOT NULL,
    [TypesJeu_Id] int  NOT NULL
);
GO

-- Creating table 'ActiviteJeu'
CREATE TABLE [dbo].[ActiviteJeu] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdJeu] nvarchar(max)  NOT NULL,
    [IdActivite] nvarchar(max)  NOT NULL,
    [JeuId_Id] int  NOT NULL,
    [ActiviteId_Id] int  NOT NULL
);
GO

-- Creating table 'Activite'
CREATE TABLE [dbo].[Activite] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [NbrMembreMin] int  NOT NULL,
    [NbrMembreMax] int  NOT NULL,
    [Jour] int  NOT NULL,
    [HeureDebut] time  NOT NULL,
    [DateDebut] datetime  NOT NULL,
    [NbrRepetion] int  NOT NULL,
    [Accepte] bit  NOT NULL,
    [IdActiviteJeu] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Participants'
CREATE TABLE [dbo].[Participants] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NoDossier] nvarchar(max)  NOT NULL,
    [IdActivite] nvarchar(max)  NOT NULL,
    [membre_Id] int  NOT NULL,
    [Activite_Id] int  NOT NULL
);
GO

-- Creating table 'Jeu'
CREATE TABLE [dbo].[Jeu] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Titre] nvarchar(max)  NOT NULL,
    [Difficulte] int  NOT NULL,
    [NbrJoueurMin] int  NOT NULL,
    [NbrJoueurMax] int  NOT NULL,
    [TempsMin] int  NOT NULL,
    [TempsMax] int  NOT NULL,
    [DateAjout] datetime  NOT NULL,
    [IdTypesJeu] nvarchar(max)  NOT NULL,
    [IdLocationJeu] nvarchar(max)  NOT NULL,
    [TypesJeuId_Id] int  NOT NULL,
    [LocationJeuId_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Membre'
ALTER TABLE [dbo].[Membre]
ADD CONSTRAINT [PK_Membre]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Publication'
ALTER TABLE [dbo].[Publication]
ADD CONSTRAINT [PK_Publication]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationDocument'
ALTER TABLE [dbo].[LocationDocument]
ADD CONSTRAINT [PK_LocationDocument]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Document'
ALTER TABLE [dbo].[Document]
ADD CONSTRAINT [PK_Document]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationJeu'
ALTER TABLE [dbo].[LocationJeu]
ADD CONSTRAINT [PK_LocationJeu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypesJeu'
ALTER TABLE [dbo].[TypesJeu]
ADD CONSTRAINT [PK_TypesJeu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Types'
ALTER TABLE [dbo].[Types]
ADD CONSTRAINT [PK_Types]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActiviteJeu'
ALTER TABLE [dbo].[ActiviteJeu]
ADD CONSTRAINT [PK_ActiviteJeu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Activite'
ALTER TABLE [dbo].[Activite]
ADD CONSTRAINT [PK_Activite]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Participants'
ALTER TABLE [dbo].[Participants]
ADD CONSTRAINT [PK_Participants]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Jeu'
ALTER TABLE [dbo].[Jeu]
ADD CONSTRAINT [PK_Jeu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [membre_Id] in table 'Publication'
ALTER TABLE [dbo].[Publication]
ADD CONSTRAINT [FK_MembrePublication]
    FOREIGN KEY ([membre_Id])
    REFERENCES [dbo].[Membre]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembrePublication'
CREATE INDEX [IX_FK_MembrePublication]
ON [dbo].[Publication]
    ([membre_Id]);
GO

-- Creating foreign key on [membre_Id] in table 'LocationDocument'
ALTER TABLE [dbo].[LocationDocument]
ADD CONSTRAINT [FK_MembreLocationDocument]
    FOREIGN KEY ([membre_Id])
    REFERENCES [dbo].[Membre]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembreLocationDocument'
CREATE INDEX [IX_FK_MembreLocationDocument]
ON [dbo].[LocationDocument]
    ([membre_Id]);
GO

-- Creating foreign key on [membre_Id] in table 'LocationJeu'
ALTER TABLE [dbo].[LocationJeu]
ADD CONSTRAINT [FK_MembreLocationJeu]
    FOREIGN KEY ([membre_Id])
    REFERENCES [dbo].[Membre]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MembreLocationJeu'
CREATE INDEX [IX_FK_MembreLocationJeu]
ON [dbo].[LocationJeu]
    ([membre_Id]);
GO

-- Creating foreign key on [membre_Id] in table 'Participants'
ALTER TABLE [dbo].[Participants]
ADD CONSTRAINT [FK_ParticipantsMembre]
    FOREIGN KEY ([membre_Id])
    REFERENCES [dbo].[Membre]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipantsMembre'
CREATE INDEX [IX_FK_ParticipantsMembre]
ON [dbo].[Participants]
    ([membre_Id]);
GO

-- Creating foreign key on [LocationDocumentId_Id] in table 'Document'
ALTER TABLE [dbo].[Document]
ADD CONSTRAINT [FK_DocumentLocationDocument]
    FOREIGN KEY ([LocationDocumentId_Id])
    REFERENCES [dbo].[LocationDocument]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DocumentLocationDocument'
CREATE INDEX [IX_FK_DocumentLocationDocument]
ON [dbo].[Document]
    ([LocationDocumentId_Id]);
GO

-- Creating foreign key on [TypesJeu_Id] in table 'Types'
--ALTER TABLE [dbo].[Types]
--ADD CONSTRAINT [FK_TypesTypesJeu]
--    FOREIGN KEY ([TypesJeu_Id])
--    REFERENCES [dbo].[TypesJeu]
--        ([Id])
--    ON DELETE NO ACTION ON UPDATE NO ACTION;
--GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TypesTypesJeu'
CREATE INDEX [IX_FK_TypesTypesJeu]
ON [dbo].[Types]
    ([TypesJeu_Id]);
GO

-- Creating foreign key on [TypesJeuId_Id] in table 'Jeu'
ALTER TABLE [dbo].[Jeu]
ADD CONSTRAINT [FK_JeuTypesJeu]
    FOREIGN KEY ([TypesJeuId_Id])
    REFERENCES [dbo].[TypesJeu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JeuTypesJeu'
CREATE INDEX [IX_FK_JeuTypesJeu]
ON [dbo].[Jeu]
    ([TypesJeuId_Id]);
GO

-- Creating foreign key on [JeuId_Id] in table 'ActiviteJeu'
ALTER TABLE [dbo].[ActiviteJeu]
ADD CONSTRAINT [FK_ActiviteJeuJeu]
    FOREIGN KEY ([JeuId_Id])
    REFERENCES [dbo].[Jeu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActiviteJeuJeu'
CREATE INDEX [IX_FK_ActiviteJeuJeu]
ON [dbo].[ActiviteJeu]
    ([JeuId_Id]);
GO

-- Creating foreign key on [ActiviteId_Id] in table 'ActiviteJeu'
ALTER TABLE [dbo].[ActiviteJeu]
ADD CONSTRAINT [FK_ActiviteActiviteJeu]
    FOREIGN KEY ([ActiviteId_Id])
    REFERENCES [dbo].[Activite]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActiviteActiviteJeu'
CREATE INDEX [IX_FK_ActiviteActiviteJeu]
ON [dbo].[ActiviteJeu]
    ([ActiviteId_Id]);
GO

-- Creating foreign key on [LocationJeuId_Id] in table 'Jeu'
ALTER TABLE [dbo].[Jeu]
ADD CONSTRAINT [FK_JeuLocationJeu]
    FOREIGN KEY ([LocationJeuId_Id])
    REFERENCES [dbo].[LocationJeu]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JeuLocationJeu'
CREATE INDEX [IX_FK_JeuLocationJeu]
ON [dbo].[Jeu]
    ([LocationJeuId_Id]);
GO

-- Creating foreign key on [Activite_Id] in table 'Participants'
ALTER TABLE [dbo].[Participants]
ADD CONSTRAINT [FK_ParticipantsActivite]
    FOREIGN KEY ([Activite_Id])
    REFERENCES [dbo].[Activite]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipantsActivite'
CREATE INDEX [IX_FK_ParticipantsActivite]
ON [dbo].[Participants]
    ([Activite_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------