using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCheck : MonoBehaviour
{
    private string playerTag = "Player";
    private string parts1Tag = "Parts1";
    private string parts2Tag = "Parts2";
    private bool isPushed = false;
    private bool isPushedEnter, isPushedStay, isPushedExit;

    public bool IsPushed()
    {
        if (isPushedEnter || isPushedStay)
        {
            isPushed = true;
        }
        else if (isPushedExit)
        {
            isPushed = false;
        }

        isPushedEnter = false;
        isPushedStay = false;
        isPushedExit = false;
        return isPushed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == playerTag || collision.tag == parts1Tag || collision.tag == parts2Tag)
        {
            isPushedEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == playerTag || collision.tag == parts1Tag || collision.tag == parts2Tag)
        {
            isPushedStay = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag || collision.tag == parts1Tag || collision.tag == parts2Tag)
        {
            isPushedExit = true;
        }
    }
}
