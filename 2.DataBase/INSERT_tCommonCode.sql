SELECT * FROM tCommonCode;
SELECT * FROM tCommonCodeGroup;

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
1
,'UserTypeCd'
,'INR'
,'내부사용자'
,1
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
1
,'UserTypeCd'
,'OUR'
,'외부사용자'
,2
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
1
,'UserTypeCd'
,'MASTER'
,'관리자'
,3
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
2
,'AuthTypeCd'
,'S'
,'사용자'
,1
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
2
,'AuthTypeCd'
,'N'
,'관리자'
,2
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
3
,'OrgCd'
,'SIN'
,'신풍제약'
,1
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
3
,'OrgCd'
,'SAM'
,'삼성제약'
,2
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
3
,'OrgCd'
,'YNG'
,'영풍제약'
,3
,'Y'
,'N'
,GETDATE()
,GETDATE()
);


INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
4
,'DivisionCd'
,'SM'
,'운영팀'
,1
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
4
,'DivisionCd'
,'SI'
,'개발팀'
,2
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
4
,'DivisionCd'
,'SE'
,'연구소'
,3
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
5
,'AppTypeCd'
,'A'
,'승인'
,1
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
5
,'AppTypeCd'
,'R'
,'보류'
,2
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
5
,'AppTypeCd'
,'N'
,'미승인'
,3
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
6
,'GenderCd'
,'F'
,'여자'
,1
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
6
,'GenderCd'
,'M'
,'남자'
,2
,'Y'
,'N'
,GETDATE()
,GETDATE()
);



INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'02'
,'서울'
,1
,'Y'
,'N'
,GETDATE()
,GETDATE()
);


INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'031'
,'경기도'
,2
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'051'
,'부산'
,3
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'053'
,'대구'
,4
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'032'
,'인천'
,5
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'033'
,'강원'
,6
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'064'
,'제주'
,7
,'Y'
,'N'
,GETDATE()
,GETDATE()
);

INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'044'
,'세종'
,8
,'Y'
,'N'
,GETDATE()
,GETDATE()
);


INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'010'
,''
,9
,'Y'
,'N'
,GETDATE()
,GETDATE()
);
INSERT INTO tCommonCode(
GroupIdx
,GroupCode
,CommonCode
,CodeName
,DisplayOrder
,UseYn
,DltYn
,CrtDateTime
,UptDateTime)
VALUES(
7
,'OffTelCd'
,'011'
,''
,10
,'Y'
,'N'
,GETDATE()
,GETDATE()
);
