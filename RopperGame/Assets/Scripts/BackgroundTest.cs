using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundTest : MonoBehaviour {
	public List<SpriteRenderer> sp;
	public float speed;
	public List<Sprite> pull;
	public List<Vector3> pos;
	// Use this for initialization
	void Start () {
		foreach(SpriteRenderer p in sp){
			pos.Add(p.transform.position);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			D();
		}
	}
	float offset = 0;
	void D(){
		offset += speed;
		if(offset>=1){
			offset = 0;
			LoopSprites();
			for(int i = 0;i<sp.Count ;i++){
				sp[i].transform.position = pos[i];
			}
		}else{
			for(int i = 0;i<sp.Count ;i++){
				sp[i].transform.position = Vector3.Lerp(pos[i],new Vector3(pos[i].x, pos[i].y-1,pos[i].z),offset);
			}

		}
	}
	void LoopSprites(){
		for(int i = 0;i<sp.Count ;i++){

			if(i== sp.Count-1){
				sp[i].sprite = pull[ Random.Range(0,pull.Count)];
			}else{
				sp[i].sprite = sp[i+1].sprite;
			}
		}
	}
}
