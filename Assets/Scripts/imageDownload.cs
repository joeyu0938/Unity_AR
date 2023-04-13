using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;
using static skybox_creator;
using UnityEditor;
//更改網址路徑即可得到exr的資料
public class imageDownload : MonoBehaviour
{

    public Texture2D texture;
    public Texture2D image;
    public byte[] Exr_image_bytes;

    [Obsolete]
    IEnumerator downloadImage()
    {
        //yield return new WaitForSeconds(20);
        yield return new WaitForSeconds(50);
        Debug.Log("success to download");
        string TargetPath = "Assets/skybox/";
        string filePath = TargetPath + "/upload_nolight.exr";
        string url = "http://120.126.151.82:5000/download/HDR_nolight/upload_nolight.hdr";
        
        UnityWebRequest www = UnityWebRequest.Get(url);
        Debug.Log(www.url);

        yield return www.SendWebRequest(); // 等待網路請求完成

        if (www.result == UnityWebRequest.Result.Success)
        {
            Exr_image_bytes = www.downloadHandler.data;
            //下載為TEST用
            //System.IO.File.WriteAllBytes(TargetPath + "/upload_nolight.exr", Exr_image_bytes);
            
            Debug.Log("EXR 下載成功: " + filePath);
        }
        else
        {
            Debug.LogError("EXR 下載失敗: " + www.error);
        }
        Debug.Log(Exr_image_bytes);
        skybox_create(Exr_image_bytes);
    }

    [Obsolete]
    void Start()
    {
        
        texture = new Texture2D(2, 2); // 初始化紋理
        StartCoroutine(downloadImage());
    }
}