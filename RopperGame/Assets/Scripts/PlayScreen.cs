using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Main2Game(){
		SceneManager.LoadScene ("Game");
	}
	public void Game2Main(){
		SceneManager.LoadScene ("Main");
	}
	public void Main2Credits(){
		SceneManager.LoadScene ("Credits");
	}
	public void Credits2Main(){
		SceneManager.LoadScene ("Main");
	}
}
