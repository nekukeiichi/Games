using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Intro : MonoBehaviour {

	public GameObject R_Hand;
	public GameObject L_Hand;
	public GameObject L_Hand2;
	public GameObject R_Hand2;
	public GameObject RopperAnimationMiddle;
	public GameObject RopperAnimationLeft;
	public GameObject RopperAnimationSuperJump;
	public Button MainButton;

	public GameObject Text1;
	public GameObject Text2;
	public GameObject Text3;

	int contador = 0;

	// Use this for initialization
	void Start () {
		R_Hand.SetActive (true);
		R_Hand2.SetActive (false);
		L_Hand.SetActive (true);
		L_Hand2.SetActive (false);
		RopperAnimationMiddle.SetActive(true);
		RopperAnimationLeft.SetActive (false);
		RopperAnimationSuperJump.SetActive (false);
		Text1.SetActive (true);
		Text2.SetActive (false);
		Text3.SetActive (false);
		R_Hand2.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	public void OnButtonPressed(){
		if (contador == 1) {
			R_Hand.SetActive (false);
			R_Hand2.SetActive (true);
			L_Hand.SetActive (false);
			L_Hand2.SetActive (false);
			RopperAnimationMiddle.SetActive(false);
			RopperAnimationLeft.SetActive (false);
			RopperAnimationSuperJump.SetActive (true);
			Text1.SetActive (false);
			Text2.SetActive (false);
			Text3.SetActive (true);
			R_Hand2.SetActive (true);

			contador += 1;
		}

		if (contador == 0) {
			R_Hand.SetActive (false);
			L_Hand.SetActive (false);
			L_Hand2.SetActive (true);
			RopperAnimationMiddle.SetActive(false);
			RopperAnimationLeft.SetActive (true);
			Text1.SetActive (false);
			Text2.SetActive (true);
			Text3.SetActive (false);
			R_Hand2.SetActive (false);
			contador += 1;
		}
	}
}
