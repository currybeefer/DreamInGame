using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

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

        public override string ToString()
        {
            return string.Format("name: {0},end: {1},length: {2},map: {3},character: {4}", name, end, length, map,
                Characters);
        }
    }
}