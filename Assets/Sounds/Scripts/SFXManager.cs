using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioClip walkingSound;
    [SerializeField] AudioClip runningSound;
    [SerializeField] AudioClip buttonSound;

    [SerializeField] private AudioSource audioSourceSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceSFX = this.gameObject.GetComponent<AudioSource>();
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK, playWalkingSound);
        

        //ui button clicks
        EventBroadcaster.Instance.AddObserver(EventNames.ON_OPTIONS_MENU, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PAUSE_GAME, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_RESUME_GAME, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_QUIT_TO_MENU, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_QUIT_GAME, playButtonSound);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK_STOP, stopWalkingSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_CAUGHT, stopWalkingSound);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_STOP_ALL_SOUNDS, stopAllSounds);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_WALK);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_WALK_STOP);

        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_OPTIONS_MENU);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PAUSE_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_RESUME_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_QUIT_TO_MENU);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_QUIT_GAME);
    }
    private void playWalkingSound(Parameters parameters)
    {
        bool isWalking = parameters.GetBoolExtra("isWalking", false);

        if (isWalking)
            audioSourceSFX.clip = walkingSound;

        else
            audioSourceSFX.clip = runningSound;
        if (!audioSourceSFX.isPlaying)
            audioSourceSFX.Play();
    }

    private void stopWalkingSound()
    {
        if (audioSourceSFX.clip == walkingSound || audioSourceSFX.clip == runningSound)
            audioSourceSFX.Stop();
    }

    private void playButtonSound()
    {
        audioSourceSFX.PlayOneShot(buttonSound);
    }
    
    private void stopAllSounds()
    {
        audioSourceSFX.Stop();
    }
}
