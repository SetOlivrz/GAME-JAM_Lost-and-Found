using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ButtonFunctions : MonoBehaviour
{
    [SerializeField] private GameObject PausedUI;

    // Start is called before the first frame update
    void Start()
    {
        PausedUI.SetActive(false);

        //  OptionsPopUp.SetActive(false);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_START_GAME, this.StartGame);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_OPTIONS_MENU, this.OptionsMenu);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_QUIT_GAME, this.QuitGame);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PAUSE_GAME, this.PauseGame);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_RESUME_GAME, this.ResumeGame);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_QUIT_TO_MENU, this.QuitToMenu);



    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_START_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_OPTIONS_MENU);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_QUIT_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PAUSE_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_RESUME_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_QUIT_TO_MENU);






    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(sceneName:"Game Proper");
    }
    public void OptionsMenu()
    {
   //     OptionsPopUp.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void QuitToMenu()
    {
        //PausedUI.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName: "Game Menu");
    }

    public void PauseGame()
    {
        PausedUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PausedUI.SetActive(false);
        Time.timeScale = 1;
    }

}

