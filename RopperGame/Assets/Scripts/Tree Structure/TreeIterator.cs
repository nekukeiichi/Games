using UnityEngine;
using System.Collections;

public class TreeIterator
{
    //variables
    protected TreeComponent myNode;

    public TreeIterator()
    {
        myNode = null;
    }

    //General Methods
    public void GoNext()
    {
        //Keep walking Johnny
        if (myNode != null)
        {
            myNode = (TreeComponent)myNode.GetNext();
        }
    }

    public void GoPrev()
    {
        //De reversa mami!!
        if (myNode != null)
        {
            myNode = (TreeComponent)myNode.GetPrev();
        }
    }

    public TreeComponent GetNode()
    {
        return myNode;
    }

    public void SetStartNode(TreeComponent _node)
    {
        myNode = _node;
    }
}
