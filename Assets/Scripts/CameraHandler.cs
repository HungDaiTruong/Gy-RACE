using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraHandler : MonoBehaviour
{
    private CinemachineVirtualCamera playerCamera;
    private PlayerLocomotion playerLocomotion;

    [SerializeField]
    private Transform backTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = GetComponent<CinemachineVirtualCamera>();
        playerLocomotion = GetComponentInParent<PlayerLocomotion>();
    }

    // Update is called once per frame
    void Update()
    {
        // FOV widens depending on the vehicle's current speed
        playerCamera.m_Lens.FieldOfView = 90f + ((transform.parent.GetComponent<PlayerLocomotion>().realSpeed) / 5);
    }

    private void FixedUpdate()
    {
        if (playerLocomotion.lookingBackInput)
        {
            if (playerCamera.Follow != backTarget)
            {
                playerCamera.Follow = backTarget;
            }
            else
            {
                playerCamera.Follow = transform.parent;
            }
        }
    }
}
