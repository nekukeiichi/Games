using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverPanel : MonoBehaviour
{

    public Text currScoreTXT;
    public Text bestScoreTXT;
    

    private static Text currScore;
    private static Text bestScore;
  

	// Use this for initialization
	void Start ()
    {
        currScore = currScoreTXT;
        bestScore = bestScoreTXT;
      

        GOScreenController.Kickstart();
	}

    void Update()
    {
       
    }

    public static Text GetCurrentScore()
    {
        
        return currScore;
    }

    public static Text GetBestScore()
    {
        return bestScore;
    }

}
