using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "trackMoviment", menuName = "ScriptableObjects/trackMoviment", order = 1)]
public class trackMoviment : ScriptableObject
{
    public float speedMoviment;
    public float speedLookt;

    public float maxDistanceToDrag;

}