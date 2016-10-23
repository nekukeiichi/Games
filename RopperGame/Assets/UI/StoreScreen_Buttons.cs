using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoreScreen_Buttons : MonoBehaviour {

	public Button Characters_B;
	public Button Powerups_B;
	public Button Coins_B;
	public Button Return_B;

	public GameObject Characters_G;
	public GameObject Powerups_G;
	public GameObject Coins_G;
	public GameObject Return_G;

	//------Characters Buttons--------------
	public Sprite Characters_ON;
	public Sprite Characters_OFF;

	//------Powerups Buttons--------------
	public Sprite Powerups_ON;
	public Sprite Powerups_OFF;

	//------Coins Buttons--------------
	public Sprite Coins_ON;
	public Sprite Coins_OFF;


	public Image Characters_Title;
	public Image Powerups_Title;
	public Image Coins_Title;

	//Loading Scene--------------------
	public Image FondoBlanco;
	float timer;
	//-----------------------------------

	//Bools------------------------------
	bool ReturnIsPressed = false;
	bool CharacterIsPressed = true;
	bool PowerupsIsPressed = false;
	bool CoinsIsPressed = false;
	//---------------------------------


	//Movimiento del Fondo--------------------
	public RawImage Fondo;
	float scrollSpeed = 0.07f;
	//---------------------------------------



	//Movimiento de Canvas----------------
	public GameObject AllCanvas;
	public Transform Position1;
	public Transform Position2;
	public Transform Position3;
	float speedCanvas = 3000.0f;
	float step;
	//---------------------------------------



	void Start () {
		FondoBlanco.CrossFadeAlpha(0,0.2f, false);
	}

	void Update () {

		//Movimiento de Canvas----------------------------------------------------------------------------------------------------
		step = speedCanvas * Time.deltaTime;

		if (CharacterIsPressed) {
			AllCanvas.transform.position = Vector3.MoveTowards (AllCanvas.transform.position, Position1.transform.position, step);
		}
		if (PowerupsIsPressed) {
			AllCanvas.transform.position = Vector3.MoveTowards (AllCanvas.transform.position, Position2.transform.position, step);
		}
		if (CoinsIsPressed) {
			AllCanvas.transform.position = Vector3.MoveTowards (AllCanvas.transform.position, Position3.transform.position, step);
		}
		//----------------------------------------------------------------------------------------------------------------------



		//Movimiento del Fondo------------------------------------------------------------------------------------------------
		float offset = Time.time * scrollSpeed;
		Fondo.GetComponent<RawImage> ().uvRect = new Rect ((new Vector2 (0.0f, offset)), new Vector2 (1.0f, 1.4f));
		//-------------------------------------------------------------------------------------------------------------------




		//---------------Load Scene de Start Menu----------------------
		if(ReturnIsPressed == true){
			timer += Time.deltaTime;
			FondoBlanco.CrossFadeAlpha(1,0.1f, false);
			if (timer > 0.2f) {
				timer = 0.0f;
				SceneManager.LoadScene("StartMenu");
			}
		}
		//------------------------------------------------------


	}

	public void Characters(){
		if (CharacterIsPressed == false) {
			Characters_B.image.overrideSprite = Characters_ON;
			Powerups_B.image.overrideSprite = Powerups_OFF;
			Coins_B.image.overrideSprite = Coins_OFF;
			CharacterIsPressed = true;
			PowerupsIsPressed = false;
			CoinsIsPressed = false;
		}
	}

	public void Powerups(){
		if (PowerupsIsPressed == false) {
			//Debug.Log ("hey");
			Powerups_B.image.overrideSprite = Powerups_ON;
			Characters_B.image.overrideSprite = Characters_OFF;
			Coins_B.image.overrideSprite = Coins_OFF;
			CharacterIsPressed = false;
			PowerupsIsPressed = true;
			CoinsIsPressed = false;
		}
	}

	public void Coins(){
		if (CoinsIsPressed == false) {
			Coins_B.image.overrideSprite = Coins_ON;
			Characters_B.image.overrideSprite = Characters_OFF;
			Powerups_B.image.overrideSprite = Powerups_OFF;
			CharacterIsPressed = false;
			PowerupsIsPressed = false;
			CoinsIsPressed = true;
		}
	}

	public void Return(){
		ReturnIsPressed = true;
	}
}
