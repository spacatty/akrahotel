USE [AkraHotel]
GO
/****** Object:  Table [dbo].[Bill]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](50) NULL,
	[Employee] [int] NOT NULL,
	[Amount] [varchar](50) NULL,
	[Date] [datetime] NULL,
 CONSTRAINT [PK_Bill] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillCompany]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillCompany](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Company] [int] NULL,
	[Bill] [int] NULL,
 CONSTRAINT [PK_BillCompany] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillGuest]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillGuest](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bill] [int] NOT NULL,
	[Guest] [int] NOT NULL,
 CONSTRAINT [PK_BillGuest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BillService]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BillService](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Bill] [int] NOT NULL,
	[Service] [int] NOT NULL,
 CONSTRAINT [PK_BillService] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Director] [varchar](50) NULL,
	[Details] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Complain]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complain](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](max) NULL,
	[Guest] [int] NULL,
	[Employee] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [varchar](50) NULL,
	[Employee] [int] NULL,
	[Company] [int] NULL,
	[Date] [datetime] NULL,
	[Discount] [varchar](50) NULL,
 CONSTRAINT [PK_Contract] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Post] [varchar](50) NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Salary] [varchar](50) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Guest]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Guest](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Passport] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
 CONSTRAINT [PK_Guest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Stars] [int] NULL,
	[Rooms] [int] NULL,
	[AvailableServices] [varchar](50) NULL,
	[Catering] [varchar](50) NULL,
	[Entertainments] [varchar](50) NULL,
	[RoomsOnFloors] [varchar](50) NULL,
	[Floors] [int] NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Room]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Room](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Class] [varchar](50) NULL,
	[Capacity] [int] NULL,
	[Floor] [int] NULL,
	[Rooms] [int] NULL,
	[Price] [varchar](50) NULL,
	[Status] [varchar](50) NULL,
	[BuildingRoom] [int] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomBill]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomBill](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Room] [int] NOT NULL,
	[Bill] [int] NOT NULL,
 CONSTRAINT [PK_RoomBill] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Service]    Script Date: 20.02.2023 21:33:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Service](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Amount] [varchar](50) NULL,
	[Type] [varchar](50) NULL,
 CONSTRAINT [PK_Service] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Bill]  WITH CHECK ADD  CONSTRAINT [FK_Bill_Employee] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Bill] CHECK CONSTRAINT [FK_Bill_Employee]
GO
ALTER TABLE [dbo].[BillCompany]  WITH CHECK ADD  CONSTRAINT [FK_BillCompany_Bill] FOREIGN KEY([Bill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillCompany] CHECK CONSTRAINT [FK_BillCompany_Bill]
GO
ALTER TABLE [dbo].[BillCompany]  WITH CHECK ADD  CONSTRAINT [FK_BillCompany_Company] FOREIGN KEY([Company])
REFERENCES [dbo].[Company] ([id])
GO
ALTER TABLE [dbo].[BillCompany] CHECK CONSTRAINT [FK_BillCompany_Company]
GO
ALTER TABLE [dbo].[BillGuest]  WITH CHECK ADD  CONSTRAINT [FK_BillGuest_Bill] FOREIGN KEY([Bill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillGuest] CHECK CONSTRAINT [FK_BillGuest_Bill]
GO
ALTER TABLE [dbo].[BillGuest]  WITH CHECK ADD  CONSTRAINT [FK_BillGuest_Guest] FOREIGN KEY([Guest])
REFERENCES [dbo].[Guest] ([id])
GO
ALTER TABLE [dbo].[BillGuest] CHECK CONSTRAINT [FK_BillGuest_Guest]
GO
ALTER TABLE [dbo].[BillService]  WITH CHECK ADD  CONSTRAINT [FK_BillService_Bill] FOREIGN KEY([Bill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[BillService] CHECK CONSTRAINT [FK_BillService_Bill]
GO
ALTER TABLE [dbo].[BillService]  WITH CHECK ADD  CONSTRAINT [FK_BillService_Service] FOREIGN KEY([Service])
REFERENCES [dbo].[Service] ([id])
GO
ALTER TABLE [dbo].[BillService] CHECK CONSTRAINT [FK_BillService_Service]
GO
ALTER TABLE [dbo].[Complain]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_Employee] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Complain] CHECK CONSTRAINT [FK_Table_1_Employee]
GO
ALTER TABLE [dbo].[Complain]  WITH CHECK ADD  CONSTRAINT [FK_Table_1_Guest] FOREIGN KEY([Guest])
REFERENCES [dbo].[Guest] ([id])
GO
ALTER TABLE [dbo].[Complain] CHECK CONSTRAINT [FK_Table_1_Guest]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Company] FOREIGN KEY([Company])
REFERENCES [dbo].[Company] ([id])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Company]
GO
ALTER TABLE [dbo].[Contract]  WITH CHECK ADD  CONSTRAINT [FK_Contract_Employee] FOREIGN KEY([Employee])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[Contract] CHECK CONSTRAINT [FK_Contract_Employee]
GO
ALTER TABLE [dbo].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Hotel] FOREIGN KEY([BuildingRoom])
REFERENCES [dbo].[Hotel] ([id])
GO
ALTER TABLE [dbo].[Room] CHECK CONSTRAINT [FK_Room_Hotel]
GO
ALTER TABLE [dbo].[RoomBill]  WITH CHECK ADD  CONSTRAINT [FK_RoomBill_Bill] FOREIGN KEY([Bill])
REFERENCES [dbo].[Bill] ([id])
GO
ALTER TABLE [dbo].[RoomBill] CHECK CONSTRAINT [FK_RoomBill_Bill]
GO
ALTER TABLE [dbo].[RoomBill]  WITH CHECK ADD  CONSTRAINT [FK_RoomBill_Room] FOREIGN KEY([Room])
REFERENCES [dbo].[Room] ([id])
GO
ALTER TABLE [dbo].[RoomBill] CHECK CONSTRAINT [FK_RoomBill_Room]
GO
