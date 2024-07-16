using UnityEngine;
namespace Player
{
    public class IdleState : BaseState, IState
    {
        public IdleState(IEntity player)
        {
            _playerController = player;
        }
        public void Enter()
        {
            _playerController.Animator.Play("idle");
            (_playerController as PlayerController).Action.idle.Prepare();
        }

        public void Exit()
        {
            (_playerController as PlayerController).Action.idle.Finished();
        }

        public void FixedUpdate()
        {
            (_playerController as PlayerController).Action.idle.Perform();
        }

        public void Update()
        {
            (_playerController as PlayerController).TryGetter();
            (_playerController as PlayerController).TryPunch();
            (_playerController as PlayerController).TryRun();
        }
    }
}