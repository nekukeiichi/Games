using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePanel : MonoBehaviour
{
    public Scrollbar energyBarSB;
    public Text scoreTXT;

    private static Scrollbar energyBar;
    private static Text score;

	// Use this for initialization
	void Start ()
    {
        energyBar = energyBarSB;
        score = scoreTXT;

        GameScreenController.Kickstart();
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public static Scrollbar GetEnergyBar()
    {
        return energyBar;
    }

    public static Text GetScoreText()
    {
        return score;
    }
}
