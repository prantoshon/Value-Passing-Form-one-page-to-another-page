USE [PPL]
GO
/****** Object:  Table [dbo].[CoronaInfo]    Script Date: 6/2/2020 9:06:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CoronaInfo](
	[Dept] [nvarchar](50) NULL,
	[pin] [nvarchar](50) NULL,
	[Name] [nvarchar](max) NULL,
	[PresentAddress] [nvarchar](max) NULL,
	[HouseType] [nvarchar](50) NULL,
	[Coronasymptom] [nchar](10) NULL,
	[CoronasymptomDetails] [nvarchar](max) NULL,
	[WaytoComeOffice] [nvarchar](max) NULL,
	[comment1] [nvarchar](max) NULL,
	[Date] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
