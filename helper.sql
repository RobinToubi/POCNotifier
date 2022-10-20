-- Update des settings de la BDD permettant d'activer le service broker

ALTER DATABASE POCNotifier SET SINGLE_USER WITH ROLLBACK IMMEDIATE
ALTER DATABASE POCNotifier SET ENABLE_BROKER; 
ALTER DATABASE POCNotifier SET MULTI_USER WITH ROLLBACK IMMEDIATE

-- Création d'un utilisateur qui va utiliser l'application
USE POCNotifier

CREATE USER foresight FOR LOGIN [DESKTOP-OIQ1J8I\robin]
WITH DEFAULT_SCHEMA=[dbo]


GRANT ALTER to foresight
GRANT CONNECT to foresight
GRANT CONTROL to foresight
GRANT CREATE CONTRACT to foresight
GRANT CREATE MESSAGE TYPE to foresight
GRANT CREATE PROCEDURE to foresight
GRANT CREATE QUEUE to foresight
GRANT CREATE SERVICE to foresight
GRANT EXECUTE to foresight
GRANT SELECT to foresight
GRANT SUBSCRIBE QUERY NOTIFICATIONS to foresight
GRANT VIEW DATABASE STATE to foresight
GRANT VIEW DEFINITION to foresight

CREATE TABLE [dbo].[Incident] (
    [Id]             INT        NOT NULL,
    [Label]          VARCHAR(MAX)       NULL,
    [Categorie]      NCHAR (10) NULL,
    [Priorite]       NCHAR (10) NULL,
    [Description]    VARCHAR(MAX)       NULL,
    [AffectedPerson] INT        NULL,
    [Product]        INT        NULL,
    [WaitingList]    SMALLINT   NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);