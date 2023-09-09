using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{

    private PlayerMovement playermovement;
    private AudioSource AudioSource;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip crashSound;


    private bool isAudioPlayed=false;

    private void Start()
    {
        playermovement= GetComponent<PlayerMovement>();
        AudioSource = GetComponent<AudioSource>();

    }
    private void OnCollisionEnter(Collision collision)
    {

        switch (collision.gameObject.tag)
        {
       
            case "Finish":
                PlaySoundEffects(winSound);
                DisablePlayerMovement();
                Invoke("FinishSequence",0.5f);
                
                break;

            case "Friendly":
                
               

                break;


            default:
                PlaySoundEffects(crashSound);
                DisablePlayerMovement();
                Invoke("CrashSequence", 0.5f);


                break;
        }

    }
    private void FinishSequence()
    {
        int currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentBuildIndex == SceneManager.sceneCount) 
        {
            currentBuildIndex = 0;
        }
        else
        {
            currentBuildIndex++;
        }
        SceneManager.LoadScene(currentBuildIndex);
    }
    private void CrashSequence()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

                
    private void DisablePlayerMovement() 
    {

        playermovement.enabled = false;

    }


    private void PlaySoundEffects(AudioClip myAudioClip)
    {
        if (!isAudioPlayed)
        {
            AudioSource.Stop();
            AudioSource.PlayOneShot(myAudioClip);
            isAudioPlayed = true;
        }
      
    }

}
