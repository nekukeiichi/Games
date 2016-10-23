using UnityEngine;
using System.Collections;
using System;

public class BlockTree : TreeComposite
{

    public BlockTree() : base(GameObjectType.BLOCK)
    {

    }

	// Use this for initialization
	void Start ()
    {
	    //Create all blocks Here
        for(int i = 0; i < GameRules.GetMaxBlocks(); i++)
        {
            GameObject tObj = (GameObject)MonoBehaviour.Instantiate(Resources.Load("Prefabs/BuildingBlock/BuildingBlock"), new Vector3(), new Quaternion());
            //Set parent
            tObj.transform.parent = this.transform;
            BuildingBlock tBlock = tObj.GetComponent<BuildingBlock>();
            //Move upwards
            //tBlock.transform.position = new Vector3(0.0f, tBlock.mySprite.transform.localScale.y * i, 0.0f);
            //name it
            tBlock.gameObject.name = "Block " + i.ToString();
            //Switch off object
            tObj.SetActive(false);
            //Since it starts off as inactive, add as reserve
            AddReserveChild(tBlock);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    //Abstract
    public override void Activate()
    {
        
    }

    public override void Deactivate()
    {
        
    }

    public BuildingBlock GetBlock()
    {
        BuildingBlock tBlock = (BuildingBlock)PopReserveChild();

        if(tBlock != null)
        {
            tBlock.gameObject.SetActive(true);

            AddActiveChild(tBlock);
        }
        else
        {

        }

        return tBlock;
    }

    public override void Row(Vector3 _target)
    {
        //Set iterator
        pIterator.SetStartNode(pActiveChildHead);

        //Walk the list
        while(pIterator.GetNode() != null)
        {
            //Yell Row!!
            pIterator.GetNode().Row(_target);

            //Keep walking Johnny
            pIterator.GoNext();
        }
    }
}
