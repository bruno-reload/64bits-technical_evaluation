using UnityEngine;

[RequireComponent(typeof(StateMachine))]

public class PlayerController : MonoBehaviour
{
    private StateMachine machine;
    private InputController inputController;
    private StateFactory stateFactory;
    private Animator animator;
    private ActionFactory action;
    private ToCollect toCollect;

    public InputController InputController { get => inputController; }
    public Animator Animator { get => animator; }
    public StateMachine Machine { get => machine; }
    public ActionFactory Action { get => action; }
    public ToCollect ToCollect { get => toCollect; }
    private void Awake()
    {
        inputController = new InputController();
        machine = GetComponent<StateMachine>();
        stateFactory = new StateFactory(this);
        animator = GetComponent<Animator>();
        action = new ActionFactory(this);
        toCollect = GetComponent<ToCollect>();
    }

    public void TryPunch()
    {
        if (inputController.Punch && action.punch.Rules())
        {
            machine.ChangeState(stateFactory.punch);
        }
    }
    public void TryRun()
    {
        if (inputController.Run && action.run.Rules())
        {
            machine.ChangeState(stateFactory.run);
        }
    }
    public void TryGetter()
    {
        if (inputController.Getter && action.getter.Rules())
        {
            machine.ChangeState(stateFactory.getter);
            toCollect.Collected();
        }
    }
    public void TryIdle()
    {
        if (!inputController.Run && !inputController.Getter && !inputController.Punch && action.idle.Rules())
        {
            machine.ChangeState(stateFactory.idle);
        }
    }
}
