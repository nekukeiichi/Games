using UnityEngine;
using System.Collections;

abstract public class Manager  
{

	//Variables
	//Active head of the list
	protected ObjectNode pActiveHead;
	
	//Reserved head of the list
	protected ObjectNode pReserveHead;
	//our iterator
	protected ObjectIterator pIterator;

	//Default constructor.
	protected Manager()
	{
		pActiveHead = null;
		pReserveHead = null;
		pIterator = new ObjectIterator ();
	}

	//Internal Methods
	//Add a node to the active list.
	protected ObjectNode AddActive(ObjectNode _node)
	{
		//Let's check if the node is NOT null.
		if (_node != null) 
		{
			//It's not null, let's add it!

			//Case 1.- The active list is empty.
			if(pActiveHead == null )
			{
				//Head points to new node.
				pActiveHead = _node;
			}
			//Case 2.- The list is not empty
			else
			{
				//Add it to the front
				//Step 1.- Point Head's Prev to new node.
				pActiveHead.SetPrev(_node);
				//Step 2.- Point new node's next to head
				_node.SetNext(pActiveHead);
				//Step 3.- Head is now new node.
				pActiveHead =_node;

			}
		}

		return _node;
	}

	//Add a node to the Reserve list.
	protected ObjectNode AddReserve(ObjectNode _node)
	{
		//Let's check if the node is NOT null.
		if (_node != null) 
		{
			//It's not null, let's add it!
			
			//Case 1.- The active list is empty.
			if(pReserveHead == null )
			{
				//Head points to new node.
				pReserveHead = _node;
			}
			//Case 2.- The list is not empty
			else
			{
				//Add it to the front
				//Step 1.- Point Head's Prev to new node.
				pReserveHead.SetPrev(_node);
				//Step 2.- Point new node's next to head
				_node.SetNext(pReserveHead);
				//Step 3.- Head is now new node.
				pReserveHead =_node;
				
			}
		}
		
		return _node;
	}

	protected ObjectNode PopReserve()
	{

		//create the result node.
		ObjectNode tResult = pReserveHead;

		//Check if there are nodes in the reserve list.
		if (tResult != null) 
		{
			//Case 1.- There is only one node left
			if(tResult.GetNext()== null)
			{
				pReserveHead = null;
			}
			//Case 2.- There are more nodes in the list
			else
			{
				//Step 1.- Move the head to the next node.
				pReserveHead = tResult.GetNext();
				//Step 2.- Remove the nodes next
				tResult.SetNext(null);
				//Step 3.-Remove the head's previous.
				pReserveHead.SetPrev(null);

			}

		}
		return tResult;
	}

	protected ObjectNode RemoveActive(ObjectNode _node)
	{
		//Is the node not null?
		if (_node != null)
		{
			//We assume the node is in the list, no need to look for it
			//Case 1.- It's the last node in the list
			if(_node == pActiveHead && _node.GetNext() == null)
			{
				//Remove the head
				pActiveHead = null;
			}
			//Case 2.- It's the head but not the last
			else if (_node == pActiveHead)
			{
				//Step 1.- Pass head to the next.
				pActiveHead = _node.GetNext();
				//Step 2 .- Remove nodes next
				_node.SetNext(null);
				//Step 3.- Remove the head its prev
				pActiveHead.SetPrev(null);
			}
			//Case 3.- Is the node somewhere in this list
			else
			{
				//Step 1.- Remove Next, And relink the next's Prev
				if(_node.GetNext() != null)
				{
					_node.GetNext().SetPrev(_node.GetPrev());

				}

				//Step 2.- Remove Prev, and relink
				if(_node.GetPrev() != null)
				{
					_node.GetPrev().SetNext(_node.GetNext());
				}
				//Step 3 .- Remove our next and prev.
				_node.SetNext(null);
				_node.SetPrev(null);
			}
		}

		return _node;
	}
	protected ObjectNode FindActive (ObjectNode _nodeToFind)
	{
		//Set the iterator first node.
		pIterator.SetStartNode (pActiveHead);

		//let the iterator walk the list.
		while (pIterator.GetNode() != null)
		{
			//is this the node we are looking for?
			if(_nodeToFind == pIterator.GetNode())
			{
				//we found it.
				return pIterator.GetNode();
			}
			//We didn't find it 
			//keep walking johnny
			pIterator.GoNext();

		}
		//in case everything goes to hell, return null.
		return null;
	}

	public bool Contains (ObjectNode _node)
	{
		if (_node == FindActive (_node)) 
		{
			return true;
		}
		return false;
	}



}
