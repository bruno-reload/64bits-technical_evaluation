using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCollect : MonoBehaviour
{
    public Transform steadyBaseRun;
    public Transform steadyBaseIdle;
    private GameObject readyToCollect;
    private BalanceManager balanceManager;
    public trackMoviment trackMoviment;
    public List<Transform> debug;


    [SerializeField] public BalanceManager BalanceManager { get { return balanceManager; } }
    private void Awake()
    {
        PlayerController player = GetComponent<PlayerController>();
        balanceManager = new BalanceManager(new StackManager(steadyBaseIdle), player);
        balanceManager.SteadyBaseRun = steadyBaseRun;
        balanceManager.SteadyBaseIdle = steadyBaseIdle;
        foreach (Transform item in debug)
        {
            readyToCollect = item.gameObject;
            Collected();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            readyToCollect = other.gameObject;
        }
    }

    public void Collected()
    {
        if (readyToCollect != null)
        {
            balanceManager.Stack.Push(ref readyToCollect);
            readyToCollect.gameObject.tag = "Untagged";
            balanceManager.RestTransforms();
            readyToCollect = null;
        }
    }

    private void FixedUpdate()
    {
        balanceManager.Update();
    }

}
