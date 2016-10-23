using UnityEngine;
using System.Collections;

public class BackgroundManager : MonoBehaviour {
	public GameObject Top;
	public GameObject Middle1;
	public GameObject Middle2;
	public GameObject Base;
	public float scrollSpeed;
	public float tileSizeZ;

	public Sprite[] sprites;
	private SpriteRenderer TopspriteRenderer;
	private SpriteRenderer Middle1spriteRenderer;
	private SpriteRenderer Middle2spriteRenderer;
	private SpriteRenderer BasespriteRenderer;

	private Sprite LastMiddle1sprite;
	private Sprite LastMiddle2sprite;
	private Sprite LastBasesprite;
	private Vector3 startPosition;

	public float framesPerSecond;

	// Use this for initialization
	void Start ()
    {
		startPosition = transform.position;
		TopspriteRenderer = Top.GetComponent<Renderer>() as SpriteRenderer;
		Middle1spriteRenderer = Middle1.GetComponent<Renderer>() as SpriteRenderer;
		Middle2spriteRenderer = Middle2.GetComponent<Renderer>() as SpriteRenderer;
		BasespriteRenderer = Base.GetComponent<Renderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        int tIndex = Random.Range(0, sprites.Length);
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);


		if (Input.GetMouseButtonDown(0))
        {
			RefreshBackground ();
			transform.position = startPosition + Vector3.up * newPosition;
			TopspriteRenderer.sprite = sprites[tIndex];
        }
	}

	void RefreshBackground()
    {
        //Get the Sprite from the top level
		LastMiddle1sprite = TopspriteRenderer.sprite;
        //Get the sprite from the Middle1 
        LastMiddle2sprite = Middle1spriteRenderer.sprite;
        //Get
        LastBasesprite = Middle2spriteRenderer.sprite;

        //Place the sprite one floor below
        Middle1spriteRenderer.sprite = LastMiddle1sprite;
        //Set 
        Middle2spriteRenderer.sprite = LastMiddle2sprite;
        //Set
		BasespriteRenderer.sprite = LastBasesprite;
	}
}
