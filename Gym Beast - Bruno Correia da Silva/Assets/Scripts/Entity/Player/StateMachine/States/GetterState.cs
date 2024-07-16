using UnityEngine;
namespace Player {
    public class GetterState : BaseState, IState
    {
        public GetterState(IEntity player)
        {
            _playerController = player;

        }
        public void Enter()
        {
            (_playerController as PlayerController).Action.getter.Prepare();
            _playerController.Animator.Play("getter");
        }

        public void Exit()
        {
            (_playerController as PlayerController).Action.getter.Finished();
        }

        public void FixedUpdate()
        {
            (_playerController as PlayerController).Action.getter.Perform();
        }

        public void Update()
        {
            (_playerController as PlayerController).TryPunch();
            (_playerController as PlayerController).TryIdle();
            (_playerController as PlayerController).TryRun();
        }
    }
}
