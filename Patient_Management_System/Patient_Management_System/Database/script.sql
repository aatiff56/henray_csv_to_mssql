USE [master]
GO
/****** Object:  Database [Patient]    Script Date: 2/22/2022 9:25:42 AM ******/
CREATE DATABASE [Patient]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Patients', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Patients.mdf' , SIZE = 28864KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Patients_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Patients_log.ldf' , SIZE = 48384KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Patient] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Patient].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Patient] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Patient] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Patient] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Patient] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Patient] SET ARITHABORT OFF 
GO
ALTER DATABASE [Patient] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Patient] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Patient] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Patient] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Patient] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Patient] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Patient] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Patient] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Patient] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Patient] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Patient] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Patient] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Patient] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Patient] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Patient] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Patient] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Patient] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Patient] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Patient] SET  MULTI_USER 
GO
ALTER DATABASE [Patient] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Patient] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Patient] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Patient] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Patient] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Patient]
GO
/****** Object:  Table [dbo].[CathLabHistory]    Script Date: 2/22/2022 9:25:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CathLabHistory](
	[CathLabHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[TeamActivationDate] [date] NULL,
	[TeamActivationTime] [time](7) NULL,
	[TeamActivation] [nvarchar](500) NULL,
	[ArrivalDate] [date] NULL,
	[ArrivalTime] [time](7) NULL,
 CONSTRAINT [PK_CathLabHistory] PRIMARY KEY CLUSTERED 
(
	[CathLabHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ConsultationHistory]    Script Date: 2/22/2022 9:25:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConsultationHistory](
	[ConsultingHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[ConsultingService] [nvarchar](500) NULL,
	[ServiceTimelyArrival] [nvarchar](500) NULL,
	[ServiceType] [nvarchar](100) NULL,
	[Staff] [nvarchar](1000) NULL,
	[ServiceDate] [date] NULL,
	[ServiceTime] [time](7) NULL,
 CONSTRAINT [PK_ConsultingHistory] PRIMARY KEY CLUSTERED 
(
	[ConsultingHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ECGHistory]    Script Date: 2/22/2022 9:25:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ECGHistory](
	[ECGHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[FirstECGDate] [date] NULL,
	[FirstECGTime] [time](7) NULL,
	[NotedOn] [nvarchar](1000) NULL,
	[SubsequentWithMIDate] [nvarchar](1000) NULL,
	[SubSequentWithMITime] [nvarchar](1000) NULL,
 CONSTRAINT [PK_ECGHistory] PRIMARY KEY CLUSTERED 
(
	[ECGHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmergencyDepartment]    Script Date: 2/22/2022 9:25:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmergencyDepartment](
	[EmergencyDepartmentID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[DischargeDate] [date] NULL,
	[DischargeTime] [time](7) NULL,
	[Deposition] [nvarchar](500) NULL,
	[DischargeTransportMode] [nvarchar](100) NULL,
	[DestinationDetermination] [nvarchar](500) NULL,
	[Physician] [nvarchar](100) NULL,
	[PhysicianServiceType] [nvarchar](200) NULL,
	[MITeamActivatedBy] [nvarchar](100) NULL,
	[AdvancedDirective] [nvarchar](1000) NULL,
 CONSTRAINT [PK_EmergencyDepartment] PRIMARY KEY CLUSTERED 
(
	[EmergencyDepartmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EMSHistory]    Script Date: 2/22/2022 9:25:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EMSHistory](
	[EMSHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[NonEMSFirstMedicalContactDate] [date] NULL,
	[NonEMSFirstMedicalContactTimeEstimate] [nvarchar](100) NULL,
	[EMS1stContactDate] [date] NULL,
	[EMS1stContactTime] [time](7) NULL,
	[NonEMSCardiacArrest] [nvarchar](100) NULL,
 CONSTRAINT [PK_EMSHistory] PRIMARY KEY CLUSTERED 
(
	[EMSHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MedicationHistory]    Script Date: 2/22/2022 9:25:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MedicationHistory](
	[MedicationHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[AntiThrombolicMedication] [nvarchar](500) NULL,
	[AsprinAtHome] [nvarchar](100) NULL,
	[AsprinInFirst24hrs] [nvarchar](100) NULL,
	[AsprinAtDischarge] [nvarchar](100) NULL,
	[BetaBlockerAtDischarge] [nvarchar](100) NULL,
	[StatinAtDischarge] [nvarchar](100) NULL,
	[StatinAtDischargeDose] [nvarchar](100) NULL,
 CONSTRAINT [PK_MedicationHistory] PRIMARY KEY CLUSTERED 
(
	[MedicationHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patient]    Script Date: 2/22/2022 9:25:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patient](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[AdmissionDate] [date] NULL,
	[AdmissionTime] [time](7) NULL,
	[LastName] [nvarchar](100) NULL,
	[FirstName] [nvarchar](100) NULL,
	[MiddleName] [nvarchar](100) NULL,
	[City] [nvarchar](100) NULL,
	[PatientCounty] [nvarchar](100) NULL,
	[State] [nvarchar](100) NULL,
	[PostCode] [nvarchar](100) NULL,
	[Country] [nvarchar](100) NULL,
	[DOB] [nvarchar](100) NULL,
	[Gender] [nvarchar](100) NULL,
	[Race] [nvarchar](100) NULL,
	[Ethnicity] [nvarchar](100) NULL,
	[Age] [tinyint] NULL,
	[AgeUnits] [nvarchar](50) NULL,
	[DeathDate] [date] NULL,
	[DeathTime] [time](7) NULL,
	[DeathCircumstance] [nvarchar](1000) NULL,
	[DeathCause] [nvarchar](1000) NULL,
	[SymptomOnsetDate] [date] NULL,
	[SymptomOnsetTime] [time](7) NULL,
	[StressTesting] [nvarchar](100) NULL,
	[FirstEvaluationLocation] [nvarchar](500) NULL,
	[ReperfusionCandidate] [nvarchar](100) NULL,
	[ReperfusionReason] [nvarchar](500) NULL,
	[AdvancedNotification] [nvarchar](100) NULL,
	[PreArrivalNotificationDate] [date] NULL,
	[PreArrivalNotificationTime] [time](7) NULL,
	[FacilityName] [nvarchar](500) NOT NULL,
	[IncidentNumber] [nvarchar](100) NOT NULL,
	[TransportMode] [nvarchar](100) NULL,
 CONSTRAINT [PK_Patient] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PatientHospital]    Script Date: 2/22/2022 9:25:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PatientHospital](
	[PatientHospitalID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[AdmissionDate] [date] NULL,
	[AdmissionTime] [time](7) NULL,
	[DischargeDate] [date] NULL,
	[DischargeTime] [time](7) NULL,
	[DischargeDisposition] [nvarchar](500) NULL,
	[TransferredTo] [nvarchar](500) NULL,
	[OutcomeDestinationDetermination] [nvarchar](500) NULL,
	[DirectAdmit] [nvarchar](100) NULL,
	[DischargeLocation] [nvarchar](500) NULL,
	[ReferringHospital] [nvarchar](500) NULL,
 CONSTRAINT [PK_PatientHospital] PRIMARY KEY CLUSTERED 
(
	[PatientHospitalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PCIHistory]    Script Date: 2/22/2022 9:25:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PCIHistory](
	[PCIHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[PrimaryPCI] [nvarchar](100) NULL,
	[NoPCIReason] [nvarchar](500) NULL,
	[Procedure] [nvarchar](1000) NULL,
	[Delay] [nvarchar](100) NULL,
	[DelayReason] [nvarchar](1000) NULL,
	[NonSystemDelayReason] [nvarchar](1000) NULL,
	[CABGTransfer] [nvarchar](500) NULL,
	[CardiacRehabilitationReferral] [nvarchar](500) NULL,
	[ICD10DiagnosticCode] [nvarchar](100) NULL,
	[FirstDeviceActivationTime] [time](7) NULL,
	[FirstDeviceActivationDate] [date] NULL,
 CONSTRAINT [PK_PCIHistory] PRIMARY KEY CLUSTERED 
(
	[PCIHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThrombolyticsHistory]    Script Date: 2/22/2022 9:25:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThrombolyticsHistory](
	[ThrombolyticsHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[Thrombolytics] [nvarchar](500) NULL,
	[DoseStartDate] [date] NULL,
	[DoseStartTime] [time](7) NULL,
	[NoAdministrationReason] [nvarchar](500) NULL,
 CONSTRAINT [PK_ThrombolyticsHistory] PRIMARY KEY CLUSTERED 
(
	[ThrombolyticsHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TruamaHistory]    Script Date: 2/22/2022 9:25:43 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TruamaHistory](
	[TruamaHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[SurgeonCalledDate] [date] NULL,
	[TraumaSurgeonCalledTime] [time](7) NULL,
	[SurgeonDateArrived] [date] NULL,
	[SurgeonTimeArrived] [time](7) NULL,
	[SurgeonTimelyArrival] [nvarchar](500) NULL,
 CONSTRAINT [PK_TruamaHistory] PRIMARY KEY CLUSTERED 
(
	[TruamaHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CathLabHistory]  WITH CHECK ADD  CONSTRAINT [FK_CathLabHistory_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[CathLabHistory] CHECK CONSTRAINT [FK_CathLabHistory_Patient]
GO
ALTER TABLE [dbo].[ConsultationHistory]  WITH CHECK ADD  CONSTRAINT [FK_ConsultingHistory_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[ConsultationHistory] CHECK CONSTRAINT [FK_ConsultingHistory_Patient]
GO
ALTER TABLE [dbo].[ECGHistory]  WITH CHECK ADD  CONSTRAINT [FK_ECGHistory_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[ECGHistory] CHECK CONSTRAINT [FK_ECGHistory_Patient]
GO
ALTER TABLE [dbo].[EmergencyDepartment]  WITH CHECK ADD  CONSTRAINT [FK_EmergencyDepartment_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[EmergencyDepartment] CHECK CONSTRAINT [FK_EmergencyDepartment_Patient]
GO
ALTER TABLE [dbo].[EMSHistory]  WITH CHECK ADD  CONSTRAINT [FK_EMSHistory_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[EMSHistory] CHECK CONSTRAINT [FK_EMSHistory_Patient]
GO
ALTER TABLE [dbo].[MedicationHistory]  WITH CHECK ADD  CONSTRAINT [FK_MedicationHistory_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[MedicationHistory] CHECK CONSTRAINT [FK_MedicationHistory_Patient]
GO
ALTER TABLE [dbo].[PatientHospital]  WITH CHECK ADD  CONSTRAINT [FK_PatientHospital_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[PatientHospital] CHECK CONSTRAINT [FK_PatientHospital_Patient]
GO
ALTER TABLE [dbo].[PCIHistory]  WITH CHECK ADD  CONSTRAINT [FK_PCIHistory_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[PCIHistory] CHECK CONSTRAINT [FK_PCIHistory_Patient]
GO
ALTER TABLE [dbo].[ThrombolyticsHistory]  WITH CHECK ADD  CONSTRAINT [FK_ThrombolyticsHistory_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[ThrombolyticsHistory] CHECK CONSTRAINT [FK_ThrombolyticsHistory_Patient]
GO
ALTER TABLE [dbo].[TruamaHistory]  WITH CHECK ADD  CONSTRAINT [FK_TruamaHistory_Patient] FOREIGN KEY([PatientID])
REFERENCES [dbo].[Patient] ([PatientID])
GO
ALTER TABLE [dbo].[TruamaHistory] CHECK CONSTRAINT [FK_TruamaHistory_Patient]
GO
USE [master]
GO
ALTER DATABASE [Patient] SET  READ_WRITE 
GO
