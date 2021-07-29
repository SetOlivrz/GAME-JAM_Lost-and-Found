using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{

    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Toggle bgmToggle;

    SFXManager[] sfxList;
    BGMManager[] bgmList;

    // Start is called before the first frame update
    void Start()
    {
        sfxList = FindObjectsOfType(typeof(SFXManager)) as SFXManager[];
        for (int i = 0; i < sfxList.Length; i++)
        {
            Debug.Log(sfxList.Length);
        }


        bgmList = FindObjectsOfType(typeof(BGMManager)) as BGMManager[];
        for (int i = 0; i < bgmList.Length; i++)
        {
            Debug.Log(bgmList.Length);
        }


    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void CheckSFXToggle()
    {
        if (sfxToggle.isOn == false)
        {
            EventBroadcaster.Instance.PostEvent(EventNames.ON_STOP_ALL_SOUNDS);
        }

        for (int i = 0; i < sfxList.Length; i++)
        {
            if (sfxToggle.isOn)
            {
                sfxList[i].enabled = true;
                sfxList[i].gameObject.GetComponent<AudioSource>().mute = false;
            }
            else
            {
                sfxList[i].enabled = false;
                sfxList[i].gameObject.GetComponent<AudioSource>().mute = true;
            }
        }
    }

    public void checkMusicToggle()
    {
        if (sfxToggle.isOn == false)
        {
            EventBroadcaster.Instance.PostEvent(EventNames.ON_STOP_ALL_BGM);
        }

        for (int i = 0; i < bgmList.Length; i++)
        {
            if (bgmToggle.isOn)
            {
                bgmList[i].enabled = true;
                bgmList[i].gameObject.GetComponent<AudioSource>().mute = false;
            }
            else
            {
                bgmList[i].enabled = false;
                bgmList[i].gameObject.GetComponent<AudioSource>().mute = true;
            }
        }
    }
}
