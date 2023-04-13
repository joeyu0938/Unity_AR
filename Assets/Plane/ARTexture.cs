using UnityEngine;

public class ARTexture : MonoBehaviour
{
    public Camera arCamera;
    private Material PlaneMaterial;

    void Start()
    {
        PlaneMaterial = GetComponent<Renderer>().material;
        arCamera = GameObject.Find("ARCamera").GetComponent<Camera>();
        PlaneMaterial.mainTexture = arCamera.targetTexture;
    }
}