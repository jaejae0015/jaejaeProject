ALTER DATABASE jaejaeSystem
COLLATE korean_wansung_ci_as;

ALTER DATABASE jaejaeSystem SET MULTI_USER;


SELECT * FROM testTB;

INSERT INTO testTB (
USERID
,USERPASS
,USERNM
,USERTYPECD
,AUTHTYPE
,OFFICETEL1
,OFFICETEL2
,OFFICETEL3
,CELLNO1
,CELLNO2
,CELLNO3
,ZIPCODE
,ADDRESS
,ADDRESS1
,EMAIL1
,EMAIL2
,ISSMS
,ISEMAIL
,COMPANYID
,ORGNM
,DIVISIONNM
,JOBNM
,EMPNO
,ENTERDT
,APPTYPE
,APPDT
,APPUSERID
,DELYN
,CREDT
,CREUSERID
,MODDT
,MODUSERID
,RESEARCHERNM
,BIRTHDT
,GENDERCD) VALUES (
'JAEJAE1','jaejae0015','관리자','Master','A', NULL, NULL, NULL, NULL, NULL, NULL, NULL,NULL,NULL,'jaejae', 	'github.com',	'Y',	'Y',1	,null,	null,NULL,'A98095112',	'20220406',	'C',	'20220406',	'jaejae0015','N',GETDATE(),'jaejae0015',GETDATE(),'jaejae0015','서지애','20000115','F'
);