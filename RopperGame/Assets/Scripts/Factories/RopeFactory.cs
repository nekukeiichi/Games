using UnityEngine;
using System.Collections;

public class RopeFactory
{

	private RopeFactory()
    {

    }

    public static StrongRope GetStrongRope()
    {
        //Get the Rope tree
        RopeTree ropeTree = (RopeTree)GameObjectManager.GetTree(GameObjectType.ROPE);
        if(ropeTree != null)
        {
            StrongBranch tBranch = (StrongBranch)ropeTree.GetBranch(RopeEnum.STRONG);
            StrongRope tblock = (StrongRope)tBranch.LoanObject();
            if (tblock != null)
            {
                return tblock;
            }
        }

        //If no rope is available, return null
        return null;
    }

    public static WeakRope GetWeakRope()
    {
        //Get the Rope tree
        RopeTree ropeTree = (RopeTree)GameObjectManager.GetTree(GameObjectType.ROPE);
        if (ropeTree != null)
        {
            WeakBranch tBranch = (WeakBranch)ropeTree.GetBranch(RopeEnum.WEAK);
            WeakRope tblock = (WeakRope)tBranch.LoanObject();
            if (tblock != null)
            {
                return tblock;
            }
        }

        //If no rope is available, return null
        return null;
    }

    public static Rope GetRandomRope()
    {
        int ropeID = Random.Range(0, 3);

        if (ropeID == 0)
        {
            //Gett a weak rope
            return GetWeakRope();
        }
        else
        {
            //Get a strong rope
            return GetStrongRope();
        }

        //Something went terribly wrong!!!! ._.
        return null;
    }

    public static void ReturnRope(Rope _rope)
    {
        RopeTree ropeTree = (RopeTree)GameObjectManager.GetTree(GameObjectType.ROPE);
        if (ropeTree != null)
        {
            //Check what type of rope it is
            switch (_rope.GetRopeType())
            {
                case RopeEnum.STRONG:
                    StrongBranch tBranch = (StrongBranch)ropeTree.GetBranch(RopeEnum.STRONG);
                    tBranch.ReturnObject(_rope);
                    break;

                case RopeEnum.WEAK:
                    WeakBranch wBranch = (WeakBranch)ropeTree.GetBranch(RopeEnum.WEAK);
                    wBranch.ReturnObject(_rope);
                    break;

                default:
                    Debug.LogWarning("Rope not recognized @_@");
                    break;
            }
        }
    }

}
