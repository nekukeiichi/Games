using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GOScreenController
{

    private static Text scoreTXT;
    private static Text bestScore;

    public static void Kickstart()
    {
        scoreTXT = GameOverPanel.GetCurrentScore();
        bestScore = GameOverPanel.GetBestScore();
    }

    public static Text GetScoreText()
    {
        return scoreTXT;
    }

    public static Text GetBestText()
    {
        return bestScore;
    }
}
