using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMSlider : MonoBehaviour
{
    Slider b_slider;
    GameObject bgm = null;
    ChangeBGMVolume cbgm;

    // Start is called before the first frame update
    void Awake()
    {
        b_slider = GetComponent<Slider>();
        bgm = GameObject.Find("BGMManager");
        cbgm = bgm.GetComponent<ChangeBGMVolume>();
        b_slider.onValueChanged.AddListener((value) => { cbgm.BGMSliderOnValueChange((float)value); });
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
