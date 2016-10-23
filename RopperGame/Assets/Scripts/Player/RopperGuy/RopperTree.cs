using UnityEngine;
using System.Collections;
using System;

public class RopperTree : TreeComposite
{

    public RopperTree() : base(GameObjectType.PLAYER)
    {

    }

    // Use this for initialization
    void Start ()
    {
        //Create the Ropper guy
        GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/Ropper/RopperGuy"), new Vector3(), new Quaternion());
        //Make it our transform's child
        tObj.transform.parent = this.transform;
        //Get the Ropper Script
        RopperGuy tGuy = tObj.GetComponent<RopperGuy>();

        tObj.SetActive(false);
        //Add it to our active list
        AddActiveChild(tGuy);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public RopperGuy GetRopperGuy()
    {
        return (RopperGuy)pActiveChildHead;
    }

    public override void Activate()
    {
        
    }

    public override void Deactivate()
    {
        
    }

    public override void Row(Vector3 _target)
    {
        
    }
}
