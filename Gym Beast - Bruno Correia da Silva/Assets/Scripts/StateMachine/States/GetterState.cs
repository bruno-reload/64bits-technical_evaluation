using UnityEngine;

public class GetterState : BaseState, IState
{
    public GetterState(PlayerController player)
    {
        _playerController = player;

    }
    public void Enter()
    {
        _playerController.Action.getter.Prepare();
        _playerController.Animator.Play("getter");
    }

    public void Exit()
    {
        _playerController.Action.getter.Finished();
    }

    public void FixedUpdate()
    {
        _playerController.Action.getter.Perform();
    }

    public void Update()
    {
        _playerController.TryPunch();
        _playerController.TryIdle();
        _playerController.TryRun();
    }
}
