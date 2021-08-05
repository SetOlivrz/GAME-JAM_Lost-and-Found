using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] AudioClip walkingSound = null;
    [SerializeField] AudioClip runningSound = null;
    [SerializeField] AudioClip buttonSound = null;
    [SerializeField] AudioClip jumpStartSound = null;
    [SerializeField] AudioClip jumpEndSound = null;
    [SerializeField] AudioClip caughtSound = null;
    [SerializeField] AudioClip keypickupSound = null;

    [SerializeField] private AudioSource audioSourceSFX;
    // Start is called before the first frame update
    void Start()
    {
        audioSourceSFX = this.gameObject.GetComponent<AudioSource>();

        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK_SFX, playWalkingSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_JUMP_START_SFX, playJumpStartSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_JUMP_END_SFX, playJumpEndSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_CAUGHT, playCaughtSound  );
        EventBroadcaster.Instance.AddObserver(EventNames.ON_KEY_GET, playKeyGetSound);


        //ui button clicks
        EventBroadcaster.Instance.AddObserver(EventNames.ON_OPTIONS_MENU, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_PAUSE_GAME, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_RESUME_GAME, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_RESUME_GAME, resumeAllSounds);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_QUIT_TO_MENU, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_QUIT_GAME, playButtonSound);
        EventBroadcaster.Instance.AddObserver(EventNames.ON_START_GAME, playButtonSound);


        EventBroadcaster.Instance.AddObserver(EventNames.ON_PLAYER_WALK_STOP_SFX, stopWalkingSound);
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

        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_OPTIONS_MENU);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_PAUSE_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_RESUME_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_QUIT_TO_MENU);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_QUIT_GAME);
        EventBroadcaster.Instance.RemoveObserver(EventNames.ON_START_GAME);

    }
    private void playWalkingSound(Parameters parameters)
    {
        bool isWalking = parameters.GetBoolExtra("isWalking", false);

        if(walkingSound != null)
        {
            if (isWalking)
                audioSourceSFX.clip = walkingSound;

            else
                audioSourceSFX.clip = runningSound;
            if (!audioSourceSFX.isPlaying)
                audioSourceSFX.Play();
        }
        

        //Debug.Log("play walking sound");
    }

    private void stopWalkingSound()
    {
        if (audioSourceSFX != null)
        {
            if ((audioSourceSFX.clip == walkingSound || audioSourceSFX.clip == runningSound) && audioSourceSFX.isPlaying == true)
                audioSourceSFX.Stop();
        }
        //Debug.Log("Stop walking sound");
        
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
        if(keypickupSound != null)
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

    private void resumeAllSounds()
    {
        if(audioSourceSFX != null)
        {
            audioSourceSFX.Play();
        }
    }
}
