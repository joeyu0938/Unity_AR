using UnityEngine;
using System.Collections;

public class UpdateRenderTexture : MonoBehaviour
{
    public RenderTexture renderTexture;
    public Camera renderCamera;

    void Update()
    {
        StartCoroutine(UpdateTexture());
    }

    IEnumerator UpdateTexture()
    {
        yield return new WaitForSeconds(0.02f);
        RenderTexture.active = renderTexture;
        renderCamera.Render();
    }
}
