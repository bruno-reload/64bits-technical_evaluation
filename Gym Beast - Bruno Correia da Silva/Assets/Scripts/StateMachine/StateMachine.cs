using UnityEngine;


public class StateMachine : MonoBehaviour
{
    private IState currentState;

    public IState CurrentState { get => currentState; }
    private void Awake()
    {

        currentState = new IdleState(GetComponent<PlayerController>());
    }

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
