using UnityEngine;
using System.Collections;

abstract public class ObjectNode : MonoBehaviour
{
    //An object that will appear on screen
    protected ObjectNode pNext;
    protected ObjectNode pPrev;

	protected GameObjectType myObjectType;

    protected ObjectNode(GameObjectType _type)
    {
		myObjectType = _type;
    }

    public ObjectNode GetNext()
    {
        return pNext;
    }
    public void SetNext(ObjectNode _next)
    {
        pNext = _next;
    }
	
    public ObjectNode GetPrev()
    {
        return pPrev;
    }
    public void SetPrev(ObjectNode _prev)
    {
        pPrev = _prev;
    }
	public GameObjectType GetObjectType()
	{
		return myObjectType;
	}
}
