using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIButtonHandler : MonoBehaviour
{
    public GameObject menu;
    //public GameObject guiBtn;
    private bool sceneLoaded = false;
    private bool gamePaused = false;
    public void Update()
    {
        showPauseMenu();
    }
    public void loadGame()
    {
        //load level one
        //when i load this level I want the canvas to populate to the new level
        DontDestroyOnLoad(this.gameObject);
        menu.SetActive(false);
        sceneLoaded = true;
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        //this only works on a full build
        Application.Quit();
        Debug.Log("Exit App");
    }
    private void showPauseMenu()
    {
        if(Input.GetKeyDown(KeyCode.P) && sceneLoaded)
        {
            if(!gamePaused)
            {
                //Debug.Log("pause menu");
                menu.SetActive(true);
                Time.timeScale = 0;
                gamePaused = true;
            }
            else
            {
                menu.SetActive(false);
                Time.timeScale = 1;
                gamePaused = false;
            }

        }
    }
}
