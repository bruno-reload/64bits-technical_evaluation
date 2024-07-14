using System.Runtime.InteropServices;
using UnityEngine;

public class RunState : BaseState, IState
{
    public RunState(PlayerController player)
    {
        _playerController = player;
    }
    public void Enter()
    {
        _playerController.Action.run.Prepare();
        _playerController.Animator.Play("run");
    }

    public void Exit()
    {
        _playerController.Action.run.Finished();
    }

    public void FixedUpdate()
    {
        _playerController.Action.run.Perform();
    }


    public void Update()
    {
        _playerController.TryGetter();
        _playerController.TryPunch();
        _playerController.TryIdle();
    }
}
