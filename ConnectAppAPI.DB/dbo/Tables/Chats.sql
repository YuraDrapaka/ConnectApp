CREATE TABLE [dbo].[Chats] (
    [Chat_Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Description]   VARCHAR (100) NULL,
    [Creation_Time] ROWVERSION    NOT NULL,
    [Icon]          VARCHAR (100) NULL,
    [IsChannel?]    BIT           NOT NULL,
    CONSTRAINT [PK_Chats] PRIMARY KEY CLUSTERED ([Chat_Id] ASC)
);

