USE [jaejaeSystem]
GO
/****** Object:  StoredProcedure [dbo].[pSelectConditionTestTB]    Script Date: 2022-04-12 오후 2:32:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*
=============================================
 Author:		서지애
 Create date:	2022-04-12
 Description:	사용자 조건조회
----------------------------------------------------------------------------------
Date				Author				Description
----------------------------------------------------------------------------------
2022-04-12			서지애				최초생성
----------------------------------------------------------------------------------
=============================================
*/
ALTER PROCEDURE [dbo].[pSelectConditionTestTB]
(
	@strSearchText		nvarchar(max)
)
AS
select	UKID
		,tt.USERID
		,tt.USERPASS
		,tt.USERNM
		,cd.CommonCode AS USERTYPECD
		,tt.AUTHTYPE
		,tt.OFFICETEL1
		,tt.OFFICETEL2
		,tt.OFFICETEL3
		,tt.CELLNO1
		,tt.CELLNO2
		,tt.CELLNO3
		,tt.ZIPCODE
		,tt.ADDRESS
		,tt.ADDRESS1
		,tt.EMAIL1
		,tt.EMAIL2
		,tt.ISSMS
		,tt.ISEMAIL
		,tt.COMPANYID
		,tt.ORGNM
		,tt.DIVISIONNM
		,tt.JOBNM
		,tt.EMPNO
		,tt.ENTERDT
		,tt.APPTYPE
		,tt.APPDT
		,tt.APPUSERID
		,tt.DELYN
		,tt.CREDT
		,tt.CREUSERID
		,tt.MODDT
		,tt.MODUSERID
		,tt.RESEARCHERNM
		,tt.BIRTHDT
		,tt.GENDERCD
from userTB  as tt
	LEFT OUTER JOIN tCommonCode cd
	ON tt.USERTYPECD = cd.CommonCode
where tt.USERID LIKE '%'+@strSearchText+'%' AND tt.DELYN = 'N'