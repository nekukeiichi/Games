using UnityEngine;
using System.Collections;

public class RopperNode : ManagerNode
{

    public RopperNode() : base(GameObjectType.PLAYER)
    {

    }

	// Use this for initialization
	void Start ()
    {
        //Create the Ropper Tree
        GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Ropper/RopperTree"), new Vector3(), new Quaternion());
        //Make it our transform's child
        tObj.transform.parent = this.transform;
        //Get the Ropper Script
        RopperTree tTree = tObj.GetComponent<RopperTree>();
        //Set it as our tree
        myTree = tTree;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
