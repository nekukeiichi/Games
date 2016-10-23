using UnityEngine;
using System.Collections;

public class ObjectIterator 
{
	//variables
	protected ObjectNode myNode;

	public ObjectIterator()
	{
		myNode = null;
	}

	//General Methods

	public void GoNext()
	{
		//keep walking Johnny
		if (myNode != null)
		{
			myNode = myNode.GetNext();
		}
	}

	public void GoPrev()
	{
		//Use reverse dude.
		if (myNode != null)
		{
			myNode = myNode.GetPrev();
		}
	}

	public ObjectNode GetNode()
	{
		return myNode;
	}

	public void SetStartNode(ObjectNode _node)
	{
		myNode = _node;
	}



}
