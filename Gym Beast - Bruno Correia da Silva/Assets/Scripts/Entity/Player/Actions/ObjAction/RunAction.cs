using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class RunAction : IAction
    {
        private PlayerController player;

        public const float speedRotation = 15;
        public const float speed = 10;
        public RunAction(PlayerController player)
        {
            this.player = player;
        }
        public void Finished()
        {
        }

        public void Perform()
        {
            MovePlayer();
            MoveCamera();
        }

        private void MovePlayer()
        {
            Vector2 direction = player.InputController.Context.ReadValue<Vector2>();
            Quaternion targetRotation = player.transform.rotation * Quaternion.Euler(0, direction.x * speedRotation, 0);
            direction.y = direction.y == 0 && direction.x != 0 ? 1 : direction.y;
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, targetRotation, Time.fixedDeltaTime * speed);
            player.transform.position += player.transform.forward * speed * Time.fixedDeltaTime * direction.y;
        }

        private void MoveCamera()
        {

        }
        public void Prepare()
        {
            player.ToCollect.BalanceManager.ChangeParentSteadyBaseRun();
        }

        public bool Rules()
        {
            return (ClipName() == "punch" || ClipName() == "getter") && EndAnimation() || player.Machine.CurrentState is IdleState;
        }

        private bool EndAnimation()
        {
            return player.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f;
        }
        private string ClipName()
        {
            return player.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        }
    }
}