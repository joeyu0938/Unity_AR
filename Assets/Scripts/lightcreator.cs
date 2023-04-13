using UnityEngine;
using System.IO;
using System.Collections.Generic;
using static json_transfer;
using System;
using TMPro;
using System.Collections;
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
//�B�z�Ӧ�json_transfer��string��ƨåB��json�i��ѪR�åͦ�����
public class lightcreator : MonoBehaviour
{
    public static GameObject pointLightPrefab;

    public static void lightscreate()
    {
        
        LightDataList lights = JsonUtility.FromJson<LightDataList>(jsonResult);
        Debug.Log(jsonResult);
        int cenx, ceny;
        double theta, phi;
        for (int i = 0; i < lights.lightDataList.Count; i++)
        {
            float depth = 15;
            LightData lightData = lights.lightDataList[i];
            pointLightPrefab = new GameObject("Generated Light");
            //�K�[�s��light
            Light lightComponent = pointLightPrefab.AddComponent<Light>();
            //�K�[�ݩ�
            lightComponent.type = LightType.Point;
            if (lightData.type == "point")
            {
                
                lightComponent.shadows = LightShadows.Hard;
            }
            else
            {
                lightComponent.shadows = LightShadows.Soft;
            }
            cenx = lightData.position[0];
            ceny = lightData.position[1];
            var j_trans = Convert.ToSingle(ceny);
            var i_trans = Convert.ToSingle(cenx);
            depth -= (depth * lightData.depth); //�V�񪺿O lightData.depth �V�j �]���n�۴�
            theta = Math.PI - ((j_trans / 512) * 2 * Math.PI);
            phi = (Math.PI / 2) - (i_trans / 256) * Math.PI;
            lightComponent.transform.position = new Vector3(Convert.ToSingle(depth * Math.Cos(phi) * Math.Cos(theta)), Convert.ToSingle(depth * Math.Sin(phi)), Convert.ToSingle(depth * Math.Cos(phi) * Math.Sin(theta)));
            lightComponent.color = new Color(lightData.color[0]/255, lightData.color[1]/255, lightData.color[2]/255);
            lightComponent.intensity = lightData.intensity;
            double temp = depth/2;
            float offset = (float) temp;
            lightComponent.range = depth+offset;// * lightComponent.intensity;
        }
    }
}
