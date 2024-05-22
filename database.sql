-- criar banco de dados
create database DbManagementTasks;

--Criar tabela
USE [DbManagementTasks];

CREATE TABLE [dbo].[Tasks](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Title] [varchar](100) NOT NULL,
    [Description] [varchar](500) NOT NULL,
    [Status] [varchar](15) NOT NULL,
    [EstimatePoints] [int] NOT NULL,
    [CreateDate] [datetime] NOT NULL,   
	[ModifyDate] [datetime] NULL,  
	Deleted BIT NOT NULL,
 CONSTRAINT [Pk_Task] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO