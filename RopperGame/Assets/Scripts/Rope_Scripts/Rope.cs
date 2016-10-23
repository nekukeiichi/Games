using UnityEngine;
using System.Collections;

 abstract public class Rope : TreeLeaf
{

    //Variables
    protected float threshold;
    //Our rope type
    protected RopeEnum myRopeType;
    //Current Row


    protected Rope(RopeEnum _type): base (GameObjectType.ROPE)
    {
        myRopeType = _type;
        //Never ask for components in abstract classes.
        threshold = 0.1f;
    }

    //Get our type
    public RopeEnum GetRopeType()
    {
        return myRopeType;
    }

    //get our Sprite
    public SpriteRenderer GetSpriteRenderer()
    {
        return mySprite;
    }

	public override void Activate ()
	{

	}

	public override void Deactivate ()
	{

	}

}
