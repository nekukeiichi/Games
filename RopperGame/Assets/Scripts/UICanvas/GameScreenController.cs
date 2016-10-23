using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScreenController
{
    private static Text scoreTXT;
    private static Scrollbar energyBar;
	
    public static void Kickstart()
    {
        scoreTXT = GamePanel.GetScoreText();
        energyBar = GamePanel.GetEnergyBar();
    }

    public static Scrollbar GetEnergyBar()
    {
        return energyBar;
    }

    public static Text GetScoreText()
    {
        return scoreTXT;
    }
}
