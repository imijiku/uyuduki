using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public FadeImage fade;

    private bool firstPush = false;
    private bool goNextScene = false;
    private GameObject SE;
    public AudioClip ClickSE;

    private void Start()
    {
        SE = GameObject.Find("SEManager");
    }
    public void PressStart()
    {
        if(!firstPush)
        {
            Time.timeScale = 1.0f;
            SE.GetComponent<ChangeSEVolume>().PlaySE(ClickSE);
            fade.StartFadeOut();
            firstPush = true;
        }
    }

    private void Update()
    {
        if(!goNextScene && fade.IsFadeOutComplete())
        {
            if(SceneManager.GetActiveScene().name == "Title")
            {
                SceneManager.LoadScene("Stage1");
            }
            else
            {
                SceneManager.LoadScene("Title");
                GManager.instance.isBGMPlayed = false;
            }
            goNextScene = true;
        }
    }
}
