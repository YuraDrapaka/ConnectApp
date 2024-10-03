CREATE TABLE [dbo].[Chats_Messages_RELATION] (
    [ChatID_FK]    INT NOT NULL,
    [MessageID_FK] INT NOT NULL,
    CONSTRAINT [PK_ChatID_MessageID] PRIMARY KEY CLUSTERED ([ChatID_FK] ASC, [MessageID_FK] ASC),
    CONSTRAINT [FK_Chats_Messages_ChatID] FOREIGN KEY ([ChatID_FK]) REFERENCES [dbo].[Chats] ([Chat_Id]),
    CONSTRAINT [FK_Chats_Messages_MessageID] FOREIGN KEY ([MessageID_FK]) REFERENCES [dbo].[Messages] ([Ms_Id])
);

