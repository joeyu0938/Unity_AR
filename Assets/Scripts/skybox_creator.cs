using UnityEngine;
using System.IO;
using Superla.RadianceHDR;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;
using System;

public class skybox_creator : MonoBehaviour
{
    public Light global_light;
    public static Material skyboxMaterial;
    public static void skybox_create(byte[] Exr_image_bytes)
    {  
        string fileName = "upload_nolight.exr";
        //Texture2D tex = new Texture2D(512, 256, TextureFormat.RGBA32, false);
        string path = "Assets/Resources";
        
        //if (!Directory.Exists(path))
        //{
        //    Directory.CreateDirectory(path);
        //}
        //Resources.UnloadUnusedAssets();
        string filePath = path + "/" + fileName;
        //string filePath_2 = path + "/" + "upload_nolight";
        //Debug.Log(filePath);
        //File.WriteAllBytes(filePath, Exr_image_bytes);
        RadianceHDRTexture hdr = new RadianceHDRTexture(Exr_image_bytes);
        Texture2D tex = hdr.texture;
        
        Debug.Log("Test Success");
        skyboxMaterial = new Material(Shader.Find("Skybox/Panoramic"));
        skyboxMaterial.SetTexture("_MainTex", tex);
        RenderSettings.skybox = skyboxMaterial;
        RenderSettings.skybox.SetFloat("_Exposure", 1.8f);
        RenderSettings.skybox.SetFloat("_Rotation", 90f);
        DynamicGI.UpdateEnvironment();
    }

}
