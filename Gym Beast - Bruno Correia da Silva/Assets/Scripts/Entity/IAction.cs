using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction 
{
    public bool Rules();
    public void Prepare();
    public void Perform();
    public void Finished();
}
