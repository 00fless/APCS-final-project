using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{public CanvasGroup canvasGroup;
    private bool isPaused = false;

    void Start()
    {
        Time.timeScale = 1f;
        hideMenu();
    }

    void Update()
    {
        //gets key inputs to pause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                resume();
            }  
            else
            { 
                pause();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Q))
        {
            quitGame();
        }
    }

    // methods to do in update
    public void resume()
    {
        hideMenu();
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void pause()
    {
        ShowMenu();
        Time.timeScale = 0f;
        isPaused = true;
    }

    //methods to do in resume and pause respectively
    private void ShowMenu()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    private void hideMenu()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
