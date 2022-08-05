USE [TEST_KSK]
GO
/****** Object:  Table [dbo].[TB_TODO]    Script Date: 2022-08-04 오후 1:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TODO](
	[TODO_ID] [int] NOT NULL,
	[U_TODO] [varchar](200) NOT NULL,
	[TODO_STATUS] [varchar](8) NULL,
 CONSTRAINT [TB_TODO__ID_PK] PRIMARY KEY CLUSTERED 
(
	[TODO_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (1, N'ASP.NET STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (2, N'ASP.NET MVC STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (3, N'ASP.NET WINDOW FORM STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (4, N'ASP.NET ADO.NET STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (5, N'C# STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (6, N'JAVASCRIPT STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (7, N'HTML STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (8, N'CSS STUDY', N'Y')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (9, N'SQL SERVER STUDY', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (10, N'FRAMEWORK STUDY', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (11, N'Jquery Study', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (12, N'Jquery Study', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (13, N'ASP.NET CodeBehind STUDY', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (14, N'ASP.NET CodeBehind STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (15, N'Jquery Study3', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (16, N'Jquery Study3', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (17, N'No Refresh Test', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (18, N'No Refresh Test', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (19, N'No Refresh Test', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (20, N'Jquery Study  No Refresh Test', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (21, N'Refreshed', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (22, N'No Refresh Test', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (23, N'No Refresh Test', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (24, N'ASP.NET Repeater STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (25, N'ASP.NET Repeater STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (26, N'ASP.NET Repeater STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (27, N'ASP.NET Repeater STUDY', N'D')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (28, N'ASP.NET Repeater STUDY', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (29, N'No Refresh Test', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (30, N'Jquery Study', N'N')
INSERT [dbo].[TB_TODO] ([TODO_ID], [U_TODO], [TODO_STATUS]) VALUES (31, N'ASP.NET CodeBehind STUDY', N'N')
GO
ALTER TABLE [dbo].[TB_TODO] ADD  DEFAULT ('N') FOR [TODO_STATUS]
GO
ALTER TABLE [dbo].[TB_TODO]  WITH CHECK ADD  CONSTRAINT [TB_TODO_STATUS_CK] CHECK  (([TODO_STATUS]='Y' OR [TODO_STATUS]='N' OR [TODO_STATUS]='D'))
GO
ALTER TABLE [dbo].[TB_TODO] CHECK CONSTRAINT [TB_TODO_STATUS_CK]
GO
/****** Object:  StoredProcedure [dbo].[TODO_C]    Script Date: 2022-08-04 오후 1:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TODO_C]
(
	@U_TODO		VARCHAR(200)
)
AS
BEGIN
	
	INSERT INTO TB_TODO
	(
		  TODO_ID
		, U_TODO
	)
	VALUES
	(
		   NEXT VALUE FOR TODO_SEQ
		, @U_TODO
	);

END;
GO
/****** Object:  StoredProcedure [dbo].[TODO_D]    Script Date: 2022-08-04 오후 1:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TODO_D]
(
	@TODO_ID	INT
)
AS
BEGIN
	UPDATE TB_TODO
	SET TODO_STATUS = 'D'
	WHERE TODO_ID = @TODO_ID;
END;
GO
/****** Object:  StoredProcedure [dbo].[TODO_R]    Script Date: 2022-08-04 오후 1:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TODO_R]
AS
BEGIN
	
	SELECT ROW_NUMBER() OVER(ORDER BY TODO_ID ASC) AS [ROWNUM], TODO_ID, U_TODO, TODO_STATUS
	FROM TB_TODO
	WHERE TODO_STATUS != 'D';

END;
GO
/****** Object:  StoredProcedure [dbo].[TODO_U]    Script Date: 2022-08-04 오후 1:42:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[TODO_U]
(
	  @TODO_ID		INT
	, @TODO_STATUS  VARCHAR(8)
)
AS
BEGIN
	UPDATE TB_TODO
	SET TODO_STATUS = @TODO_STATUS
	WHERE TODO_ID = @TODO_ID;
END;
GO
