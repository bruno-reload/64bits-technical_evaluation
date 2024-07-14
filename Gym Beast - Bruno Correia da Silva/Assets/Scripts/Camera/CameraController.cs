using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraController : MonoBehaviour
{
    private PlayerController playerController;
    private CinemachineVirtualCamera camera;
    private CinemachineTargetGroup targetGroup;
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        camera = playerController.Camera.GetComponentInChildren<CinemachineVirtualCamera>();
        targetGroup = playerController.Camera.GetComponentInChildren<CinemachineTargetGroup>();
        foreach (Transform e in playerController.ToCollect.BalanceManager.ObjList)
        {
            targetGroup.AddMember(e, 1, 1);
        }
    }
}
