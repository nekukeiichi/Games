using UnityEngine;
using System.Collections;

public class Backgrounds : MonoBehaviour {
	//Gameobjects of the Floors on the scene.
	public GameObject Top_Floor;
	public GameObject Second_Floor;
	public GameObject First_Floor;
	public GameObject Base;
	public GameObject Extra_Floor;
	//List containing the Sprites.
	public Sprite[] sprites;
	//Float to change the Speed of movement.
	public float speed;


	private SpriteRenderer ExtraFloorSpriteRenderer;
	private Sprite ExtraFloorSprite;
	private Vector3 Extra_FloorstartPosition;
	private Rigidbody2D TopF_rgb2d;
	private Rigidbody2D SecondF_rgb2d;
	private Rigidbody2D FirstF_rgb2d;
	private Rigidbody2D BaseF_rgb2d;
	private Rigidbody2D ExtraF_rgb2d;


	// Use this for initialization
	void Start () {
		//obtain the starting position of the extra floor.
		Extra_FloorstartPosition = Extra_Floor.transform.position;
		//obtain the renderer.
		ExtraFloorSpriteRenderer = Extra_Floor.GetComponent<Renderer>() as SpriteRenderer;
		//Obtain the Rigidbody2D component of the background parts.
		TopF_rgb2d = Top_Floor.GetComponent<Rigidbody2D> ();
		SecondF_rgb2d = Second_Floor.GetComponent<Rigidbody2D> ();
		FirstF_rgb2d = First_Floor.GetComponent<Rigidbody2D> ();
		BaseF_rgb2d = Base.GetComponent<Rigidbody2D> ();
		ExtraF_rgb2d = Extra_Floor.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//index to randomize the sprite selected.
		int tIndex = Random.Range(0, sprites.Length);

		
		if (Input.GetMouseButtonDown(0))
		{
			//asign the selected sprite.
			ExtraFloorSpriteRenderer.sprite = sprites[tIndex];
			Vector2 movement = new Vector2 (0,-3);
			TopF_rgb2d.AddForce(movement*speed);
			/*SecondF_rgb2d.AddForce(movement*speed);
			FirstF_rgb2d.AddForce(movement*speed);
			BaseF_rgb2d.AddForce(movement*speed);
			ExtraF_rgb2d.AddForce(movement*speed);
*/


		}
	
	}
}
