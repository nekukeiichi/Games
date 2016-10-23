using UnityEngine;
using System.Collections;
using System;

public class GameOverScreen : ScreenState
{
	private RefillEnergyCommand energyRefill;

    public GameOverScreen() : base()
    {
		energyRefill = new RefillEnergyCommand();
    }

    public override void Enter()
    {
        //UI
        UIManager.SwitchToGameOver();
		EventManager.AddEvent(energyRefill, 0.0f);

        ScoreManager.ShowScores();
    }

    public override void Execute()
    {
        
    }

    public override void Exit()
    {
		EventManager.StopEventTimer();
    }
}
