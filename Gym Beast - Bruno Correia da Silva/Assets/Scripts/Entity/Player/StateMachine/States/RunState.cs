using System.Runtime.InteropServices;
using UnityEngine;
namespace Player
{
    public class RunState : BaseState, IState
    {
        public RunState(IEntity player)
        {
            _playerController = player;
        }
        public void Enter()
        {
            (_playerController as PlayerController).Action.run.Prepare();
            _playerController.Animator.Play("run");
        }

        public void Exit()
        {
            (_playerController as PlayerController).Action.run.Finished();
        }

        public void FixedUpdate()
        {
            (_playerController as PlayerController).Action.run.Perform();
        }


        public void Update()
        {
            (_playerController as PlayerController).TryGetter();
            (_playerController as PlayerController).TryPunch();
            (_playerController as PlayerController).TryIdle();
        }
    }
}
