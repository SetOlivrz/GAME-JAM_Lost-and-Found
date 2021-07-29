using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip walkingSound;
    [SerializeField] AudioClip runningSound;
    [SerializeField] AudioClip buttonSound;

    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK, playWalkingSound);
        

        //ui button clicks
        EventBroadcaster.Instance.AddObserver(EventNames.ON_OPTIONS_MENU, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PAUSE_GAME, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_RESUME_GAME, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_QUIT_TO_MENU, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_QUIT_GAME, playButtonSound);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK_STOP, stopWalkingSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_CAUGHT, stopWalkingSound);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_WALK);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_WALK_STOP);
    }
    private void playWalkingSound(Parameters parameters)
    {
        bool isWalking = parameters.GetBoolExtra("isWalking", false);

        if (isWalking)
            audioSource.clip = walkingSound;

        else
            audioSource.clip = runningSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    private void stopWalkingSound()
    {
        if (audioSource.clip == walkingSound || audioSource.clip == runningSound)
            audioSource.Stop();
    }

    private void playButtonSound()
    {
        audioSource.PlayOneShot(buttonSound);
    }
    
    private void stopAllSounds()
    {
        audioSource.Stop();
    }
}
