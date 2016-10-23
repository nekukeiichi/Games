using UnityEngine;
using System.Collections;
using System;

public class CenterRopeLane : RopeLane
{
    public override void Enter(TreeLeaf _object)
    {
        
    }

    public override void Execute(TreeLeaf _object)
    {
        //Cast the object as Ropper guy
        RopperGuy guy = (RopperGuy)_object;

        //Place at the center
        guy.transform.position = Vector3.zero;
        //Switch the Sprite

    }

    public override void Exit(TreeLeaf _object)
    {
        
    }
}
