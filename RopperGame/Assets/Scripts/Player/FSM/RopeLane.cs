using UnityEngine;
using System.Collections;

abstract public class RopeLane : State
{
    //Our Neighbour lanes
    protected RopeLane leftLane;
    protected RopeLane rightLane;
    
    protected RopeLane() : base()
    {

    } 

    public void SetLeftLane(RopeLane _lane)
    {
        leftLane = _lane;
    }
    public RopeLane GetLeftLane()
    {
        return leftLane;
    }

    public void SetRightLane(RopeLane _lane)
    {
        rightLane = _lane;
    }
    public RopeLane GetRightLane()
    {
        return rightLane;
    }

}