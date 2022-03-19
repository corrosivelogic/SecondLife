using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaymodeAutoSetup : MonoBehaviour
{
    public GameObject cameraRig;
    private Camera activeCamera;
    void Start()
    {
        Destroy(Camera.main.gameObject);
        cameraRig.transform.SetParent(null);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
