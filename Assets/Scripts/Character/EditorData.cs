using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using UnityEditor.U2D.Animation;

namespace EditorLogics
{
    public class EditorData : MonoBehaviour
    {
        public static EditorData Instance;
        //剧本名称
        public string name;

        //剧本情节介绍
        public string end;

        //
        public int length = 120;

        //角色列表
        public List<CharacterInfo> CharacterInfoList;

        //地图
        public MapData map;

        public override string ToString()
        {
            String characterInfoStr = "";
            for (int i = 0; i < CharacterInfoList.Count; i++)
            {
                characterInfoStr += "{" + CharacterInfoList[i].ToString() + "},";
            }
            characterInfoStr = characterInfoStr.Substring(0, characterInfoStr.Length - 1);
            string nameWithNumOfPlayer = name + "," + CharacterInfoList.Count.ToString();
            String editorDataStr = "{" + string.Format("\"name\": \"{0}\",\"end\": \"{1}\",\"length\": {2},\"map\": [{3}],\"character\": [{4}]", nameWithNumOfPlayer, end, length, map.ToString(),
                characterInfoStr) + "}";
            return editorDataStr;
        }

        void Awake(){
            if(Instance == null || Instance != this)
            {
                Destroy(Instance);
            }
            Instance = this;
        }

        void Start(){
            map = new MapData();
        }

        public string GetName(){
            return name;
        }

        public void SetName(string newName){
            name = newName;
        }

        public string GetEnd(){
            return end;
        }

        public void SetEnd(string newEnd){
            end = newEnd;
        }

        public int GetLength(){
            return length;
        }

        public void SetLength(int newLength){
            length = newLength;
        }

        public MapData GetMapData(){
            return map;
        }

        public void SetMapdata(MapData newMapData){
            map = newMapData;
        }

        public void SetCharacterInfoList(List<CharacterInfo> infos){
            CharacterInfoList = new List<CharacterInfo>(infos);
        }
        

    }
}