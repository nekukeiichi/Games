using UnityEngine;
using System.Collections;
using System;

public class RefillEnergyCommand : ICommand
{

    public RefillEnergyCommand()
    {
        
    }

    public override void Execute()
    {
        //Get the energy bar
        RopperTree tTree = (RopperTree)GameObjectManager.GetTree(GameObjectType.PLAYER);
        //reset Energy
        tTree.GetRopperGuy().ResetEnergy();
    }
}
