using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    private Vector3 cameraOffset;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    //Called after Update()
    void LateUpdate()
    {
        transform.position = player.transform.position + cameraOffset;
    }
}
