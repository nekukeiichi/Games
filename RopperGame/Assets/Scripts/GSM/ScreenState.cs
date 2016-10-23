using UnityEngine;
using System.Collections;

abstract public class ScreenState
{

    protected ScreenState()
    {

    }

    abstract public void Enter();

    abstract public void Execute();

    abstract public void Exit();

}
