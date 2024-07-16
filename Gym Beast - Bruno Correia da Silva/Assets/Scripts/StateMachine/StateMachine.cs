using UnityEngine;

[System.Serializable]
public class StateMachine : MonoBehaviour
{
    private IState currentState;

    public IState CurrentState { get => currentState; set => currentState = value; }

    void Update()
    {
        //Debug.Log("update " + currentState);
        currentState.Update();
    }

    void FixedUpdate()
    {
        //Debug.Log("fixed update " + currentState);
        currentState.FixedUpdate();
    }

    public void ChangeState(IState next)
    {
        currentState.Exit();
        currentState = next;
        currentState.Enter();
    }
}
