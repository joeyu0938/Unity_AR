using UnityEngine;
using System;
using UnityEngine.Networking;
using System.Collections;
using static skybox_creator;
using UnityEditor;
//�����}���|�Y�i�o��exr�����
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

        yield return www.SendWebRequest(); // ���ݺ����ШD����

        if (www.result == UnityWebRequest.Result.Success)
        {
            Exr_image_bytes = www.downloadHandler.data;
            //�U����TEST��
            //System.IO.File.WriteAllBytes(TargetPath + "/upload_nolight.exr", Exr_image_bytes);
            
            Debug.Log("EXR �U�����\: " + filePath);
        }
        else
        {
            Debug.LogError("EXR �U������: " + www.error);
        }
        Debug.Log(Exr_image_bytes);
        skybox_create(Exr_image_bytes);
    }

    [Obsolete]
    void Start()
    {
        
        texture = new Texture2D(2, 2); // ��l�Ư��z
        StartCoroutine(downloadImage());
    }
}