using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterControls : MonoBehaviour {

	private float HeightScreen;
	private float WidthScreen;

	Vector2 CenterPosition;
	Vector2 RightPosition;
	Vector2 LeftPosition;

	public bool OnCenter_Right = true;
	public bool OnCenter_Left = false;

	public bool OnRight = false;
	public bool OnLeft = false;

	//Slider
	public Slider TimeSlider;
	public float SecondsSlider = 5;
	public float GlobalTime;

	//Score
	public Text ScoreDisplay;
	int Score;

	//Get Ready Screen
	public Text GetReady;
	bool startGame = false;
	public Text GameOver;
	bool endGame = false;

	public Button Right;
	public Button Left;

	void Start () {
		
		//Create the the 3 positions the character can be, depending the screen of the device
		HeightScreen = Camera.main.orthographicSize;
		WidthScreen = HeightScreen * Screen.width/ Screen.height; // basically height * screen aspect ratio
		CenterPosition = new Vector2 (0, -HeightScreen/(float)1.35);
		RightPosition = new Vector2 (WidthScreen/2, -HeightScreen/(float)1.35);
		LeftPosition = new Vector2 (-WidthScreen/2, -HeightScreen/(float)1.35);

		GameOver.enabled = false;
	}
	
	void Update () {

		if (startGame) {
			//With more time playing, the faster the slider will decrease
			GlobalTime += Time.deltaTime;
			SecondsSlider -= (float)(Time.deltaTime+(GlobalTime*0.0007));
			TimeSlider.value = SecondsSlider;

			//Always check that 10 seconds is the max you can get on the slider
			if (SecondsSlider > 10.0f) {
				SecondsSlider = 10.0f;
			}

			//The Score always updates with every frame
			ScoreDisplay.text = "" + Score;
		}
		if(SecondsSlider <= 0.0f){
			startGame = false;
			endGame = true;
		}
		if (endGame) {
			GameOver.enabled = true;
			Left.enabled = false;
			Right.enabled = false;
		}
	}

	public void RightButton(){
		
		try{
			Destroy (GetReady);
			startGame = true;
		}catch{}

		//Checks in which of the 3 positions the character is
		//and jumps from position to position
		if (OnCenter_Right) {
			transform.position = RightPosition;
			OnCenter_Right = false;
			OnRight = true;
			SecondsSlider += 0.5f;
		} 
		else if (OnCenter_Left) {
			OnCenter_Left = false;
			OnCenter_Right = true;
			SecondsSlider += 0.5f;
		} 
		else if (OnLeft) {
			transform.position = CenterPosition;
			OnLeft = false;
			OnCenter_Right = true;
			SecondsSlider += 0.5f;
		} 
		else if (OnRight) {
			SecondsSlider += 0.2f;
		}
			
		//With every touch, the slider increases a little and the score increases by 1
		Score += 1;

	}
	public void LeftButton(){

		try{
			Destroy (GetReady);
			startGame = true;
		}catch{}

		//Checks in which of the 3 positions the character is
		//and jumps from position to position
		if (OnCenter_Right) {
			OnCenter_Right = false;
			OnCenter_Left = true;
			SecondsSlider += 0.5f;
		}
		else if (OnCenter_Left) {
			transform.position = LeftPosition;
			OnCenter_Left = false;
			OnLeft = true;
			SecondsSlider += 0.5f;
		}
		else if (OnRight) {
			transform.position = CenterPosition;
			OnRight = false;
			OnCenter_Left = true;
			SecondsSlider += 0.5f;
		}
		else if (OnLeft) {
			SecondsSlider += 0.2f;
		}

		//With every touch, the slider increases a little and the score increases by 1
		Score += 1;
	}
}
