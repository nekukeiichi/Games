using UnityEngine;
using System.Collections;

public class PriorityQueue<T>
{

    //Variables
    //The head
    protected PriorityQueueNode<T> pActiveHead;
    protected PriorityQueueNode<T> pReserveHead;

    protected PriorityQueueIterator<T> pIterator;

    public PriorityQueue()
    {
        pActiveHead = null;
        pReserveHead = null;

        //The iterator
        pIterator = new PriorityQueueIterator<T>();
    }



    //reserve functions
    protected PriorityQueueNode<T> PopReserve()
    {
        PriorityQueueNode<T> tResult = pReserveHead;

        if (tResult != null)
        {
            //Move the head
            pReserveHead = tResult.GetNext();

            //Unlink the node
            tResult.SetNext(null);
        }

        return tResult;
    }

    protected void AddReserve(PriorityQueueNode<T> _node)
    {
        //Check if not null
        if (_node != null)
        {
            //Case 1: The list is empty
            if (pReserveHead == null)
            {
                //Make the head the _node
                pReserveHead = _node;
            }
            //Case 2: The list empty
            else
            {
                //Link the node
                _node.SetNext(pReserveHead);
                //Move the head
                pReserveHead = _node;
            }
        }
    }

    //Active methods
    protected PriorityQueueNode<T> AddOrdered(PriorityQueueNode<T> _node)
    {
        //Make sure it isn't null
        if(_node != null)
        {
            if(pActiveHead == null)
            {
                //Set the head to this new node
                pActiveHead = _node;
            }
            else if(_node.GetExecuteTime() < pActiveHead.GetExecuteTime())
            {
                //Link the node to the head
                _node.SetNext(pActiveHead);

                //Move the head to the new node
                pActiveHead = _node;
            }
            else
            {
                //Set iterator 
                pIterator.SetStartNode(pActiveHead);

                //Walk the list and place the node in there
                while (pIterator.GetNode() != null)
                {
                    //If this is the last node in the list
                    if (pIterator.GetNode().GetNext() == null)
                    {
                        //Place it at the end
                        pIterator.GetNode().SetNext(_node);
                        break;
                    }
                    else if(_node.GetExecuteTime() < pIterator.GetNode().GetNext().GetExecuteTime())
                    {
                        //Place it in between them
                        _node.SetNext(pIterator.GetNode().GetNext());

                        //Link the iterator to the new node 
                        pIterator.GetNode().SetNext(_node);
                        break;
                    }

                    //Keep walking Johnny
                    pIterator.GoNext();
                    
                }
            }

            return _node;
        }

        //In case something goes wrong
        return null;
    }

    protected PriorityQueueNode<T> ExecuteFront()
    {
        PriorityQueueNode<T> tNode = pActiveHead;

        if(tNode != null)
        {
            //Remove it from the front
            //Move the head to the next one
            pActiveHead = tNode.GetNext();

            //Unlink from the head
            tNode.SetNext(null);
        }

        return tNode;
    }

    public void Add(T _data, float _time)
    {
        //Pop a node fro reserve
        PriorityQueueNode<T> tNode = PopReserve();
        //Add it ordered to the list
        if(tNode != null)
        {
            //Set the node
            tNode.SetData(_data);
            tNode.SetExecuteTime(_time);

            //Add it
            AddOrdered(tNode);
        }
        else
        {
            tNode = new PriorityQueueNode<T>();

            //Set the Data
            tNode.SetData(_data);
            //Set the Execute Time
            tNode.SetExecuteTime(_time);
            //Add it
            AddOrdered(tNode);
        }
    }

    public T ExecuteFirstAvailable(float _time)
    {
        if (pActiveHead != null)
        {
            //Check if the head is Less or equal to the execute Time
            if (pActiveHead.GetExecuteTime() <= _time)
            {
                //Catch data
                T tData = pActiveHead.GetData();

                //Remove the head, and send to reserve
                AddReserve(ExecuteFront());

                //Return data
                return tData;
            }
        }

        return default(T);
    }

    public bool Contains(T _data)
    {
        pIterator.SetStartNode(pActiveHead);

        while (pIterator.GetNode() != null)
        {
            if(pIterator.GetNode().GetData().Equals(_data))
            {
                return true;
            }

            //Keep walking Johnny
            pIterator.GoNext();
        }

        return false;
    }

    public void Dump()
    {
        //Set iterator
        pIterator.SetStartNode(pActiveHead);
        int counter = 0;
        //walk list and print
        while(pIterator.GetNode() != null)
        {
            counter++;
            //Keep walking Johnny
            pIterator.GoNext();
        }

        Debug.Log("There are " + counter.ToString() + " nodes in EventManager");
    }

}
