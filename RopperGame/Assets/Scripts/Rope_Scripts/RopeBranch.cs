using UnityEngine;
using System.Collections;

abstract public class RopeBranch : TreeComposite 
{
	//variables 
	protected RopeEnum ropeType;

	public RopeBranch(RopeEnum _ropeType):base(GameObjectType.ROPE)
	{
        ropeType = _ropeType;
	}
	public RopeEnum GetRopeType()
	{
		return ropeType;
	}

	public override void Activate ()
	{

	}
	public override void Deactivate ()
	{

	}

	public override void Row (Vector3 _target)
	{
		//Set Iterator
		pIterator.SetStartNode (pActiveChildHead);

		//Walk the list
		while (pIterator.GetNode() != null) 
		{
			//Shout row
			pIterator.GetNode().Row(_target);

			//keep walking johnny
			pIterator.GoNext();
		}
	}

}
