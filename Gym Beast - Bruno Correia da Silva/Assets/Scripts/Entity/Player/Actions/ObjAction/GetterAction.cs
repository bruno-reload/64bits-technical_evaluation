using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Player
{
    public class GetterAction : IAction
    {
        private PlayerController player;
        public GetterAction(PlayerController player)
        {
            this.player = player;
        }

        public void Finished()
        {
        }

        public void Perform()
        {
        }

        public void Prepare()
        {
            foreach (var item in player.ToCollect.BalanceManager.ObjList)
            {
                EnemyController enemy = item.GetComponentInParent<EnemyController>();
                if (enemy != null)
                {
                    enemy.RagDoll.Drag();
                }
            }
        }


        public bool Rules()
        {
            return (ClipName() == "punch") && EndAnimation() || player.Machine.CurrentState is IdleState || player.Machine.CurrentState is RunState;
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