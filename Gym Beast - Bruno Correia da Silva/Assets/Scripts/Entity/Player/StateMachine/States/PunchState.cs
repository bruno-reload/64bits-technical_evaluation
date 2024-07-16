using Player;
using UnityEngine;

public class PunchState : BaseState,  IState
{
    public PunchState(IEntity player)
    {
        _playerController = player;
    }
    public void Enter()
    {
        _playerController.Animator.Play("punch");
        (_playerController as PlayerController).Action.punch.Prepare();
    }

    public void Exit()
    {
        (_playerController as PlayerController).Action.punch.Finished();
    }

    public void FixedUpdate()
    {
        (_playerController as PlayerController).Action.punch.Perform();
    }

    public void Update()
    {
        (_playerController as PlayerController).TryGetter();
        (_playerController as PlayerController).TryIdle();
        (_playerController as PlayerController).TryRun();
    }
}
