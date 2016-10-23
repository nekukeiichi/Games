using UnityEngine;
using System.Collections;

public class RopperEnergy
{
    //Variables
    //Max amount of energy
    private float maxEnergy;

    private RopperAnimator parentAnim;

    //Current Amount of energy
    private float currentEnergy;

    private GameOverCommand goComm;

    public RopperEnergy(RopperAnimator _anim)
    {
        //Maximum amount of energy (this number might change)
        maxEnergy = 12.0f;

        //Current energy is equal to max
		currentEnergy = maxEnergy/2.0f;

        parentAnim = _anim;

        goComm = new GameOverCommand();
    }

    public void DrainEnergy(float _amount)
    {
        if (currentEnergy > 0.0f)
        {
            currentEnergy -= _amount;
            UpdateBar();
        }
        else
        {
            //Game over bitch ò.ó
            parentAnim.Animate("Falling");
            EventManager.AddEvent(goComm, 0.3f);
        }

    }

	public float GetCurrentEnergy()
	{
		return currentEnergy;
	}

    public void RecoverEnergy(float _amount)
    {
        currentEnergy += _amount;

        //Clamp it
        if(currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        UpdateBar();
    }

    public void ResetEnergy()
    {
		currentEnergy = (maxEnergy/2);
        UpdateBar();
    }

    private void UpdateBar()
    {
        //Refill bar
        if(GameScreenController.GetEnergyBar() != null)
        {
            GameScreenController.GetEnergyBar().size = (currentEnergy) / maxEnergy;
        }
    }
	
}
