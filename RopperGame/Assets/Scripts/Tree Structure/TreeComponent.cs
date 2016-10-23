using UnityEngine;
using System.Collections;

abstract public class TreeComponent : ObjectNode
{
    //Variables
    protected TreeComponent pActiveChildHead;
    protected TreeComponent pReserveChildHead;
    protected TreeIterator pIterator;


	protected TreeComponent(GameObjectType _type) : base(_type)
    {
        pIterator = new TreeIterator();
    }

    protected virtual TreeComponent AddActiveChild(TreeComponent _node)
    {
        //Do nothing
        return null;
    }

    protected virtual TreeComponent AddReserveChild(TreeComponent _node)
    {
        //Do Nothing
        return null;
    }

    protected virtual TreeComponent PopReserveChild()
    {
        //Do nothing
        return null;
    }

    protected virtual TreeComponent RemoveActive(TreeComponent _node)
    {
        //Do Nothing 
        return null;
    }

    protected virtual TreeComponent FindActive(TreeComponent _node)
    {
        //Do nothing 
        return null;
    }

    //Get an object from your tree
    public virtual TreeComponent LoanObject()
    {
        return null;
    }

    public virtual void ReturnObject(TreeComponent _object)
    {
        //Do nothing
    }

    //Abstract methods
    public abstract void Activate();

    public abstract void Deactivate();

    public abstract void Row(Vector3 _target);

}
