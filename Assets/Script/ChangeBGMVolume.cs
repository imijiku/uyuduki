using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeBGMVolume : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject BGMSlider = null;
    public GameObject _parent = null;
    public GameObject parent = null;
    private Slider b_slider;
    public AudioClip Title;
    public AudioClip Stage;
    public AudioClip Clear;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        BGMSlider = GameObject.Find("BGMSlider");
        b_slider = BGMSlider.GetComponent<Slider>();
        audioSource.volume = GManager.instance.BGMSoundValue;
        b_slider.value = audioSource.volume;
        PlayBGM();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if(SceneManager.GetActiveScene().name == "Title") 
        {
            BGMSlider = GameObject.Find("BGMSlider");
            b_slider = BGMSlider.GetComponent<Slider>();
        }
        else if(SceneManager.GetActiveScene().name != "Stage99")
        {
            _parent = GameObject.Find("Canvas");
            parent = _parent.transform.Find("Menu").gameObject;
            BGMSlider = parent.transform.Find("BGMSlider").gameObject;
            b_slider = BGMSlider.GetComponent<Slider>();
        }
        audioSource.volume = GManager.instance.BGMSoundValue;
        b_slider.value = audioSource.volume;
        PlayBGM();
    }

    private void PlayBGM()
    {
        if (SceneManager.GetActiveScene().name == "Title")
        {
            audioSource.Stop();
            audioSource.clip = Title;
            audioSource.Play();
        }
        if (SceneManager.GetActiveScene().name == "Stage1")
        {
            if(!GManager.instance.isBGMPlayed)
            {
                audioSource.Stop();
                audioSource.clip = Stage;
                audioSource.Play();
                GManager.instance.isBGMPlayed = true;
            }
        }
        if (SceneManager.GetActiveScene().name == "Stage99")
        {
            audioSource.Stop();
            audioSource.clip = Clear;
            audioSource.Play();
        }
    }
    public void BGMSliderOnValueChange(float newSliderValue)
    {
        GManager.instance.BGMSoundValue = newSliderValue;
        audioSource.volume = newSliderValue;
    }
}
