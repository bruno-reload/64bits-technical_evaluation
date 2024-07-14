using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : IAction
{
    private PlayerController player;
    public IdleAction(PlayerController player)
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
        player.ToCollect.BalanceManager.ChangeParentSteadyBaseIdle();
    }

    public bool Rules()
    {
        return (ClipName() == "punch" || ClipName() == "getter") && EndAnimation() || player.Machine.CurrentState is RunState;
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
