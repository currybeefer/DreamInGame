using System;
using System.Collections.Generic;
using ExitGames.Client.Photon.StructWrapping;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

namespace EditorLogics
{
    public class MapData
    {
        //map的图片名称，是否考虑添加一个唯一id用于标识
        string background = "";
        //编辑器使用者在map上放置的物体
        List<ObjectInfo> objects; //平均在150个，但大部分object的message为空字符串
        //碰撞矩阵的大小，目前常量
        int collideMapSize = 20;//这个变量的定义和下面这行数组初始化应该放到map的初始化函数里，目前临时放在这
        //碰撞矩阵
        bool[,] collideMap;

        public String GetBackground()
        {
            return background;
        }

        public List<ObjectInfo> GetObjects()
        {
            return objects;
        }

        public bool[,] GetCollideMap(){
            return collideMap;
        }

        public int GetCollideMapSize()
        {
            return collideMapSize;
        }

        public void SetCollideMapSize(int size)
        {
            collideMapSize = size;
        }

        public void SetCollideMap(bool[,] newCollideMap){
            collideMap = newCollideMap;
        }
        
        public void SetBackground(String bg)
        {
            background = bg;
        }

        public void SetObejcts(List<ObjectInfo> objectInfos)
        {
            objects = new List<ObjectInfo>(objectInfos);
        }

        
        public override string ToString()
        {
            String collideMapStr = "",objectsStr = "";
            for (int i=0; i < collideMap.GetLength(0); i++)
            {
                for (int j = 0; j < collideMap.GetLength(1); j++)
                {
                    if (collideMap[i, j])
                    {
                        string pos = j + ",";
                        collideMapStr += pos;
                    }
                }
                collideMapStr += ";";
            }
            for (int i = 0; i < objects.Count; i++)
            {
                objectsStr += "{" + objects[i].ToString() + "},";
            }
            if(objectsStr != ""){
                objectsStr = objectsStr.Substring(0, objectsStr.Length - 1);
            }
            String mapStr = "{" + string.Format("\"background\": \"{0}\",\"collide_map\": \"{1}\",\"object\": [{2}]", background,
                collideMapStr, objectsStr) + "}";

            return mapStr;
        }
    }
}