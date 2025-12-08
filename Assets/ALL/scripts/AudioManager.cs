using UnityEngine;

public class WeatherAudioManager : MonoBehaviour
{
    public AudioClip InsideClip;
    public AudioClip OutsideClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayOutsideRain();
    }

    public void PlayOutsideRain()
    {
        if (audioSource.clip != InsideClip)
        {
            audioSource.Stop(); // 
            audioSource.clip = InsideClip;
            audioSource.Play();
        }
    }

    public void PlayInsideRain()
    {
        if (audioSource.clip != OutsideClip)
        {
            audioSource.Stop(); // 
            audioSource.clip = OutsideClip;
            audioSource.Play();
        }
    }
}
