using UnityEngine;
using System.Collections;

abstract public class FSM
{

    protected State previousState;
    protected State currentState;

    protected TreeLeaf gameObject;

    protected FSM(State _state)
    {
        currentState = _state;
        previousState = null;

        if(_state != null)
        {
            currentState.Enter(gameObject);
        }
    }

    public State GetCurrentState()
    {
        return currentState;
    }

    public void SetGameObject(TreeLeaf _gameObj)
    {
        gameObject = _gameObj;
    }

    public void UpdateFSM()
    {
        //Execute the current state
        currentState.Execute(gameObject);
    }

    public void ChangeState(State _state)
    {
        if(_state != null)
        {
            //exit the current state
            currentState.Exit(gameObject);

            //record current with previous
            previousState = currentState;

            //switch current to new
            currentState = _state;

            //Enter new state
            currentState.Enter(gameObject);
        }
    }

    public void RevertToPreviousState()
    {
        ChangeState(previousState);
    }

}
