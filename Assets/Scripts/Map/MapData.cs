using System;
using System.Collections.Generic;

namespace EditorLogics
{
    public class MapData
    {
        //map的图片名称，是否考虑添加一个唯一id用于标识
        string background;
        //编辑器使用者在map上放置的物体
        List<ObjectInfo> objects; //平均在150个，但大部分object的message为空字符串
        //碰撞矩阵的大小，目前常量
        const int collideMapSize = 20;//这个变量的定义和下面这行数组初始化应该放到map的初始化函数里，目前临时放在这
        //碰撞矩阵
        bool[,] collideMap = new bool[collideMapSize,collideMapSize];

        public String GetBackground()
        {
            return background;
        }

        public List<ObjectInfo> GetObjects()
        {
            return objects;
        }

        public int GetCollideMapSize()
        {
            return collideMapSize;
        }

        public bool[,] CollideMap
        {
            get => collideMap;
            set => collideMap = value;
        }
        
        public void SetBackGround(String bg)
        {
            this.background = bg;
        }

        public void SetObejcts(List<ObjectInfo> objectInfos)
        {
            objects = new List<ObjectInfo>(objectInfos);
        }
        
        public override string ToString()
        {
            return string.Format("background: {0},collide_map: {1},object: {2}", background, collideMap, objects);
        }
    }
}