using UnityEngine;
using System.Collections;

public class RopeBlock : TreeLeaf
{

	//Default Constructor
	public RopeBlock() : base(GameObjectType.ROPE)
	{

	}

	// Use this for initialization
	void Start () {

		//Get the Sprite Renderer from the object
		mySprite = this.GetComponentInChildren<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Let's see if the movement works
		transform.position -= new Vector3(0.0f, 0.05f, 0.0f);
		
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
	private void RepositionRope()
	{
		
	}
	
	//This function will let the rope get a new Sprite from Resources
	private void GetNewSprite()
	{
		
	}
	
	//Abstract Classes
	
	//Activate object
	public override void Activate ()
	{
		this.gameObject.SetActive (true);
	}
	//Deactivate object
	public override void Deactivate ()
	{
		this.gameObject.SetActive (false);
	}
	public override void Row (Vector3 _target)
	{

	}
}
