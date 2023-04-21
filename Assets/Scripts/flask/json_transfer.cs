using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEngine.UIElements;
using System.Xml.Serialization;
using System;
using TMPro;
using UnityEngine.SceneManagement;
using static lightcreator;
//讀取特定資料夾中的json檔案並使用static string 儲存以便lightcreator使用
public class json_transfer : MonoBehaviour
{

    public static string jsonResult;
    public string url = "http://120.126.151.82:5000/download/data.json";
    //public string test = "C:/Users/User/Desktop/TEST";
    IEnumerator downloadjson()
    {
        yield return new WaitForSeconds(50);
        //string filePath = test + "/Result.json";
        //yield return new WaitForSeconds(20);
        UnityWebRequest www = UnityWebRequest.Get(url);
        
        
        yield return www.SendWebRequest(); // 等待網路請求完成

        if (www.result == UnityWebRequest.Result.Success)
        {
            jsonResult = www.downloadHandler.text;
            //Add these two lines


            Debug.Log("JSON 下載成功: ");
        }
        else
        {
            Debug.LogError("JSON 下載失敗: " + www.error);
        }
        Debug.Log(jsonResult);
        lightscreate();
    }
    void Start()
    {
        StartCoroutine(downloadjson());
    }
}
