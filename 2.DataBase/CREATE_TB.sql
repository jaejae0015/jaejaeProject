CREATE TABLE testTB(
 UKID numeric(38,0) IDENTITY(1,1) primary key not null
,USERID nvarchar(20) null UNIQUE
,USERPASS nvarchar(2000) null
,USERNM nvarchar(60) null
,USERTYPECD nvarchar(20) null
,AUTHTYPE nchar(1)
,OFFICETEL1 nvarchar(3) null
,OFFICETEL2 varbinary(max) null
,OFFICETEL3 varbinary(max) null
,CELLNO1 nvarchar(3) null
,CELLNO2 varbinary(max) null
,CELLNO3 varbinary(max) null
,ZIPCODE nvarchar(7) null
,ADDRESS nvarchar(500) null
,ADDRESS1 nvarchar(max) null
,EMAIL1 nvarchar(max) null
,EMAIL2 nvarchar(60) null
,ISSMS nchar(1) null
,ISEMAIL nchar(1) null
,COMPANYID numeric(38,0) null
,ORGNM nvarchar(200) null
,DIVISIONNM nvarchar(200) null
,JOBNM nvarchar(200) null
,EMPNO nvarchar(20) null
,ENTERDT nvarchar(8) null
,APPTYPE nchar(1) null
,APPDT nvarchar(8) null
,APPUSERID nvarchar(20) null
,DELYN nchar(1) null
,CREDT datetime null
,CREUSERID  nvarchar(20) null
,MODDT datetime null
,MODUSERID nvarchar(20) null
,RESEARCHERNM nvarchar(20) null
,BIRTHDT nvarchar(8) null
,GENDERCD nchar(1) null);
