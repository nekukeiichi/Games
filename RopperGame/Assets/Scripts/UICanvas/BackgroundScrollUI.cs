using UnityEngine;
using System.Collections;

public class BackgroundScrollUI : MonoBehaviour {

    private float scrollSpeed = 0.03F;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
		rend.material.mainTextureOffset = new Vector2(0.768f, offset);
        
    }
}
