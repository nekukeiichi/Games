using UnityEngine;
using System.Collections;

abstract public class ManagerNode : ObjectNode 
{
	//variable
	protected TreeComponent myTree;

	protected ManagerNode(GameObjectType _type):base(_type)
	{
		myTree = null;
	}

	public TreeComponent GetMyTree()
	{
		return myTree;
	}

	public void Row(Vector3 _target)
	{
		myTree.Row(_target);
	}
}
