using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySwitchCheck : MonoBehaviour
{
    public Player player;
    private string playerTag = "Player";
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
        if (collision.tag == playerTag && player.pMode == Player.PlayerMode.HEAVY)
        {
            isPushedEnter = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == playerTag && player.pMode == Player.PlayerMode.HEAVY)
        {
            isPushedStay = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == playerTag && player.pMode == Player.PlayerMode.HEAVY)
        {
            isPushedExit = true;
        }
    }
}
