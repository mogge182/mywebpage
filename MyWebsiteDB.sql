Create Table [User] (
[ID] uniqueidentifier not null primary key,
[Username] nvarchar(50) not null,
[Password] nvarchar(max) not null,
)

Create Table [Picture](
[ID] uniqueidentifier primary key not null,
[PictureAdress] nvarchar(max) not null
)

Create Table [Background](
[ID] uniqueidentifier not null primary key,
[UserID] uniqueidentifier not null foreign key references [User](ID),
[BackGroundAdress] nvarchar(max) not null)

Create Table [PersonalLetter](
[ID] uniqueidentifier not null primary key,
[UserID] uniqueidentifier not null foreign key references [User](ID),
[Title] nvarchar(50) not null,
[Letter] nvarchar(max) not null
)

Create Table [CV](
[ID] uniqueidentifier not null primary key,
[DateCreated] datetime not null,
[FileName] nvarchar(50) not null,
[Description] nvarchar(max) not null,
[PictureID] uniqueidentifier null foreign key references [Picture](ID)
)

Create Table [Employer](
[ID] uniqueidentifier not null primary key,
[Name] nvarchar(50) not null,
[StartDate] datetime null,
[EndDate] datetime null,
[Description] nvarchar(max) not null,
[PictureID] uniqueidentifier not null foreign key references [Picture](ID)
)

--drop table [CV]
--drop table [PersonalLetter]
--drop table [Background]
--drop table [Picture]
--drop table [User]


