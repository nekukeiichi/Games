using UnityEngine;
using System.Collections;

public class Fondo_Tiling : MonoBehaviour {

	float scrollSpeed = 0.05f;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		float offset = Time.time * scrollSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
	}
}
