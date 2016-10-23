using UnityEngine;
using System.Collections;
using System;

abstract public class TreeLeaf : TreeComponent
{
    //The flag to know if it's rowing
    protected bool isRowing;

    //The Target position 
    protected Vector3 targetPos;

    //The Sprite renderer
    protected SpriteRenderer mySprite;

    protected TreeLeaf(GameObjectType _type) : base(_type)
    {

    }

    public override void Row(Vector3 _target)
    {
        if (!isRowing)
        {
            //Get a new target
            targetPos = _target;
            //Mark us as rowing
            isRowing = true;
        }
    }

    public bool IsRowing()
    {
        return isRowing;
    }

    public SpriteRenderer GetSpriteRenderer()
    {
        //Do a quick check up of the sprite
        if(mySprite == null)
        {
            //Apparently, there is no sprite! Try to get it!
            mySprite = this.GetComponentInChildren<SpriteRenderer>();
        }
        return mySprite;
    }

    public void ForceNewPosition(Vector3 _position)
    {
        this.transform.position = _position;
        targetPos = _position;
    }
}
