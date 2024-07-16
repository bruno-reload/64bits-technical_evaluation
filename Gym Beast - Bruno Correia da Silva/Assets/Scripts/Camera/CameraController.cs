using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using Player;

public class CameraController : MonoBehaviour
{
    public  PlayerController playerController;
    private CinemachineVirtualCamera camera;
    private CinemachineTargetGroup targetGroup;

    void Start()
    {
        camera = GetComponentInChildren<CinemachineVirtualCamera>();
        targetGroup = GetComponentInChildren<CinemachineTargetGroup>();
        playerController.ToCollect.BalanceManager.newItem.AddListener(NewItem);
    }

    private void NewItem(Transform obj)
    {
        targetGroup.AddMember(obj, 1, 1);
    }
}
