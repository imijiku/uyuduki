using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject _switchCheck = null;
    public StageCtrl stageCtrl;
    public SwitchCheck switchCheck;
    public Sprite NormalSwitch;
    public Sprite PushedSwitch;
    public AudioClip SwitchSE;

    private SpriteRenderer sr = null;
    private GameObject SE;
    public bool isPushed = false;
    private bool sound = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        SE = GameObject.Find("SEManager");
    }

    // Update is called once per frame
    void Update()
    {
        isPushed = switchCheck.IsPushed();
        if(!isPushed)
        {
            if(sound)
            {
                SE.GetComponent<ChangeSEVolume>().PlaySE(SwitchSE);
                sound = false;
            }
            if(sr.sprite != NormalSwitch)
            {
                sr.sprite = NormalSwitch;
            }
            if(_switchCheck.tag == "RedSwitch")
            {
                stageCtrl.Red = false;
            }
            if(_switchCheck.tag == "BlueSwitch")
            {
                stageCtrl.Blue = false;
            }
            if (_switchCheck.tag == "YellowSwitch")
            {
                stageCtrl.Yellow = false;
            }
        }
        else
        {
            if(!sound)
            {
                SE.GetComponent<ChangeSEVolume>().PlaySE(SwitchSE);
                sound = true;
            }
            if(sr.sprite != PushedSwitch)
            {
                sr.sprite = PushedSwitch;
            }
            if (_switchCheck.tag == "RedSwitch")
            {
                stageCtrl.Red = true;
            }
            if (_switchCheck.tag == "BlueSwitch")
            {
                stageCtrl.Blue = true;
            }
            if (_switchCheck.tag == "YellowSwitch")
            {
                stageCtrl.Yellow = true;
            }
        }
    }
}
