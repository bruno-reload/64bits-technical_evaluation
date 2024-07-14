using UnityEngine;

public class IdleState : BaseState, IState
{
    public IdleState(PlayerController player)
    {
        _playerController = player;
    }
    public void Enter()
    {
        _playerController.Animator.Play("idle");
        _playerController.Action.idle.Prepare();
    }

    public void Exit()
    {
        _playerController.Action.idle.Finished();
    }

    public void FixedUpdate()
    {
        _playerController.Action.idle.Perform();
    }

    public void Update()
    {
        _playerController.TryGetter();
        _playerController.TryPunch();
        _playerController.TryRun();
    }
}
