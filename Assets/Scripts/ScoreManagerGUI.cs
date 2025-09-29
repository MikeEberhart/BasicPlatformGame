using TMPro;
using UnityEngine;

public class ScoreManagerGUI : MonoBehaviour
{
    public TMP_Text guiCurScore;
    public TMP_Text guiHighScore;
    public GameObject player;
    private PlayerController pcScript;
    private HighScoreManager hsmScript;

    public void Start()
    {
        pcScript = player.GetComponent<PlayerController>();
        hsmScript = GetComponent<HighScoreManager>();
        pcScript.setPlayerHighScore(hsmScript.ReadHighScore());
        setGUIHighScore();
    }


    public void setGUICurScore()
    {
        guiCurScore.text = "Score: " + pcScript.getPlayerScore().ToString();
        if(isHighScore())
        {
            setGUIHighScore();
            hsmScript.WriteHighScore();
        }

    }

    public void setGUIHighScore()
    {

        guiHighScore.text = "HighScore: " + pcScript.getPlayerHighScore().ToString();
    }

    public bool isHighScore()
    {
        if(pcScript.getPlayerHighScore() < pcScript.getPlayerScore())
        {
            //change the high score that is connected to the playerController
            pcScript.setPlayerHighScore(pcScript.getPlayerHighScore());
            //we have a new high score so return true
            return true;
        }
        else
        {
            return false;
        }
    }

}
