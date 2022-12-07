CREATE TABLE [dbo].[Users] (
    [Id]       INT          NOT NULL IDENTITY(1,1),
    [UserName] VARCHAR (20) NOT NULL,
    [Password] VARCHAR (15) NOT NULL,
    [Role]     INT          NOT NULL,
    [State]    INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Purchases] (
    [Id]            INT          NOT NULL IDENTITY(1,1),
    [Date]          DATETIME     NOT NULL,
    [PurchaseState] INT          NOT NULL,
    [Value]         DECIMAL (18) NOT NULL,
    [State]         INT          NOT NULL,
    [IdUser]        INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdUser]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[Categories] (
    [Id]    INT          NOT NULL IDENTITY(1,1),
    [Name]  VARCHAR (50) NULL,
    [State] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Products] (
    [Id]         INT           NOT NULL IDENTITY(1,1),
    [Name]       VARCHAR (50)  NOT NULL,
    [Image]      VARCHAR (100) NOT NULL,
    [Category]   VARCHAR (250) NOT NULL,
    [Value]      DECIMAL (18)  NOT NULL,
    [State]      INT           NOT NULL,
    [IdCategory] INT     
	FOREIGN KEY ([IdCategory]) REFERENCES [dbo].[Categories] ([Id])NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
CREATE TABLE [dbo].[PurchaseDetails] (
    [Id]          INT          NOT NULL IDENTITY(1,1),
    [Amount]      INT          NULL,
    [Value]       DECIMAL (18) NULL,
    [State]       INT          NULL,
    [IdPurchases] INT          NULL,
    [IdProduct]   INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([IdPurchases]) REFERENCES [dbo].[Purchases] ([Id]),
    FOREIGN KEY ([IdProduct]) REFERENCES [dbo].[Products] ([Id])
);

INSERT INTO Users (UserName, Password, State, Role) Values ('Hoal', 'holas', 1, 1)

