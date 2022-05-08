using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using LitJson;

namespace EditorLogics
{
    public class GameManager
    {
        void SaveDataJsonFile(MapData mapData)
        {
            String jsonString = JsonMapper.ToJson(mapData);
            String jsonFile = "";
            
            File.WriteAllText(jsonFile, jsonString, System.Text.Encoding.UTF8);
        }
    }
}