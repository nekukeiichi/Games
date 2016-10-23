using UnityEngine;
using System.Collections;
using System;

public class GameOverCommand : ICommand
{

	public GameOverCommand()
    {

    }

    public override void Execute()
    {
        //Calculate the final Score

        //Go to Game Over Screen
        GameStateMachine.EnterGOScreen();
    }
}
