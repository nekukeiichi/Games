using UnityEngine;
using System.Collections;

public class PriorityQueueNode<T>
{

    PriorityQueueNode<T> pNext;
    T pData;
    //The "Time" value
    float executeTime;

    public PriorityQueueNode()
    {
        pData = default(T);

        executeTime = 0.0f;
    }

    public void SetNext(PriorityQueueNode<T> _next)
    {
        pNext = _next;
    }

    public PriorityQueueNode<T> GetNext()
    {
        return pNext;
    }

    public void SetExecuteTime(float _time)
    {
        executeTime = _time;
    }

    public float GetExecuteTime()
    {
        return executeTime;
    }

    public void SetData(T _data)
    {
        pData = _data;
    }

    public T GetData()
    {
        return pData;
    }

}
