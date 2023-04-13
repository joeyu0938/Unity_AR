using UnityEngine;
using System.IO;
using Superla.RadianceHDR;
using UnityEngine.SocialPlatforms;

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
        RenderSettings.skybox.SetFloat("_Exposure", (float)1.4);
        DynamicGI.UpdateEnvironment();
        // Resources.UnloadAsset(tex);

        //下面可以跑 不過是以檔案型態 上面位元組一直有問題猜測是有隱藏的header

        //AssetDatabase.Refresh();
        //AssetDatabase.ImportAsset("Assets/skybox/upload_nolight.exr");

        //Texture2D tex = (Texture2D)AssetDatabase.LoadAssetAtPath<Texture2D>("Assets/skybox/upload_nolight.exr");
        //Material skyboxMaterial = new Material(Shader.Find("Skybox/Panoramic"));
        //skyboxMaterial.SetTexture("_MainTex", tex);

        //Debug.Log("sky_create");
        //RenderSettings.skybox = skyboxMaterial;
    }

}
