using UnityEngine;
using System.Collections;

public class BlockFactory
{

    private BlockFactory()
    {

    }

    public static BuildingBlock CreateBlock()
    {
        //Get the Block tree!
        BlockTree tTree = (BlockTree)GameObjectManager.GetTree(GameObjectType.BLOCK);
        //Check if the tree isn't null
        if(tTree != null)
        {
            //Get a block from the tree
            BuildingBlock tBlock = (BuildingBlock)tTree.LoanObject();
            return tBlock;
        }

        //Something went wrong
        return null;
    }

    //Be green and recycle your blocks :) (Insert more greenpeace shit here) :P
    public static void ReturnBlock(BuildingBlock _block)
    {
        //Get the Block tree!
        BlockTree tTree = (BlockTree)GameObjectManager.GetTree(GameObjectType.BLOCK);
        //Check if the tree isn't null
        if (tTree != null)
        {
            //Return the object
            tTree.ReturnObject(_block);
        }
    }
	
}
