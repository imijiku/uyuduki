using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public StageCtrl stageCtrl;
    private SpriteRenderer sr = null;
    private BoxCollider2D bc = null;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.tag == "RedBlock")
        {
            if(stageCtrl.Red)
            {
                sr.color = new Color(1, 1, 1, 0.5f);
                bc.enabled = false;
            }
            else
            {
                sr.color = new Color(1, 1, 1, 1);
                bc.enabled = true;
            }
        }
        if (transform.tag == "BlueBlock")
        {
            if (stageCtrl.Blue)
            {
                sr.color = new Color(1, 1, 1, 0.5f);
                bc.enabled = false;
            }
            else
            {
                sr.color = new Color(1, 1, 1, 1);
                bc.enabled = true;
            }
        }
        if (transform.tag == "YellowBlock")
        {
            if (stageCtrl.Yellow)
            {
                sr.color = new Color(1, 1, 1, 0.5f);
                bc.enabled = false;
            }
            else
            {
                sr.color = new Color(1, 1, 1, 1);
                bc.enabled = true;
            }
        }
        if (transform.tag == "ReverseRedBlock")
        {
            if (!stageCtrl.Red)
            {
                sr.color = new Color(1, 1, 1, 0.5f);
                bc.enabled = false;
            }
            else
            {
                sr.color = new Color(1, 1, 1, 1);
                bc.enabled = true;
            }
        }
        if (transform.tag == "ReverseBlueBlock")
        {
            if (!stageCtrl.Blue)
            {
                sr.color = new Color(1, 1, 1, 0.5f);
                bc.enabled = false;
            }
            else
            {
                sr.color = new Color(1, 1, 1, 1);
                bc.enabled = true;
            }
        }
        if (transform.tag == "ReverseYellowBlock")
        {
            if (!stageCtrl.Yellow)
            {
                sr.color = new Color(1, 1, 1, 0.5f);
                bc.enabled = false;
            }
            else
            {
                sr.color = new Color(1, 1, 1, 1);
                bc.enabled = true;
            }
        }
    }
}
