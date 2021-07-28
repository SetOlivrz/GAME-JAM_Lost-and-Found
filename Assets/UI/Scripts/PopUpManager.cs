using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject CaughtUI;


    // Start is called before the first frame update
    void Start()
    {
        CaughtUI.SetActive(false);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_CAUGHT, this.OnCaughtTrigger);
    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_CAUGHT);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 1;
            
            //Respawn Player
            EventBroadcaster.Instance.PostEvent(EventNames.ON_PLAYER_RESPAWN);

            //Remove Key UI
            EventBroadcaster.Instance.PostEvent(EventNames.ON_KEY_LOST);

            //Respawn Key
            EventBroadcaster.Instance.PostEvent(EventNames.ON_KEY_SPAWN);

            CaughtUI.SetActive(false);
            Debug.Log("Continue Game");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Exit Game");
            Application.Quit();
        }
    }

    private void OnCaughtTrigger()
    {
        CaughtUI.SetActive(true);
    }
}
