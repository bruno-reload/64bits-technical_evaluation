using UnityEngine;

public class PunchState : BaseState,  IState
{
    public PunchState(PlayerController player)
    {
        _playerController = player;
    }
    public void Enter()
    {
        _playerController.Animator.Play("punch");
        _playerController.Action.punch.Prepare();
    }

    public void Exit()
    {
        _playerController.Action.punch.Finished();
    }

    public void FixedUpdate()
    {
        _playerController.Action.punch.Perform();
    }

    public void Update()
    {
        _playerController.TryGetter();
        _playerController.TryIdle();
        _playerController.TryRun();
    }
}
