using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CanvasController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void SwitchToMenu()
    {
        UIManager.Kickstart();
       SceneManager.LoadScene("StartMenu");
      
    }

	public void SwitchToIntro()
	{
		GameStateMachine.EnterIntroScreen ();
	}

    public void SwitchToGame()
    {
        GameStateMachine.EnterGameScreen();
    }

}
