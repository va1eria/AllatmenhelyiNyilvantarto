CREATE TABLE [dbo].[Allat] (
    [Nev]               VARCHAR (64)   NOT NULL,
    [Chipszam]          VARCHAR (16)   NULL,
    [Leiras]            VARCHAR (1000) NULL,
    [Szor]              INT            NOT NULL,
    [Nem]               INT            NOT NULL,
    [Suly]              FLOAT (53)     NULL,
    [SzuletesiDatum]    DATE           NULL,
    [BekerulesiDatum]   DATE           NOT NULL,
    [Ivartalanitott]    BIT            NULL,
    [MacskavalTarthato] BIT            NULL,
    [KutyavalTarthato]  BIT            NULL,
    [GyerekkelTarthato] BIT            NULL,
    [Gazdas]            BIT            NULL,
    [GondozoID]         INT            NULL
)
