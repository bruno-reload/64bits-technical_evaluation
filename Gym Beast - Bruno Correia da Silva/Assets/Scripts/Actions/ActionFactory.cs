using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionFactory 
{
    public IAction run;
    public IAction getter;
    public IAction punch;
    public IAction idle;


    public ActionFactory(PlayerController player)
    {
        run = new RunAction(player);
        getter = new GetterAction(player);
        punch = new PunchAction(player);
        idle = new IdleAction(player);
    }
}
