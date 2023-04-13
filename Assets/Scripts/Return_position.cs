using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;
using static PlaceOnPlane;
using static SpawnableManager;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UIElements;

public class Return_position : MonoBehaviour
{
   
    private  TextMeshProUGUI positionText;
    
    // Start is called before the first frame update
    void Start()
    {
        positionText = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (_spawnedObject != null)
        {
            Vector3 position = _spawnedObject.transform.position;
            positionText.text=string.Format("Position: ({0:F2}, {1:F2}, {2:F2})", position.x, position.y, position.z);
        }

    }
}
