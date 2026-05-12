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
}
