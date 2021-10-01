using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private string groundTag = "Ground";
    private string switchTag = "Switch";
    private string redBlockTag = "RedBlock";
    private string blueBlockTag = "BlueBlock";
    private string yellowBlockTag = "YellowBlock";
    private string RredBlockTag = "ReverseRedBlock";
    private string RblueBlockTag = "ReverseBlueBlock";
    private string RyellowBlockTag = "ReverseYellowBlock";
    private bool isGround = false;
    private bool isGroundEnter, isGroundStay, isGroundExit;

    public bool IsGround()
    {
        if(isGroundEnter || isGroundStay)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }

        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == switchTag || collision.tag == redBlockTag || collision.tag == blueBlockTag || collision.tag == yellowBlockTag || collision.tag == RredBlockTag || collision.tag == RblueBlockTag || collision.tag == RyellowBlockTag)
        {
            isGroundEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == switchTag || collision.tag == redBlockTag || collision.tag == blueBlockTag || collision.tag == yellowBlockTag || collision.tag == RredBlockTag || collision.tag == RblueBlockTag || collision.tag == RyellowBlockTag)
        {
            isGroundStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == groundTag || collision.tag == switchTag || collision.tag == redBlockTag || collision.tag == blueBlockTag || collision.tag == yellowBlockTag || collision.tag == RredBlockTag || collision.tag == RblueBlockTag || collision.tag == RyellowBlockTag)
        {
            isGroundExit = true;
        }
    }
}
