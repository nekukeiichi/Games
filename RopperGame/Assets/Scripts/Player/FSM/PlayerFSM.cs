using UnityEngine;
using System.Collections;

public class PlayerFSM : FSM
{
    private static PlayerFSM pInstance;

    private LLRopeLane llLane;
    private RRRopeLane rrLane;
   //private LRRopeLane lrLane;
    //private RLRopeLane rlLane;


    public RopperGuy climber;

    private PlayerFSM() : base(null)
    {
        llLane = new LLRopeLane();
        rrLane = new RRRopeLane();
       
       // lrLane = new LRRopeLane();
       // rlLane = new RLRopeLane();

        //Add the neighbours
        //Add for LL
        llLane.SetLeftLane(null);
        llLane.SetRightLane(rrLane);
        //Add for LR
        //lrLane.SetLeftLane(llLane);
        //lrLane.SetRightLane(rlLane);
        //Add for RL
        //rlLane.SetLeftLane(lrLane);
       // rlLane.SetRightLane(rrLane);
        //Add for RR
        rrLane.SetLeftLane(llLane);
        rrLane.SetRightLane(null);


        //Set the new current state
        currentState = rrLane;

    }

    private static PlayerFSM GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new PlayerFSM();
        }
        return pInstance;
    }

    public static void MoveToRight()
    {
        //Get the next node
        RopeLane currentLane = (RopeLane)GetInstance().currentState;

        if(currentLane.GetRightLane() != null)
        {
            GetInstance().ChangeState(currentLane.GetRightLane());

            //Execute the state
            GetInstance().currentState.Execute(GetInstance().climber);
        }
        else
        {
            GetInstance().currentState.Execute(GetInstance().climber);
        }
    }

    public static void MoveToLeft()
    {
        //Get the next node
        RopeLane currentLane = (RopeLane)GetInstance().currentState;

        if (currentLane.GetLeftLane() != null)
        {
            GetInstance().ChangeState(currentLane.GetLeftLane());

            //Execute the state
            GetInstance().currentState.Execute(GetInstance().climber);
        }
        else
        {
            GetInstance().currentState.Execute(GetInstance().climber);
        }
    }

    public static void PowerJumpRight()
    {
        RopeLane currentLane = (RopeLane)GetInstance().currentState;

        if(currentLane == GetInstance().llLane)
        {
            while (currentLane.GetRightLane() != null)
            {
                //Move to the right
                currentLane = currentLane.GetRightLane();
            }

            GetInstance().ChangeState(currentLane);

            GetInstance().currentState.Execute(GetInstance().climber);

            //Drain energy as penalty
            GetInstance().climber.DrainEnergy(GameRules.GetHighEnergy());
        }
        else
        {
            MoveToRight();
        }
    }

    public static void PowerJumpLeft()
    {
        RopeLane currentLane = (RopeLane)GetInstance().currentState;

        if (currentLane == GetInstance().rrLane)
        {
            while (currentLane.GetLeftLane() != null)
            {
                //Move to the right
                currentLane = currentLane.GetLeftLane();
            }

            GetInstance().ChangeState(currentLane);

            GetInstance().currentState.Execute(GetInstance().climber);

            //Drain energy as penalty
            GetInstance().climber.DrainEnergy(GameRules.GetHighEnergy());

        }
        else
        {
            MoveToLeft();
        }
    }

    public static void SetRopper(RopperGuy _climber)
    {
        GetInstance().climber = _climber;
    }

    public static void DrainEnergy(float _energy)
    {
        GetInstance().climber.DrainEnergy(_energy);

    }

    public static void ResetRopper()
    {
        GetInstance().currentState = GetInstance().rrLane;

        RopperTree tTree = (RopperTree)GameObjectManager.GetTree(GameObjectType.PLAYER);

        SetRopper(tTree.GetRopperGuy());



        //Reposition the ropper guy
        if (GetInstance().climber != null)
        {
            GetInstance().climber.ForceNewPosition(Vector3.zero);
            GetInstance().climber.gameObject.SetActive(true);
        }
    }

    public static void DeactivateRopper()
    {
        if (GetInstance().climber != null)
        {
            GetInstance().climber.gameObject.SetActive(false);
        }
    }

}
