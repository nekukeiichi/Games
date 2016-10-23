using UnityEngine;
using System.Collections;

public class Floor
{
    //This class will hold a reference to all objects in one floor
    //Such as a Building Block, coins, Ropes, ETC.

    protected BuildingBlock myBlock;

    protected Rope leftRope;

    protected Rope rightRope;

    //When the time comes, items will be here too
    public Floor()
    {

    }

    public BuildingBlock GetBlock()
    {
        return myBlock;
    }

    public Rope GetLeftRope()
    {
        return leftRope;
    }

    public Rope GetRightRope()
    {
        return rightRope;
    }

    public void GetNewAssets(int _index)
    {
        //Here is where we will set our assets

        //Set the BuildingBlock
        //Get and Set a building block
        SetBlock(_index);

        //Left Rope
        SetLeftRope();

        //Right Rope
        SetRightRope();
    }

    public void DeleteAssets()
    {
        //Return assets to respective factories
        //Delete the block
        BlockFactory.ReturnBlock(this.myBlock);
        this.myBlock = null;

        //Delete the left rope
        RopeFactory.ReturnRope(this.leftRope);
        this.leftRope = null;

        //Delete the Right rope
        RopeFactory.ReturnRope(this.rightRope);
        this.rightRope = null;
    }

    public void SetPosition(Vector3 _position)
    {
        //Set the position for all assets
        //Block
        myBlock.transform.position = _position;

        //Left Rope
        leftRope.ForceNewPosition(new Vector3(-0.55f, _position.y, _position.z));

        //Right Rope
        rightRope.ForceNewPosition(new Vector3(0.55f, _position.y, _position.z));
    }

    public void Row(Vector3 _target)
    {
        //Row Block
        myBlock.Row(_target);

        //Left Rope
        leftRope.Row(new Vector3(-0.55f, _target.y, _target.z));

        //Right Rope
        rightRope.Row(new Vector3(0.55f, _target.y, _target.z));
    }
	
    public bool IsRowing()
    {
        //Check that all of your items aren't rowing, otherwise return true
        if(!myBlock.IsRowing())
        {
            return false;
        }

        return true;
    }

    private void SetBlock(int _index)
    {
        this.myBlock = BlockFactory.CreateBlock();

        this.myBlock.GetSpriteRenderer().sprite = BlockSpriteFactory.GetSprite(_index);
    }

    private void SetLeftRope()
    {
        this.leftRope = RopeFactory.GetStrongRope();
    }

    private void SetRightRope()
    {
        this.rightRope = RopeFactory.GetStrongRope();
    }

    public void ResetContent()
    {
        //Here is where you will reset the content of the floor
        myBlock.GetSpriteRenderer().sprite = BlockSpriteFactory.GetRandomSprite();

        //Get the next Left Rope
        //Return our current rope
        RopeFactory.ReturnRope(this.leftRope);
        //Return our current rope
        RopeFactory.ReturnRope(this.rightRope);

        //Set our ropes
        RopeGenerator.SetFloorRopes(out this.leftRope, out this.rightRope);

        //Set the position
        this.leftRope.ForceNewPosition(new Vector3(-0.55f, (GameRules.GetMaxBlocks() * BuildingBlock.BlockHeight) - BuildingBlock.BlockHeight, 0.0f));
        //Set the position
        this.rightRope.ForceNewPosition(new Vector3(0.55f, (GameRules.GetMaxBlocks() * BuildingBlock.BlockHeight) - BuildingBlock.BlockHeight, 0.0f));

    }

}
