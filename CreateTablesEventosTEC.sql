USE [EventosTEC]
GO
/****** Object:  Table [dbo].[ApplicationRole]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ApplicationRole](
	[idApplicationRole] [int] IDENTITY(1,1) NOT NULL,
	[applicationRoleName] [varchar](255) NOT NULL,
	[parentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idApplicationRole] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AttendaceState]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AttendaceState](
	[idAttendanceState] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AttendaceState] PRIMARY KEY CLUSTERED 
(
	[idAttendanceState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Campus]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Campus](
	[idCampus] [int] IDENTITY(1,1) NOT NULL,
	[campusName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idCampus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CampusXLocation]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CampusXLocation](
	[idCampus] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[idComment] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](255) NOT NULL,
	[date] [datetime] NULL,
	[text] [nvarchar](50) NULL,
	[idEvent] [int] NULL,
 CONSTRAINT [PK_Comentario] PRIMARY KEY CLUSTERED 
(
	[idComment] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Constraint]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Constraint](
	[idConstraint] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[description] [nvarchar](50) NULL,
 CONSTRAINT [PK_Restriccion] PRIMARY KEY CLUSTERED 
(
	[idConstraint] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Degree]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Degree](
	[idDegree] [int] IDENTITY(1,1) NOT NULL,
	[degreeName] [varchar](255) NOT NULL,
	[idCampus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idDegree] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[email] [varchar](255) NOT NULL,
	[idSchool] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[name] [nvarchar](50) NULL,
	[date] [datetime] NULL,
	[idEventState] [int] NOT NULL,
	[description] [nvarchar](50) NULL,
	[organizer] [nvarchar](50) NOT NULL,
	[maxCapacity] [nchar](10) NULL,
	[entryCost] [nchar](10) NULL,
	[idEvent] [int] IDENTITY(1,1) NOT NULL,
	[idEventType] [int] NULL,
 CONSTRAINT [PK_Evento] PRIMARY KEY CLUSTERED 
(
	[idEvent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventAttendance]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventAttendance](
	[idEvent] [int] NOT NULL,
	[email] [varchar](255) NOT NULL,
	[confirmationDate] [datetime] NOT NULL,
	[idAttendanceState] [int] NOT NULL,
 CONSTRAINT [PK_EventXPerson] PRIMARY KEY CLUSTERED 
(
	[idEvent] ASC,
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventState]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventState](
	[idEventState] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[idEventState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventType]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventType](
	[idEventType] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](10) NULL,
	[description] [nchar](10) NULL,
 CONSTRAINT [PK_EventType] PRIMARY KEY CLUSTERED 
(
	[idEventType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EventXFacility]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventXFacility](
	[idEvent] [int] NOT NULL,
	[idFacility] [int] NOT NULL,
 CONSTRAINT [PK_EventXBuilding] PRIMARY KEY CLUSTERED 
(
	[idEvent] ASC,
	[idFacility] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facility]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facility](
	[idFacility] [int] NOT NULL,
	[name] [nchar](50) NOT NULL,
	[idBuildingType] [tinyint] NULL,
	[capacity] [smallint] NULL,
	[idLocation] [int] NULL,
	[idFacilityAdministrator] [int] NOT NULL,
 CONSTRAINT [PK_Establecimiento] PRIMARY KEY CLUSTERED 
(
	[idFacility] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacilityAdministrator]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacilityAdministrator](
	[idFacilityAdministrator] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](255) NOT NULL,
 CONSTRAINT [PK_FacilityAdministrator] PRIMARY KEY CLUSTERED 
(
	[idFacilityAdministrator] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacilityReservation]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacilityReservation](
	[idFacilityReservation] [int] IDENTITY(1,1) NOT NULL,
	[idFacility] [int] NOT NULL,
	[day] [int] NOT NULL,
	[startingHour] [time](0) NOT NULL,
	[finishHour] [time](0) NOT NULL,
	[idReservatioState] [int] NOT NULL,
 CONSTRAINT [PK_FacilityReservation] PRIMARY KEY CLUSTERED 
(
	[idFacilityReservation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacilitySchedule]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacilitySchedule](
	[idFacilitySchedule] [int] IDENTITY(1,1) NOT NULL,
	[day] [tinyint] NOT NULL,
	[idScheduleHoursRange] [int] NOT NULL,
	[idFacility] [int] NOT NULL,
 CONSTRAINT [PK_FacilitySchedule] PRIMARY KEY CLUSTERED 
(
	[idFacilitySchedule] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacilityType]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacilityType](
	[idFacilityType] [tinyint] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_BuildingType_1] PRIMARY KEY CLUSTERED 
(
	[idFacilityType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacilityXConstraint]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacilityXConstraint](
	[idFacility] [int] IDENTITY(1,1) NOT NULL,
	[idConstraint] [int] NOT NULL,
 CONSTRAINT [PK_FacilityXConstraint] PRIMARY KEY CLUSTERED 
(
	[idFacility] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Location]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Location](
	[idLocation] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](50) NULL,
	[coordinates] [geography] NULL,
	[inCampus] [bit] NULL,
 CONSTRAINT [PK_Ubicacion] PRIMARY KEY CLUSTERED 
(
	[idLocation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Organization]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[email] [varchar](255) NOT NULL,
	[idDegree] [int] NULL,
	[organizationPassword] [varchar](255) NOT NULL,
	[organizationName] [varchar](255) NOT NULL,
	[idOrganizationType] [int] NOT NULL,
	[isCouncil] [bit] NOT NULL,
 CONSTRAINT [PK__Organiza__AB6E6165F9958DF0] PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrganizationType]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrganizationType](
	[idOrganizationType] [int] IDENTITY(1,1) NOT NULL,
	[typeName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idOrganizationType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[email] [varchar](255) NOT NULL,
	[personPassword] [varchar](255) NOT NULL,
	[cardNumber] [int] NOT NULL,
	[personName] [varchar](255) NOT NULL,
	[firstLastName] [varchar](255) NOT NULL,
	[secondLastName] [varchar](255) NOT NULL,
	[debt] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonXApplicationRole]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonXApplicationRole](
	[email] [varchar](255) NOT NULL,
	[applicationRoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[email] ASC,
	[applicationRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[idRequest] [int] IDENTITY(1,1) NOT NULL,
	[idFacility] [int] NULL,
	[date] [datetime] NULL,
	[motive] [nvarchar](50) NULL,
	[idRequestState] [int] NULL,
	[idEvent] [int] NULL,
 CONSTRAINT [PK_Solicitud] PRIMARY KEY CLUSTERED 
(
	[idRequest] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestState]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestState](
	[idRequestState] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_RequestState] PRIMARY KEY CLUSTERED 
(
	[idRequestState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationState]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationState](
	[idReservationState] [int] IDENTITY(1,1) NOT NULL,
	[reservatioStateName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ReservationState] PRIMARY KEY CLUSTERED 
(
	[idReservationState] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ScheduleHoursRange]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScheduleHoursRange](
	[idScheduleHoursRange] [int] IDENTITY(1,1) NOT NULL,
	[startHour] [time](0) NOT NULL,
	[finishHour] [time](0) NOT NULL,
 CONSTRAINT [PK_ScheduleHoursRange] PRIMARY KEY CLUSTERED 
(
	[idScheduleHoursRange] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School](
	[idSchool] [int] IDENTITY(1,1) NOT NULL,
	[schoolName] [varchar](255) NOT NULL,
	[idCampus] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSchool] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 15/10/2023 00:45:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[email] [varchar](255) NOT NULL,
	[idStudent] [int] NOT NULL,
	[idDegree] [int] NOT NULL,
	[isExemptFromPrintingCosts] [bit] NULL,
UNIQUE NONCLUSTERED 
(
	[idStudent] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ApplicationRole]  WITH CHECK ADD FOREIGN KEY([parentId])
REFERENCES [dbo].[ApplicationRole] ([idApplicationRole])
GO
ALTER TABLE [dbo].[ApplicationRole]  WITH CHECK ADD FOREIGN KEY([parentId])
REFERENCES [dbo].[ApplicationRole] ([idApplicationRole])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Event] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([idEvent])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Event]
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD  CONSTRAINT [FK_Comment_Person] FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
ALTER TABLE [dbo].[Comment] CHECK CONSTRAINT [FK_Comment_Person]
GO
ALTER TABLE [dbo].[Degree]  WITH CHECK ADD FOREIGN KEY([idCampus])
REFERENCES [dbo].[Campus] ([idCampus])
GO
ALTER TABLE [dbo].[Degree]  WITH CHECK ADD FOREIGN KEY([idCampus])
REFERENCES [dbo].[Campus] ([idCampus])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([idSchool])
REFERENCES [dbo].[School] ([idSchool])
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD FOREIGN KEY([idSchool])
REFERENCES [dbo].[School] ([idSchool])
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Event_EventType] FOREIGN KEY([idEventType])
REFERENCES [dbo].[EventType] ([idEventType])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Event_EventType]
GO
ALTER TABLE [dbo].[Event]  WITH CHECK ADD  CONSTRAINT [FK_Evento_Estado] FOREIGN KEY([idEventState])
REFERENCES [dbo].[EventState] ([idEventState])
GO
ALTER TABLE [dbo].[Event] CHECK CONSTRAINT [FK_Evento_Estado]
GO
ALTER TABLE [dbo].[EventAttendance]  WITH CHECK ADD  CONSTRAINT [FK_EventAttendance_AttendaceState] FOREIGN KEY([idAttendanceState])
REFERENCES [dbo].[AttendaceState] ([idAttendanceState])
GO
ALTER TABLE [dbo].[EventAttendance] CHECK CONSTRAINT [FK_EventAttendance_AttendaceState]
GO
ALTER TABLE [dbo].[EventAttendance]  WITH CHECK ADD  CONSTRAINT [FK_EventXPerson_Event] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([idEvent])
GO
ALTER TABLE [dbo].[EventAttendance] CHECK CONSTRAINT [FK_EventXPerson_Event]
GO
ALTER TABLE [dbo].[EventAttendance]  WITH CHECK ADD  CONSTRAINT [FK_EventXPerson_Person] FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
ALTER TABLE [dbo].[EventAttendance] CHECK CONSTRAINT [FK_EventXPerson_Person]
GO
ALTER TABLE [dbo].[EventXFacility]  WITH CHECK ADD  CONSTRAINT [FK_EventXBuilding_Building] FOREIGN KEY([idFacility])
REFERENCES [dbo].[Facility] ([idFacility])
GO
ALTER TABLE [dbo].[EventXFacility] CHECK CONSTRAINT [FK_EventXBuilding_Building]
GO
ALTER TABLE [dbo].[EventXFacility]  WITH CHECK ADD  CONSTRAINT [FK_EventXBuilding_Event] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([idEvent])
GO
ALTER TABLE [dbo].[EventXFacility] CHECK CONSTRAINT [FK_EventXBuilding_Event]
GO
ALTER TABLE [dbo].[Facility]  WITH CHECK ADD  CONSTRAINT [FK_Building_BuildingType1] FOREIGN KEY([idBuildingType])
REFERENCES [dbo].[FacilityType] ([idFacilityType])
GO
ALTER TABLE [dbo].[Facility] CHECK CONSTRAINT [FK_Building_BuildingType1]
GO
ALTER TABLE [dbo].[Facility]  WITH CHECK ADD  CONSTRAINT [FK_Establecimiento_Ubicacion] FOREIGN KEY([idLocation])
REFERENCES [dbo].[Location] ([idLocation])
GO
ALTER TABLE [dbo].[Facility] CHECK CONSTRAINT [FK_Establecimiento_Ubicacion]
GO
ALTER TABLE [dbo].[Facility]  WITH CHECK ADD  CONSTRAINT [FK_Facility_FacilityAdministrator] FOREIGN KEY([idFacilityAdministrator])
REFERENCES [dbo].[FacilityAdministrator] ([idFacilityAdministrator])
GO
ALTER TABLE [dbo].[Facility] CHECK CONSTRAINT [FK_Facility_FacilityAdministrator]
GO
ALTER TABLE [dbo].[FacilityAdministrator]  WITH CHECK ADD  CONSTRAINT [FK_FacilityAdministrator_Person] FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
ALTER TABLE [dbo].[FacilityAdministrator] CHECK CONSTRAINT [FK_FacilityAdministrator_Person]
GO
ALTER TABLE [dbo].[FacilityReservation]  WITH CHECK ADD  CONSTRAINT [FK_FacilityReservation_Facility] FOREIGN KEY([idFacility])
REFERENCES [dbo].[Facility] ([idFacility])
GO
ALTER TABLE [dbo].[FacilityReservation] CHECK CONSTRAINT [FK_FacilityReservation_Facility]
GO
ALTER TABLE [dbo].[FacilityReservation]  WITH CHECK ADD  CONSTRAINT [FK_FacilityReservation_ReservationState] FOREIGN KEY([idReservatioState])
REFERENCES [dbo].[ReservationState] ([idReservationState])
GO
ALTER TABLE [dbo].[FacilityReservation] CHECK CONSTRAINT [FK_FacilityReservation_ReservationState]
GO
ALTER TABLE [dbo].[FacilitySchedule]  WITH CHECK ADD  CONSTRAINT [FK_FacilitySchedule_Facility] FOREIGN KEY([idFacility])
REFERENCES [dbo].[Facility] ([idFacility])
GO
ALTER TABLE [dbo].[FacilitySchedule] CHECK CONSTRAINT [FK_FacilitySchedule_Facility]
GO
ALTER TABLE [dbo].[FacilitySchedule]  WITH CHECK ADD  CONSTRAINT [FK_FacilitySchedule_ScheduleHoursRange] FOREIGN KEY([idScheduleHoursRange])
REFERENCES [dbo].[ScheduleHoursRange] ([idScheduleHoursRange])
GO
ALTER TABLE [dbo].[FacilitySchedule] CHECK CONSTRAINT [FK_FacilitySchedule_ScheduleHoursRange]
GO
ALTER TABLE [dbo].[FacilityXConstraint]  WITH CHECK ADD  CONSTRAINT [FK_FacilityXConstraint_Constraint] FOREIGN KEY([idConstraint])
REFERENCES [dbo].[Constraint] ([idConstraint])
GO
ALTER TABLE [dbo].[FacilityXConstraint] CHECK CONSTRAINT [FK_FacilityXConstraint_Constraint]
GO
ALTER TABLE [dbo].[FacilityXConstraint]  WITH CHECK ADD  CONSTRAINT [FK_FacilityXConstraint_Facility] FOREIGN KEY([idFacility])
REFERENCES [dbo].[Facility] ([idFacility])
GO
ALTER TABLE [dbo].[FacilityXConstraint] CHECK CONSTRAINT [FK_FacilityXConstraint_Facility]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK__Organizat__degre__04E4BC85] FOREIGN KEY([idDegree])
REFERENCES [dbo].[Degree] ([idDegree])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK__Organizat__degre__04E4BC85]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK__Organizat__degre__5EBF139D] FOREIGN KEY([idDegree])
REFERENCES [dbo].[Degree] ([idDegree])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK__Organizat__degre__5EBF139D]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK__Organizat__typeI__05D8E0BE] FOREIGN KEY([idOrganizationType])
REFERENCES [dbo].[OrganizationType] ([idOrganizationType])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK__Organizat__typeI__05D8E0BE]
GO
ALTER TABLE [dbo].[Organization]  WITH CHECK ADD  CONSTRAINT [FK__Organizat__typeI__5FB337D6] FOREIGN KEY([idOrganizationType])
REFERENCES [dbo].[OrganizationType] ([idOrganizationType])
GO
ALTER TABLE [dbo].[Organization] CHECK CONSTRAINT [FK__Organizat__typeI__5FB337D6]
GO
ALTER TABLE [dbo].[PersonXApplicationRole]  WITH CHECK ADD FOREIGN KEY([applicationRoleId])
REFERENCES [dbo].[ApplicationRole] ([idApplicationRole])
GO
ALTER TABLE [dbo].[PersonXApplicationRole]  WITH CHECK ADD FOREIGN KEY([applicationRoleId])
REFERENCES [dbo].[ApplicationRole] ([idApplicationRole])
GO
ALTER TABLE [dbo].[PersonXApplicationRole]  WITH CHECK ADD FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
ALTER TABLE [dbo].[PersonXApplicationRole]  WITH CHECK ADD FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_Event] FOREIGN KEY([idEvent])
REFERENCES [dbo].[Event] ([idEvent])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_Event]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_RequestState] FOREIGN KEY([idRequestState])
REFERENCES [dbo].[RequestState] ([idRequestState])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_RequestState]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Solicitud_Establecimiento] FOREIGN KEY([idFacility])
REFERENCES [dbo].[Facility] ([idFacility])
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Solicitud_Establecimiento]
GO
ALTER TABLE [dbo].[School]  WITH CHECK ADD FOREIGN KEY([idCampus])
REFERENCES [dbo].[Campus] ([idCampus])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([idDegree])
REFERENCES [dbo].[Degree] ([idDegree])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([idDegree])
REFERENCES [dbo].[Degree] ([idDegree])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
ALTER TABLE [dbo].[Student]  WITH CHECK ADD FOREIGN KEY([email])
REFERENCES [dbo].[Person] ([email])
GO
