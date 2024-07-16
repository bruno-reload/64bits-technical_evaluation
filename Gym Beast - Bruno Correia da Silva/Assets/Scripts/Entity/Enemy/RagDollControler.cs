using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class RagDollControler : MonoBehaviour
{
    private Animator anim;
    public Rigidbody hip;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();    
    }

    public void DisableRagDoll()
    {
        anim.enabled = false;
    }
    public void enableRagDoll()
    {
        hip.isKinematic = false;
        anim.enabled = false;
    }
    public void Drag()
    {
        hip.isKinematic = true;
    }
}
