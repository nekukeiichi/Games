using UnityEngine;
using System.Collections;

public class RopeBuilder : ObjectNode
{
	
	//Variables
	private SpriteRenderer mySprite;
	
	//Default Constructor
	public RopeBuilder() : base(GameObjectType.ROPE)
	{
		
	}
	
	// Use this for initialization
	void Start ()
	{
		//Get the Sprite Renderer from the object
		mySprite = this.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	void FixedUpdate()
	{
		//Let's see if the movement works
		transform.position -= new Vector3(0.0f, 0.05f, 0.0f);
		
		//Check if we should reposition
		if (transform.position.y <= GameRules.GetRope_lDeathPosition ().y) {
			//Reposition the rope
			if(transform.position.x== 0.8f){
				transform.position = GameRules.GetRope_rResetPosition();
			}else{
				transform.position = GameRules.GetRope_lResetPosition();
			}
		}


	}
	
	//Reposition the rope to the upper side
	private void RepositionBlock()
	{
		
	}
	
	//This function will let the rope get a new Sprite from Resources
	private void GetNewSprite()
	{
		
	}
}