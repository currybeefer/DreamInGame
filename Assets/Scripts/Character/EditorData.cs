using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using UnityEditor.U2D.Animation;

namespace EditorLogics
{
    public class EditorData
    {
        //剧本名称
        public string name;

        //剧本情节介绍
        public string end;

        //
        public int length;

        //角色列表
        public List<CharacterInfo> CharacterInfoList; //最多11个

        //地图
        public MapData map;

        public override string ToString()
        {
            return string.Format("name: {0},end: {1},length: {2},map: {3},character: {4}", name, end, length, map,
                CharacterInfoList);
        }
    }
}