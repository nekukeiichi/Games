using UnityEngine;
using System.Collections;

public class PriorityQueueIterator<T>
{
    PriorityQueueNode<T> myNode;

    public PriorityQueueIterator()
    {
        myNode = null;
    }

    public void SetStartNode(PriorityQueueNode<T> _next)
    {
        myNode = _next;
    }

    public PriorityQueueNode<T> GetNode()
    {
        return myNode;
    }

    public void GoNext()
    {
        if (myNode != null)
        {
            myNode = myNode.GetNext();
        }
    }
}
