using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using LitJson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace EditorLogics
{
    public class EditorGameManager
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


        public static void SendJsonByHttpPost(String jsonDataPost)
        {
            //Debug.Log("测试Post");
            //String jsonDataPost = ReadJsonFile(jsonFilePath);
            String url = "https://api.dreamin.land/game_info_post/";
            Encoding encoding = Encoding.UTF8;
            byte[] buffer = encoding.GetBytes(jsonDataPost);
            HttpsPost(url, buffer);
        }
        
        /// <summary>
        /// HTTPS Post请求
        /// </summary>
        /// <param name="URL">访问地址</param>
        /// <param name="postBytes">携带数据</param>
        /// <returns></returns>
        private static void HttpsPost(string url, byte[] postBytes)
        {
            UnityWebRequest request = new UnityWebRequest(url, "POST");//method传输方式，默认为Get；

            request.uploadHandler = new UploadHandlerRaw(postBytes);//实例化上传缓存器
            request.downloadHandler = new DownloadHandlerBuffer();//实例化下载存贮器
            request.SetRequestHeader("Content-Type", "application/json");//更改内容类型，
            request.SendWebRequest();//发送请求
            
            while (!request.isDone)
            {
                Debug.Log("wait");
            }
            Debug.Log("Status Code: " + request.responseCode);//获得返回值
            if (request.responseCode == 200)//检验是否成功
            {
                string text = request.downloadHandler.text;//打印获得值
                Debug.Log(text);
       
            }
            else
            {
                Debug.Log("post失败了");
                Debug.Log(request.error);
                Debug.Log(request.responseCode);
            }
        }
        
        public bool IsBusy=false;//用于检测是否重复发送
    }
}