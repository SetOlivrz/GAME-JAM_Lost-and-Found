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
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK_SFX, playWalkingSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK_STOP_SFX, stopWalkingSound);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAY_BUTTON_SFX, playButtonSound);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_CAUGHT, stopWalkingSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_STOP_ALL_SFX, stopAllSounds);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_WALK_SFX);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_WALK_STOP_SFX);

        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAY_BUTTON_SFX);

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
        if (audioSourceSFX != null)
        {
            if (audioSourceSFX.clip == walkingSound || audioSourceSFX.clip == runningSound)
                audioSourceSFX.Stop();
        }
        
    }

    private void playButtonSound()
    {
        audioSourceSFX.PlayOneShot(buttonSound);
    }
    
    private void stopAllSounds()
    {
        if (audioSourceSFX != null)
        {
            if (audioSourceSFX.isPlaying)
                audioSourceSFX.Stop();
        }
        
    }
}
