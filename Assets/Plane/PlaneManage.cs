using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManage : MonoBehaviour
{
    [SerializeField] private GameObject planeObj = null;
    [SerializeField] private RenderTexture backgroundRT = null;

    private Camera mainCamera = null;
    private Mesh planeMesh = null;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
        //planeMesh = planeObj.GetComponent<MeshFilter>().mesh;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}