CREATE TABLE [dbo].[StoredEvent] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [CreationDate] DATETIME         NULL,
    [Data]         NTEXT            NULL,
    [User]         VARCHAR (100)    NULL,
    [Action]       VARCHAR (100)    NULL,
    [MessageType]  VARCHAR (100)    NULL,
    [AggregateId]  UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_StoredEvent] PRIMARY KEY CLUSTERED ([Id] ASC)
);

