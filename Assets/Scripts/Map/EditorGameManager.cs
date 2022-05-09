using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace EditorLogics
{
    public class EditGameManager
    {
        public static void SaveDataJsonFile(MapData mapData,String jsonFilePath)
        {
            String jsonString = JsonMapper.ToJson(mapData);
            String jsonFile = jsonFilePath;  
            
            File.WriteAllText(jsonFile, jsonString, System.Text.Encoding.UTF8);
        }

        public static String ReadJsonFile(String jsonFilePath)
        {
            //string jsonfile = "D://testJson.json";//JSON文件路径
 
            using (System.IO.StreamReader file = System.IO.File.OpenText(jsonFilePath))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);
                    String jsonString = o.ToString();
                    return jsonString;
                }
            }
        }


        public static void SendJsonByHttpPost(String jsonFilePath)
        {
            String jsonDataPost = ReadJsonFile(jsonFilePath);
            WWW www = new WWW("http://52.71.182.98/game_info_post/", Encoding.UTF8.GetBytes(jsonDataPost));

            while (!www.isDone)
            {
                Debug.Log("wait");
            }

            if (www.error != null)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(www.text);
//取数据1
                MapData msgJsonRecieve = JsonMapper.ToObject<MapData>(www.text);

                Debug.Log(msgJsonRecieve.ToString());
//取数据2
                JsonData jsonDataGet = JsonMapper.ToObject(www.text);
                Debug.Log(jsonDataGet.ToString());
            }
        }
    }
}