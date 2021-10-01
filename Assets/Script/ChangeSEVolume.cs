using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSEVolume : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject BGMSlider;
    public GameObject SESlider;
    private Slider s_slider;
    private Slider b_slider;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        s_slider = SESlider.GetComponent<Slider>();
        audioSource.volume = GManager.instance.SESoundValue;
        s_slider.value = audioSource.volume;
    }

    public void SESliderOnValueChange(float newSliderValue)
    {
        GManager.instance.SESoundValue = newSliderValue;
        audioSource.volume = newSliderValue;
    }

    public void PlaySE(AudioClip clip)
    {
        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("No Audio Source");
        }
    }
}
