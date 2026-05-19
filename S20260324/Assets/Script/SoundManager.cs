using UnityEngine;




public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;

    public AudioClip clipBGM;
    public AudioClip clipFX;

    AudioSource audioSourceFX;
    AudioSource audioSourceBGM;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        Instance = this;


        audioSourceFX = gameObject.AddComponent<AudioSource>();
        audioSourceBGM = gameObject.AddComponent<AudioSource>();

        audioSourceFX.clip = clipFX;


    }

    public void PlaySound()
    {
        audioSourceFX.PlayOneShot(clipFX);

    }

    public void PlayBGM()
    {
        audioSourceBGM.clip = clipBGM;

        audioSourceBGM.loop = true;

        audioSourceBGM.Play();
    }




    public void OnOffBGM(bool isOn)
    {
        if (isOn)
        {
            audioSourceBGM.volume = 1f;
        }
        else
        {
            audioSourceBGM.volume = 0f;
        }
    }

    public void OnOffFX(bool isOn)
    {
        if (isOn)
        {
            audioSourceFX.volume = 1f;
        }
        else
        {
            audioSourceFX.volume = 0f;
        }
    }
    public void SetBGMVolume(float volume)
    {
        audioSourceBGM.volume = volume;
    }

    public void SetFXVolume(float volume)
    {
        audioSourceFX.volume = volume;
    }
}
