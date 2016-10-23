using UnityEngine;
using System.Collections;

abstract public class State
{

    public abstract void Enter(TreeLeaf _object);

    public abstract void Execute(TreeLeaf _object);

    public abstract void Exit(TreeLeaf _object);
	
}
