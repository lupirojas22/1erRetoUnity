using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{

    public AudioSource audioSource;

    public Sprite musicOnSprite;   // img cuando la música está activa
    public Sprite musicOffSprite;  // img cuando la música está pausada
    private Image buttonImage;
   
    

public void ToggleMusic()
    {
        buttonImage = GetComponent<Image>();
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
            buttonImage.sprite = musicOffSprite;

        }
        else
        {
            audioSource.UnPause();
            buttonImage.sprite = musicOnSprite;

        }
    }

}
