using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static lightcreator;


public class Management : MonoBehaviour
{
    public Material myMaterial;

    void Update()
    {
        int a = lights.lightDataList.Count;
        myMaterial.SetFloat("_LightNum", (float)a);
        //int b = lightCount;
        //Debug.Log(lights.lightDataList.Count);
    }
}