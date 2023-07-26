using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{

    public AudioSource audioSource;

    public Sprite musicOnSprite;   // img cuando la m�sica est� activa
    public Sprite musicOffSprite;  // img cuando la m�sica est� pausada
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
