CREATE TABLE [dbo].[Users_Contacts_RELATION] (
    [User_Countact_relationID] NVARCHAR (450) NOT NULL,
    [UserID_FK]                NVARCHAR (450) NOT NULL,
    [Contact_FK]               NVARCHAR (450) NOT NULL,
    CONSTRAINT [PK_Users_Contacts_RELATION] PRIMARY KEY CLUSTERED ([User_Countact_relationID] ASC),
    CONSTRAINT [FK_UserID_Contacts-Contact] FOREIGN KEY ([Contact_FK]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_UserID_Contacts-UserID] FOREIGN KEY ([UserID_FK]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

