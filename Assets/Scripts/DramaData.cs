using System.Collections.Generic;

namespace EditorLogics
{
    public class DramaData
    {
        //剧本名称
        string name = "头号玩家";
        //剧本情节介绍
        private string end;
        //
        int length = 120;
        //角色列表
        List<CharacterData> Characters; //最多11个
        //地图
        MapData map;
    }
}