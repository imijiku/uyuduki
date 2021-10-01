using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavuSwitch : MonoBehaviour
{
    public Player player;
    public GameObject _switchCheck = null;
    public StageCtrl stageCtrl;
    public HeavySwitchCheck heavySwitchCheck;
    public Sprite NormalSwitch;
    public Sprite PushedSwitch;
    public AudioClip SwitchSE;

    private SpriteRenderer sr = null;
    private BoxCollider2D bc = null;
    private GameObject SE;
    public bool isPushed = false;
    private bool sound = false;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
        SE = GameObject.Find("SEManager");
    }

    // Update is called once per frame
    void Update()
    {
        isPushed = heavySwitchCheck.IsPushed();
        if(player.pMode != Player.PlayerMode.HEAVY)
        {
            if (sound)
            {
                SE.GetComponent<ChangeSEVolume>().PlaySE(SwitchSE);
                sound = false;
            }
            bc.offset = new Vector2(0f, 0f);
            bc.size = new Vector2(1f, 0.5f);
            if (sr.sprite != NormalSwitch)
            {
                sr.sprite = NormalSwitch;
            }
            if (_switchCheck.tag == "RedSwitch")
            {
                stageCtrl.Red = false;
            }
            if (_switchCheck.tag == "BlueSwitch")
            {
                stageCtrl.Blue = false;
            }
            if (_switchCheck.tag == "YellowSwitch")
            {
                stageCtrl.Yellow = false;
            }
        }
        else if (!isPushed)
        {
            if (sound)
            {
                SE.GetComponent<ChangeSEVolume>().PlaySE(SwitchSE);
                sound = false;
            }
            bc.offset = new Vector2(0f, 0f);
            bc.size = new Vector2(1f, 0.5f);
            if (sr.sprite != NormalSwitch)
            {
                sr.sprite = NormalSwitch;
            }
            if (_switchCheck.tag == "RedSwitch")
            {
                stageCtrl.Red = false;
            }
            if (_switchCheck.tag == "BlueSwitch")
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
            if (!sound)
            {
                SE.GetComponent<ChangeSEVolume>().PlaySE(SwitchSE);
                sound = true;
            }
            bc.offset = new Vector2(0f, -0.125f);
            bc.size = new Vector2(1f, 0.25f);
            if (sr.sprite != PushedSwitch)
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
