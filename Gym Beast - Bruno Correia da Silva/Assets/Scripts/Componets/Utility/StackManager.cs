using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public class StackManager
{
    private List<Transform> stack;
    private Transform steadyBase;
    private int stackPointSelect = 0;


    public List<Transform> Stack { get => stack; set => stack = value; }
    public Transform SteadyBase { get => steadyBase; private set => steadyBase = value; }

    public int PointSelect { get => stackPointSelect; private set => stackPointSelect = value; }
    public int PointPrevious { get => Mathf.Clamp(stackPointSelect - 1, 0, stack.Count); }
    public int PointNext { get => Mathf.Clamp(stackPointSelect + 1, 0, stack.Count); }

    public StackManager(Transform steadyBase)
    {
        this.steadyBase = steadyBase;
        stack = new List<Transform>();
        stack.Add(steadyBase);
    }
    public void Push(ref GameObject go)
    {

        //if (stack.Count > 0) {
        //    stack[stack.Count - 1].SetParent(go.transform);
        //}
        //go.transform.SetParent(steadyBase);
        stack.Add(go.transform);
        SelectUp();
    }
    public void SelectUp()
    {
        stackPointSelect = Mathf.Clamp((stackPointSelect + 1) % Stack.Count, 0, Stack.Count);
    }
    public void SelectDown()
    {
        //NOTE: n testei
        stackPointSelect = Mathf.Clamp(stackPointSelect - 1, 0, Stack.Count - 1);
    }
    public Transform GetObj()
    {
        return stack[stackPointSelect];
    }
    public void DropAll(Transform target)
    {
        //n deve está mais funcionando devido as ultimas alterações
        foreach (Transform item in stack)
        {
            item.tag = "Default";
            item.SetParent(target);
        }
        Stack.Clear();
    }
}
