using UnityEngine;
using System.Collections;

public class PanelContainer : MonoBehaviour
{

    public GameObject menuPanel;
	public GameObject introPanel;
    public GameObject gamePanel;
    public GameObject gameOverPanel;

    private static GameObject staticMenu;
	private static GameObject staticIntro;
    private static GameObject staticGame;
    private static GameObject staticGO;

    private PanelContainer()
    {

    }

	// Use this for initialization
	void Start ()
    {
        staticMenu = menuPanel;
		staticIntro = introPanel;
        staticGame = gamePanel;
        staticGO = gameOverPanel;

        UIManager.Kickstart();
	}
	
    public static GameObject GetMenuPanel()
    {
        return staticMenu;
    }
	public static GameObject GetIntroPanel()
	{
		return staticIntro;
	}

    public static GameObject GetGamePanel()
    {
        return staticGame;
    }

    public static GameObject GetGameOverPanel()
    {
        return staticGO;
    }


}
