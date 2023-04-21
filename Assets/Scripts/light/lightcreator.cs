using UnityEngine;
using System.IO;
using System.Collections.Generic;
using static json_transfer;
using System;
using TMPro;
using System.Collections;
using JetBrains.Annotations;

public class LightDataList
{
    public List<LightData> lightDataList;
}

[System.Serializable]
public class LightData
{
    public string type;
    public int[] position;
    public float[] color;
    public float intensity;
    public float depth;
}
//處理來自json_transfer的string資料並且對json進行解析並生成光源
public class lightcreator : MonoBehaviour
{
    public static GameObject pointLightPrefab;
    public static LightDataList lights;
    public static Material material;

    public static void lightscreate()
    {
        
        lights = JsonUtility.FromJson<LightDataList>(jsonResult);
        int cenx, ceny;
        double theta, phi;
        Shader.SetGlobalInt("_lightNum", lights.lightDataList.Count);
        //Material.SetInteger("_lightNum", lights.lightDataList.Count);
        for (int i = 0; i < lights.lightDataList.Count; i++)   
        {
            float depth = (float)1;
            LightData lightData = lights.lightDataList[i];
            pointLightPrefab = new GameObject("Generated Light");
            //添加新的light
            Light lightComponent = pointLightPrefab.AddComponent<Light>();
            //添加屬性
            lightComponent.type = LightType.Point;
            if (lightData.type == "point")
            {
                lightComponent.renderMode = LightRenderMode.ForcePixel;
                lightComponent.shadows = LightShadows.Hard;
            }
            else
            {
                lightComponent.renderMode = LightRenderMode.ForcePixel;
                lightComponent.shadows = LightShadows.Soft;
            }
            cenx = lightData.position[0];
            ceny = lightData.position[1];
            var j_trans = Convert.ToSingle(ceny);
            var i_trans = Convert.ToSingle(cenx); 
            depth *= lightData.depth;
            if (depth > 10) depth = 10;
            theta = Math.PI - ((j_trans / 512) * 2 * Math.PI);
            phi = (Math.PI / 2) - (i_trans / 256) * Math.PI; 
            //lightComponent.transform.position = new Vector3(Convert.ToSingle(depth * Math.Cos(phi) * Math.Sin(theta)), Convert.ToSingle(depth * Math.Sin(phi)), Convert.ToSingle(depth * Math.Cos(phi) * Math.Cos(theta)));
            lightComponent.transform.position = new Vector3(Convert.ToSingle(depth * Math.Cos(phi) * Math.Cos(theta)), Convert.ToSingle(depth * Math.Sin(phi)), Convert.ToSingle(depth * Math.Cos(phi) * Math.Sin(theta)));
            lightComponent.transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0f, 1f, 0f), -90f);
            lightComponent.color = new Color(lightData.color[0]/255, lightData.color[1]/255, lightData.color[2]/255);
            lightComponent.intensity = lightData.intensity * (1+depth * depth * (float)0.001) *0.6f;
            //-----------------------------------------------------------------------------------------
            if (lightData.type == "point") lightComponent.range = (float)Math.Sqrt((lightComponent.intensity - (float)0.001) * 100);// * lightComponent.intensity;
            else lightComponent.range = (float)Math.Sqrt((lightComponent.intensity * 4 - (float)0.001) * 100);
        }
    }
}
