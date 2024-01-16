using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private Player player;
    [SerializeField] private PlayerAttack playerAttack;


    private bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        ResumeGame();
        gameInput.OnOpenPausedAction += GameInput_OnOpenPausedAction;

    }


    private void GameInput_OnOpenPausedAction(object sender, System.EventArgs e)
    {
        if (isPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;


        player.enabled = false;
       
    }



    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        player.enabled = true;

    }



    #region Button Functions
    public void OnContinuePress()
    {
       ResumeGame();
    }

    
    public void OnMainMenuPress()
    {
        // load scene 0
        SceneManager.LoadScene(0);
    }

    public void OnQuitPress()
    {
        Application.Quit();
    }


    #endregion
}
