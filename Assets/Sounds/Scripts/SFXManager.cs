using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioClip walkingSound;
    [SerializeField] AudioClip runningSound;
    [SerializeField] AudioClip buttonSound;
    [SerializeField] AudioClip jumpStartSound;
    [SerializeField] AudioClip jumpEndSound;
    [SerializeField] AudioClip caughtSound;
    [SerializeField] AudioClip keypickupSound;

    [SerializeField] private AudioSource audioSourceSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceSFX = this.gameObject.GetComponent<AudioSource>();

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK_SFX, playWalkingSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK_STOP_SFX, stopWalkingSound);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_JUMP_START_SFX, playJumpStartSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_JUMP_END_SFX, playJumpEndSound);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_CAUGHT, playCaughtSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_CAUGHT, stopWalkingSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_KEY_GET, playKeyGetSound);

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAY_BUTTON_SFX, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_STOP_ALL_SFX, stopAllSounds);

    }

    private void OnDestroy()
    {
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_WALK_SFX);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_WALK_STOP_SFX);

        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_JUMP_END_SFX);

        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_CAUGHT);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAYER_CAUGHT);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_KEY_GET);

        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PLAY_BUTTON_SFX);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_STOP_ALL_SFX);

    }

    // Update is called once per frame
    void Update()
    {

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

        //Debug.Log("play walking sound");
    }

    private void stopWalkingSound()
    {
        if (audioSourceSFX != null)
        {
            if ((audioSourceSFX.clip == walkingSound || audioSourceSFX.clip == runningSound) && audioSourceSFX.isPlaying == true)
                audioSourceSFX.Stop();
        }
        Debug.Log("Stop walking sound");
        
    }

    private void playJumpStartSound()
    {
        if (jumpStartSound != null)
            AudioSource.PlayClipAtPoint(jumpStartSound, transform.position, audioSourceSFX.volume);

        else Debug.Log("no jumpstart sound file attached");
    }

    private void playJumpEndSound()
    {
        if (jumpEndSound != null)
            AudioSource.PlayClipAtPoint(jumpEndSound, transform.position, audioSourceSFX.volume);

        else Debug.Log("no jumpend sound file attached");
    }

    private void playCaughtSound()
    {
        //audioSourceSFX.clip = jumpStartSound;
        if (caughtSound != null)
            AudioSource.PlayClipAtPoint(caughtSound, transform.position, audioSourceSFX.volume);

        else Debug.Log("no caught sound file attached");
    }

    private void playButtonSound()
    {
        audioSourceSFX.PlayOneShot(buttonSound);
    }

    private void playKeyGetSound()
    {
        AudioSource.PlayClipAtPoint(keypickupSound, transform.position, audioSourceSFX.volume);
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
