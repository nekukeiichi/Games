using UnityEngine;
using System.Collections;

public class BlockSpriteFactory
{
    private static BlockSpriteFactory pInstance;

    //The list of sprites available
    private DLL<Sprite> mySprites;

    private BlockSpriteFactory()
    {
        mySprites = new DLL<Sprite>();

        //Add the sprites here
        Sprite tSprite = Resources.Load<Sprite>("Sprites/Block/Block_19");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_18");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_17");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_16");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_15");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_14");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_13");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_12");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_11");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_10");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_09");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_08");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_07");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_06");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_05");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_04");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_03");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_02");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_01");
        mySprites.Add(tSprite);
        tSprite = Resources.Load<Sprite>("Sprites/Block/Block_00");
        mySprites.Add(tSprite);

    }

    private static BlockSpriteFactory GetInstance()
    {
        if(pInstance == null)
        {
            pInstance = new BlockSpriteFactory();
        }
        return pInstance;
    }

    public static Sprite GetRandomSprite()
    {
        //Get a random sprite
        Sprite result = null;
        int rnd = Random.Range(4, GetInstance().mySprites.GetSize());
        result = GetInstance().mySprites[rnd];

        return result;
    }

    public static Sprite GetSprite(int _index)
    {
        if(_index < GetInstance().mySprites.GetSize())
        {
            //This is for the bottom block
            if(_index < 0)
            {
                return GetInstance().mySprites[0];
            }
            return GetInstance().mySprites[_index];
        }

        return null;
    }

}
