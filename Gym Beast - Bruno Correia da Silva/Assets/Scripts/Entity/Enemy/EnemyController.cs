using Enemy;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class EnemyController : MonoBehaviour, IEntity
{
    private StateMachine machine;
    private StateFactory stateFactory;
    private ActionFactory actionFactory;
    private Animator animator;
    private RagDollControler ragDollControler;

    public Animator Animator { get => animator; }
    public StateMachine Machine { get => machine; }
    public StateFactory StateFactory { get => stateFactory; }
    public ActionFactory Action { get => actionFactory; }
    public RagDollControler RagDoll { get => ragDollControler; }
    public Transform World { get => transform; }


    private void Awake()
    {
        machine = GetComponent<StateMachine>();
        stateFactory = new StateFactory(this);
        animator = GetComponentInChildren<Animator>();
        actionFactory = new ActionFactory(this);
        ragDollControler = GetComponentInChildren<RagDollControler>();
        machine.CurrentState = stateFactory.idle;
    }
    public void TryIdle()
    {
        if (actionFactory.idle.Rules())
        {
            machine.ChangeState(stateFactory.idle);
        }
    }
    public void TryRun()
    {
        if (actionFactory.run.Rules())
        {
            machine.ChangeState(stateFactory.move);
        }
    }
    public void TryChangeDir()
    {
        if (actionFactory.changeDir.Rules())
        {
            machine.ChangeState(stateFactory.changeDir);
        }
    }
    public void TryDead()
    {
        if (actionFactory.dead.Rules())
        {
            machine.ChangeState(stateFactory.dead);
        }
    }
}
