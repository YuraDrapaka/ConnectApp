CREATE TABLE [dbo].[Messages] (
    [Ms_Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Time]            ROWVERSION     NOT NULL,
    [Text]            TEXT           NOT NULL,
    [From_UserID_FK]  NVARCHAR (450) NOT NULL,
    [To_UserID_FK]    NVARCHAR (450) NULL,
    [MediaID_FK]      INT            NOT NULL,
    [IsEdited?]       BIT            NOT NULL,
    [IsViewed?]       BIT            NOT NULL,
    [IsDeleted?]      BIT            NOT NULL,
    [IsForwarded?]    BIT            NOT NULL,
    [OldMessageID_FK] INT            NULL,
    CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED ([Ms_Id] ASC),
    CONSTRAINT [FK_Messages_FromUserID] FOREIGN KEY ([From_UserID_FK]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Messages_Media] FOREIGN KEY ([MediaID_FK]) REFERENCES [dbo].[Medias] ([Md_Id]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_Messages_OldMessageID] FOREIGN KEY ([OldMessageID_FK]) REFERENCES [dbo].[Messages] ([Ms_Id]),
    CONSTRAINT [FK_Messages_ToUserID] FOREIGN KEY ([To_UserID_FK]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

