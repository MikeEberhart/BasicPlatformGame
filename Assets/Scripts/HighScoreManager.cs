using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public GameObject player;
    private PlayerController pcScript;

    ScoreManagerGUI scoreManagerScript;
    private void Start()
    {
        //I have to have reference to the player to do this 
        //because this script is not attached to the same object as the 
        pcScript = player.GetComponent<PlayerController>();
        //I can do this because this script is attached to the 
        //the same object as score manager script
        scoreManagerScript = GetComponent<ScoreManagerGUI>();
    }

    public void WriteHighScore()
    {
        //we can write simple things to a standard text file by using the PlayerPrefs
        PlayerPrefs.SetInt("HighScore1", pcScript.getPlayerHighScore());
    }
    public int ReadHighScore()
    {
        int highScoreFromFile = PlayerPrefs.GetInt("HighScore1", 0);
        return highScoreFromFile;
    }
}
