CREATE TABLE [dbo].[Users_Chats_RELATION] (
    [Users_Chats_Relation_ID] INT            IDENTITY (1, 1) NOT NULL,
    [UserID_FK]               NVARCHAR (450) NOT NULL,
    [ChatID_FK]               INT            NOT NULL,
    CONSTRAINT [PK_UserID_ChatID_REL] PRIMARY KEY CLUSTERED ([Users_Chats_Relation_ID] ASC),
    CONSTRAINT [FK_Users_Chats_ChatID] FOREIGN KEY ([ChatID_FK]) REFERENCES [dbo].[Chats] ([Chat_Id]),
    CONSTRAINT [FK_Users_Chats_UserID] FOREIGN KEY ([UserID_FK]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

