CREATE TABLE [dbo].[Medias] (
    [Md_Id]       INT            IDENTITY (1, 1) NOT NULL,
    [URL]         TEXT           NOT NULL,
    [Size]        FLOAT (53)     NOT NULL,
    [UploadTime]  DATETIME     NOT NULL,
    [AuthorId_FK] NVARCHAR (450) NULL,
    CONSTRAINT [PK_Medias] PRIMARY KEY CLUSTERED ([Md_Id] ASC),
    CONSTRAINT [FK_Medias_Author] FOREIGN KEY ([AuthorId_FK]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

