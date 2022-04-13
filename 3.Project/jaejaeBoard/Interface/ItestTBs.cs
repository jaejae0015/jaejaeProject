using System;
using System.Collections.Generic;
using jaejaeBoard.Models;


namespace jaejaeBoard.Interface
{
    public interface ItestTBs
    {
        //사용자 목록조회
        IEnumerable<userTB> GetUserCondition(string strSearchText);
        //사용자 상세조회
        userTB GetUserDetail(int iUserIdx);
        //사용자 등록
        int AddUser(userTB sData);
        //사용자 수정/삭제
        int ModifyUser(userTB sData);
        //그룹코드 조회
        tCommonCodeGroup GetGroupCode(string groupCode);
        //상세코드 조회
        IEnumerable<tCommonCode> GetCodeLists(int groupIdx);
    }
}
