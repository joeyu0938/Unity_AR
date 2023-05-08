using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCount : MonoBehaviour
{
    public  GameObject targetObject;
    public Material MyMaterial;

    void Update()
    {
        if (targetObject != null)
        {
            Renderer renderer = targetObject.GetComponent<Renderer>();
            if (renderer != null && renderer.enabled)
            {
                int lightCount = 0;
                // 遍歷所有光源
                foreach (Light light in FindObjectsOfType<Light>())
                {
                    // 計算光源對物體的影響
                    if (light.isActiveAndEnabled && light.enabled && light.gameObject.activeInHierarchy)
                    {
                        float distance = Vector3.Distance(light.transform.position, targetObject.transform.position);
                        if (distance < light.range)
                        {
                            // 計算光源對物體的影響程度
                            float intensity = light.intensity / Mathf.Pow(distance, 2);
                            lightCount++;
                        }
                    }
                }
                int a = lightCount;
                MyMaterial.SetFloat("_LightNum", (float)a);
                Debug.Log("The object " + targetObject.name + " is affected by " + lightCount + " lights.");
            }
        }
    }
}
