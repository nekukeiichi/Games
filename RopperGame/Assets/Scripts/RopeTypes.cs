using UnityEngine;
using System.Collections;

public class RopeTypes : MonoBehaviour {
	public enum RopeType
	{
		UNINITIALIZED,
		STRONG,
		WEAK
	}
	// all of the ropes at scene-
	public GameObject R_Top_l;
	public GameObject R_Top_r;
	public GameObject R_Middle1_l;
	public GameObject R_Middle1_r;
	public GameObject R_Middle2_l;
	public GameObject R_Middle2_r;
	public GameObject R_Base_l;
	public GameObject R_Base_r;
	//array with the different ropes-
	public Sprite[] sprites;
	//all of the rope renderers 
	private SpriteRenderer R_Top_lspriteRenderer;
	private SpriteRenderer R_Middle1_lspriteRenderer;
	private SpriteRenderer R_Middle2_lspriteRenderer;
	private SpriteRenderer R_Base_lspriteRenderer;
	private SpriteRenderer R_Top_rspriteRenderer;
	private SpriteRenderer R_Middle1_rspriteRenderer;
	private SpriteRenderer R_Middle2_rspriteRenderer;
	private SpriteRenderer R_Base_rspriteRenderer;
	//The sprites in order to save the last chunk of rope.
	private Sprite Rope_rLastMiddle1sprite;
	private Sprite Rope_rLastMiddle2sprite;
	private Sprite Rope_rLastBasesprite;
	private Sprite Rope_lLastMiddle1sprite;
	private Sprite Rope_lLastMiddle2sprite;
	private Sprite Rope_lLastBasesprite;

	void Start ()
	{
		R_Top_lspriteRenderer = R_Top_l.GetComponent<Renderer>() as SpriteRenderer;
		R_Top_rspriteRenderer = R_Top_r.GetComponent<Renderer>() as SpriteRenderer;
		R_Middle1_lspriteRenderer = R_Middle1_l.GetComponent<Renderer>() as SpriteRenderer;
		R_Middle1_rspriteRenderer = R_Middle1_r.GetComponent<Renderer>() as SpriteRenderer;
		R_Middle2_lspriteRenderer = R_Middle2_l.GetComponent<Renderer>() as SpriteRenderer;
		R_Middle2_rspriteRenderer = R_Middle2_r.GetComponent<Renderer>() as SpriteRenderer;
		R_Base_lspriteRenderer = R_Base_l.GetComponent<Renderer>() as SpriteRenderer;
		R_Base_rspriteRenderer = R_Base_r.GetComponent<Renderer>() as SpriteRenderer;
	}

	void FixedUpdate ()
	{
		int tIndex = Random.Range(0, sprites.Length);
		
		if (Input.GetMouseButtonDown(0))
		{
			RefreshRopes ();
			
			R_Top_lspriteRenderer.sprite = sprites[tIndex];

		}
	}
	void RefreshRopes()
	{
		//Get the Sprite from the top right rope
		Rope_rLastMiddle1sprite = R_Top_rspriteRenderer.sprite;
		//Get the sprite from the Middle1 right rope
		Rope_rLastMiddle2sprite = R_Middle1_rspriteRenderer.sprite;
		//Get the sprite from the Middle2 right rope
		Rope_rLastBasesprite = R_Middle2_rspriteRenderer.sprite;

		//Get the Sprite from the top left rope
		Rope_lLastMiddle1sprite = R_Top_lspriteRenderer.sprite;
		//Get the sprite from the Middle1 left rope
		Rope_lLastMiddle2sprite = R_Middle1_lspriteRenderer.sprite;
		//Get the sprite from the Middle2 left rope
		Rope_lLastBasesprite = R_Middle2_lspriteRenderer.sprite;
		
		//Place the Right sprite one rope below
		R_Middle1_rspriteRenderer.sprite = Rope_rLastMiddle1sprite;
		//Set 
		R_Middle2_rspriteRenderer.sprite = Rope_rLastMiddle2sprite;
		//Set
		R_Base_rspriteRenderer.sprite = Rope_rLastBasesprite;

		//Place the Left sprite one rope below
		R_Middle1_lspriteRenderer.sprite = Rope_lLastMiddle1sprite;
		//Set 
		R_Middle2_lspriteRenderer.sprite = Rope_lLastMiddle2sprite;
		//Set
		R_Base_lspriteRenderer.sprite = Rope_lLastBasesprite;

	}

}