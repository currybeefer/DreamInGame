using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class LevelInfo {
    private string title;
    private int duration;
    private string summary;
    string background = "";
    private List<ObjectInfo> objects;
    bool[,] collideMap;

    int COLLIDE_MAP_SIZE = 32;
}
