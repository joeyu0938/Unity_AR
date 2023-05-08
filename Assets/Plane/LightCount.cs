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
                // �M���Ҧ�����
                foreach (Light light in FindObjectsOfType<Light>())
                {
                    // �p������磌�骺�v�T
                    if (light.isActiveAndEnabled && light.enabled && light.gameObject.activeInHierarchy)
                    {
                        float distance = Vector3.Distance(light.transform.position, targetObject.transform.position);
                        if (distance < light.range)
                        {
                            // �p������磌�骺�v�T�{��
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
