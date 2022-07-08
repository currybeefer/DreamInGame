using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class LevelInfo {
    private string title_;
    private int duration_;
    private string end_;
    private string background_ = "";
    private List<ObjectInfo> objects_;
    private bool[,] collideMap_;

    public LevelInfo()
    {
        Debug.Log("Level Created");
        title_ = "";
        duration_ = 1;
        end_ = "";
        background_ = "";
        objects_ = new List<ObjectInfo>();
        collideMap_ = new bool[0,0];
    }

    public void SetTitle(string title)
    {
        title_ = title;
    }

    public void SetDuration(int duration)
    {
        duration_ = duration;
    }

    public void SetSummary(string summary)
    {
        end_ = summary;
    }

    public void SetBackground(string background)
    {
        background_ = background;
    }

    public void SetObejcts(List<ObjectInfo> objects)
    {
        objects_ = new List<ObjectInfo>(objects);
    }

    public void SetCollideMap(bool[,] collideMap)
    {
        collideMap_ = collideMap;
    }

    public override string ToString()
    {
        String collideMapStr = "", objectsStr = "";
        for (int i = 0; i < collideMap_.GetLength(0); i++)
        {
            for (int j = 0; j < collideMap_.GetLength(1); j++)
            {
                if (collideMap_[i, j])
                {
                    string pos = j + ",";
                    collideMapStr += pos;
                }
            }
            collideMapStr += ";";
        }
        for (int i = 0; i < objects_.Count; i++)
        {
            objectsStr += "{" + objects_[i].ToString() + "},";
        }
        if (objectsStr != "")
        {
            objectsStr = objectsStr.Substring(0, objectsStr.Length - 1);
        }
        String levelStr = "{" + string.Format("\"title\": \"{0}\",\"duration\": \"{1}\",\"end\": \"{2}\",\"background\": \"{3}\",\"collide_map\": \"{4}\",\"object\": [{5}]", title_, duration_, end_, background_,
                collideMapStr, objectsStr) + "}";

        return levelStr;
    }
}
