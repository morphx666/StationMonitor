
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/07/2018 10:32:22
-- Generated from EDMX file: D:\Projects\StationMonitor\FPDataManager\FPDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [fpdata];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Advertisers_Cities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Advertisers] DROP CONSTRAINT [FK_Advertisers_Cities];
GO
IF OBJECT_ID(N'[dbo].[FK_CepstralCoefficients_Tracks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CepstralCoefficients] DROP CONSTRAINT [FK_CepstralCoefficients_Tracks];
GO
IF OBJECT_ID(N'[dbo].[FK_Clientes_Ciudades]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Clients] DROP CONSTRAINT [FK_Clientes_Ciudades];
GO
IF OBJECT_ID(N'[dbo].[FK_Fingerprints_Tracks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fingerprints] DROP CONSTRAINT [FK_Fingerprints_Tracks];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayedTracks_Stations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayedTracks] DROP CONSTRAINT [FK_PlayedTracks_Stations];
GO
IF OBJECT_ID(N'[dbo].[FK_PlayedTracks_Tracks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlayedTracks] DROP CONSTRAINT [FK_PlayedTracks_Tracks];
GO
IF OBJECT_ID(N'[dbo].[FK_Stations_Cities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stations] DROP CONSTRAINT [FK_Stations_Cities];
GO
IF OBJECT_ID(N'[dbo].[FK_SubFingerprints_Tracks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubFingerprints] DROP CONSTRAINT [FK_SubFingerprints_Tracks];
GO
IF OBJECT_ID(N'[dbo].[FK_tmpPlayedTracks_Stations]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tmpPlayedTracks] DROP CONSTRAINT [FK_tmpPlayedTracks_Stations];
GO
IF OBJECT_ID(N'[dbo].[FK_tmpPlayedTracks_TracksHashes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[tmpPlayedTracks] DROP CONSTRAINT [FK_tmpPlayedTracks_TracksHashes];
GO
IF OBJECT_ID(N'[dbo].[FK_Tracks_Albums]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tracks] DROP CONSTRAINT [FK_Tracks_Albums];
GO
IF OBJECT_ID(N'[dbo].[FK_Tracks_Artists]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tracks] DROP CONSTRAINT [FK_Tracks_Artists];
GO
IF OBJECT_ID(N'[dbo].[FK_Tracks_Genres]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tracks] DROP CONSTRAINT [FK_Tracks_Genres];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Advertisers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Advertisers];
GO
IF OBJECT_ID(N'[dbo].[Albums]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Albums];
GO
IF OBJECT_ID(N'[dbo].[Artists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Artists];
GO
IF OBJECT_ID(N'[dbo].[CepstralCoefficients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CepstralCoefficients];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[Clients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clients];
GO
IF OBJECT_ID(N'[dbo].[configs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[configs];
GO
IF OBJECT_ID(N'[dbo].[Fingerprints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fingerprints];
GO
IF OBJECT_ID(N'[dbo].[Genres]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genres];
GO
IF OBJECT_ID(N'[dbo].[PlayedTracks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlayedTracks];
GO
IF OBJECT_ID(N'[dbo].[RecordsSeals]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecordsSeals];
GO
IF OBJECT_ID(N'[dbo].[Stations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stations];
GO
IF OBJECT_ID(N'[dbo].[SubFingerprints]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubFingerprints];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[tmpPlayedTracks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[tmpPlayedTracks];
GO
IF OBJECT_ID(N'[dbo].[Tracks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tracks];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Advertisers'
CREATE TABLE [dbo].[Advertisers] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(75)  NOT NULL,
    [Contract] varchar(50)  NULL,
    [Address] varchar(200)  NULL,
    [CityID] int  NOT NULL,
    [Phones] varchar(100)  NULL
);
GO

-- Creating table 'Albums'
CREATE TABLE [dbo].[Albums] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Year] int  NULL,
    [SealID] int  NULL
);
GO

-- Creating table 'Artists'
CREATE TABLE [dbo].[Artists] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(100)  NOT NULL
);
GO

-- Creating table 'CepstralCoefficients'
CREATE TABLE [dbo].[CepstralCoefficients] (
    [id] int IDENTITY(1,1) NOT NULL,
    [c1] float  NOT NULL,
    [c2] float  NOT NULL,
    [c3] float  NOT NULL,
    [c4] float  NOT NULL,
    [c5] float  NOT NULL,
    [c6] float  NOT NULL,
    [c7] float  NOT NULL,
    [c8] float  NOT NULL,
    [c9] float  NOT NULL,
    [c10] float  NOT NULL,
    [c11] float  NOT NULL,
    [c12] float  NOT NULL,
    [TrackID] int  NOT NULL,
    [Position] float  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [ID] int  NOT NULL,
    [Name] varchar(100)  NOT NULL,
    [Contract] varchar(50)  NULL,
    [Address] varchar(200)  NULL,
    [CityID] int  NOT NULL,
    [Phones] varchar(100)  NULL,
    [Type] tinyint  NOT NULL,
    [PublisherID] int  NULL
);
GO

-- Creating table 'Fingerprints'
CREATE TABLE [dbo].[Fingerprints] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Hash] int  NULL,
    [TrackID] int  NOT NULL,
    [Position] float  NOT NULL
);
GO

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'PlayedTracks'
CREATE TABLE [dbo].[PlayedTracks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [TrackID] int  NOT NULL,
    [StationID] int  NOT NULL
);
GO

-- Creating table 'RecordsSeals'
CREATE TABLE [dbo].[RecordsSeals] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Type] tinyint  NOT NULL
);
GO

-- Creating table 'Stations'
CREATE TABLE [dbo].[Stations] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(50)  NOT NULL,
    [Frequency] varchar(50)  NOT NULL,
    [CityID] int  NOT NULL,
    [Type] tinyint  NOT NULL,
    [SamplingTime] int  NOT NULL,
    [RecordingDevice] nchar(36)  NOT NULL,
    [SourceLine] int  NOT NULL,
    [ChannelMode] int  NOT NULL,
    [LeftChMute] int  NOT NULL,
    [RightChMute] int  NOT NULL
);
GO

-- Creating table 'SubFingerprints'
CREATE TABLE [dbo].[SubFingerprints] (
    [id] int IDENTITY(1,1) NOT NULL,
    [Hash] int  NULL,
    [TrackID] int  NOT NULL,
    [Position] float  NOT NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'tmpPlayedTracks'
CREATE TABLE [dbo].[tmpPlayedTracks] (
    [id] int IDENTITY(1,1) NOT NULL,
    [StartTime] datetime  NOT NULL,
    [EndTime] datetime  NOT NULL,
    [TrackID] int  NULL,
    [StationID] int  NOT NULL,
    [Score] float  NOT NULL,
    [Duration] int  NOT NULL
);
GO

-- Creating table 'Tracks'
CREATE TABLE [dbo].[Tracks] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [MediaType] tinyint  NOT NULL,
    [Title] varchar(200)  NOT NULL,
    [Year] int  NOT NULL,
    [ArtistID] int  NOT NULL,
    [AlbumID] int  NOT NULL,
    [GenreID] int  NOT NULL,
    [SealID] int  NULL,
    [ClientID] int  NULL,
    [Campaign] varchar(100)  NULL,
    [Version] varchar(75)  NULL,
    [FileName] varchar(max)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int  NOT NULL,
    [Name] varchar(15)  NOT NULL,
    [Password] varchar(20)  NOT NULL,
    [Priority] int  NOT NULL
);
GO

-- Creating table 'configs'
CREATE TABLE [dbo].[configs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fingerPrintsDirectory] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Advertisers'
ALTER TABLE [dbo].[Advertisers]
ADD CONSTRAINT [PK_Advertisers]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [PK_Albums]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Artists'
ALTER TABLE [dbo].[Artists]
ADD CONSTRAINT [PK_Artists]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'CepstralCoefficients'
ALTER TABLE [dbo].[CepstralCoefficients]
ADD CONSTRAINT [PK_CepstralCoefficients]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Fingerprints'
ALTER TABLE [dbo].[Fingerprints]
ADD CONSTRAINT [PK_Fingerprints]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [PK_Genres]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'PlayedTracks'
ALTER TABLE [dbo].[PlayedTracks]
ADD CONSTRAINT [PK_PlayedTracks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RecordsSeals'
ALTER TABLE [dbo].[RecordsSeals]
ADD CONSTRAINT [PK_RecordsSeals]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Stations'
ALTER TABLE [dbo].[Stations]
ADD CONSTRAINT [PK_Stations]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [id] in table 'SubFingerprints'
ALTER TABLE [dbo].[SubFingerprints]
ADD CONSTRAINT [PK_SubFingerprints]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'tmpPlayedTracks'
ALTER TABLE [dbo].[tmpPlayedTracks]
ADD CONSTRAINT [PK_tmpPlayedTracks]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [ID] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [PK_Tracks]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [id] in table 'configs'
ALTER TABLE [dbo].[configs]
ADD CONSTRAINT [PK_configs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CityID] in table 'Advertisers'
ALTER TABLE [dbo].[Advertisers]
ADD CONSTRAINT [FK_Advertisers_Cities]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Cities]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Advertisers_Cities'
CREATE INDEX [IX_FK_Advertisers_Cities]
ON [dbo].[Advertisers]
    ([CityID]);
GO

-- Creating foreign key on [AlbumID] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [FK_Tracks_Albums]
    FOREIGN KEY ([AlbumID])
    REFERENCES [dbo].[Albums]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tracks_Albums'
CREATE INDEX [IX_FK_Tracks_Albums]
ON [dbo].[Tracks]
    ([AlbumID]);
GO

-- Creating foreign key on [ArtistID] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [FK_Tracks_Artists]
    FOREIGN KEY ([ArtistID])
    REFERENCES [dbo].[Artists]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tracks_Artists'
CREATE INDEX [IX_FK_Tracks_Artists]
ON [dbo].[Tracks]
    ([ArtistID]);
GO

-- Creating foreign key on [TrackID] in table 'CepstralCoefficients'
ALTER TABLE [dbo].[CepstralCoefficients]
ADD CONSTRAINT [FK_CepstralCoefficients_Tracks]
    FOREIGN KEY ([TrackID])
    REFERENCES [dbo].[Tracks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CepstralCoefficients_Tracks'
CREATE INDEX [IX_FK_CepstralCoefficients_Tracks]
ON [dbo].[CepstralCoefficients]
    ([TrackID]);
GO

-- Creating foreign key on [CityID] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [FK_Clientes_Ciudades]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Cities]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Clientes_Ciudades'
CREATE INDEX [IX_FK_Clientes_Ciudades]
ON [dbo].[Clients]
    ([CityID]);
GO

-- Creating foreign key on [CityID] in table 'Stations'
ALTER TABLE [dbo].[Stations]
ADD CONSTRAINT [FK_Stations_Cities]
    FOREIGN KEY ([CityID])
    REFERENCES [dbo].[Cities]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Stations_Cities'
CREATE INDEX [IX_FK_Stations_Cities]
ON [dbo].[Stations]
    ([CityID]);
GO

-- Creating foreign key on [TrackID] in table 'Fingerprints'
ALTER TABLE [dbo].[Fingerprints]
ADD CONSTRAINT [FK_Fingerprints_Tracks]
    FOREIGN KEY ([TrackID])
    REFERENCES [dbo].[Tracks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Fingerprints_Tracks'
CREATE INDEX [IX_FK_Fingerprints_Tracks]
ON [dbo].[Fingerprints]
    ([TrackID]);
GO

-- Creating foreign key on [GenreID] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [FK_Tracks_Genres]
    FOREIGN KEY ([GenreID])
    REFERENCES [dbo].[Genres]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Tracks_Genres'
CREATE INDEX [IX_FK_Tracks_Genres]
ON [dbo].[Tracks]
    ([GenreID]);
GO

-- Creating foreign key on [StationID] in table 'PlayedTracks'
ALTER TABLE [dbo].[PlayedTracks]
ADD CONSTRAINT [FK_PlayedTracks_Stations]
    FOREIGN KEY ([StationID])
    REFERENCES [dbo].[Stations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayedTracks_Stations'
CREATE INDEX [IX_FK_PlayedTracks_Stations]
ON [dbo].[PlayedTracks]
    ([StationID]);
GO

-- Creating foreign key on [TrackID] in table 'PlayedTracks'
ALTER TABLE [dbo].[PlayedTracks]
ADD CONSTRAINT [FK_PlayedTracks_Tracks]
    FOREIGN KEY ([TrackID])
    REFERENCES [dbo].[Tracks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlayedTracks_Tracks'
CREATE INDEX [IX_FK_PlayedTracks_Tracks]
ON [dbo].[PlayedTracks]
    ([TrackID]);
GO

-- Creating foreign key on [StationID] in table 'tmpPlayedTracks'
ALTER TABLE [dbo].[tmpPlayedTracks]
ADD CONSTRAINT [FK_tmpPlayedTracks_Stations]
    FOREIGN KEY ([StationID])
    REFERENCES [dbo].[Stations]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tmpPlayedTracks_Stations'
CREATE INDEX [IX_FK_tmpPlayedTracks_Stations]
ON [dbo].[tmpPlayedTracks]
    ([StationID]);
GO

-- Creating foreign key on [TrackID] in table 'SubFingerprints'
ALTER TABLE [dbo].[SubFingerprints]
ADD CONSTRAINT [FK_SubFingerprints_Tracks]
    FOREIGN KEY ([TrackID])
    REFERENCES [dbo].[Tracks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubFingerprints_Tracks'
CREATE INDEX [IX_FK_SubFingerprints_Tracks]
ON [dbo].[SubFingerprints]
    ([TrackID]);
GO

-- Creating foreign key on [TrackID] in table 'tmpPlayedTracks'
ALTER TABLE [dbo].[tmpPlayedTracks]
ADD CONSTRAINT [FK_tmpPlayedTracks_TracksHashes]
    FOREIGN KEY ([TrackID])
    REFERENCES [dbo].[Tracks]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_tmpPlayedTracks_TracksHashes'
CREATE INDEX [IX_FK_tmpPlayedTracks_TracksHashes]
ON [dbo].[tmpPlayedTracks]
    ([TrackID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------