using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    private CinemachineVirtualCamera playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        // FOV widens depending on the vehicle's current speed
        playerCamera.m_Lens.FieldOfView = 90f + ((transform.parent.GetComponent<PlayerLocomotion>().realSpeed) / 5);
    }
}
