using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IntroScreen : ScreenState {



	public IntroScreen() : base()
	{
		
	}

	public override void Enter()
	{
		//Start (or activate) all assets in the main menu
		//UI
		UIManager.SwitchToIntro();
	}

	public override void Execute()
	{
		

	}

	public override void Exit()
	{

	}
}
