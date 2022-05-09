USE [SCBEFT]
GO
/****** Object:  Table [dbo].[UP_API_Secret]    Script Date: 5/9/2022 12:34:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UP_API_Secret](
	[ClientId] [varchar](50) NULL,
	[ClientSecret] [varchar](255) NULL,
	[CreateDate] [datetime] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[UP_API_Secret] ([ClientId], [ClientSecret], [CreateDate]) VALUES (N'api_user_name', N'BVfTNcGVmZ892apJDNB%!Fb!zdebNq', CAST(N'2022-04-27T15:31:39.113' AS DateTime))
GO
ALTER TABLE [dbo].[UP_API_Secret] ADD  DEFAULT (getdate()) FOR [CreateDate]
GO
/****** Object:  StoredProcedure [dbo].[UP_CheckClientSecret]    Script Date: 5/9/2022 12:34:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UP_CheckClientSecret](@ClientId varchar(50), @ClientSecret varchar(255), @ErrorMsg varchar(100) OUTPUT)
AS
BEGIN
	SET @ErrorMsg = ''
	IF(NOT EXISTS(SELECT 1 FROM SCBEFT.dbo.UP_API_Secret where ClientId = @ClientId AND ClientSecret = @ClientSecret))
		SET @ErrorMsg = 'User secret does not match'
END
GO
