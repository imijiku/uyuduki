using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class StageCtrl : MonoBehaviour
{
    public GameObject playerObj;
    public FadeImage fade;
    public int nextStageNum;
    public bool Red = false;
    public bool Blue = false;
    public bool Yellow = false;


    private Player player;
    private bool startFade = false;
    private float timer = 0.0f;
    private CinemachineVirtualCamera _camera;

    // Start is called before the first frame update
    void Start()
    {
        player = playerObj.GetComponent<Player>();
        GameObject camera = GameObject.Find("CM vcam1");
        _camera = camera.GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.isGoal)
        {
            if (timer < 1.0f)
            {
                _camera.m_Lens.OrthographicSize = 6.0f - 4.0f * timer;
                timer += Time.deltaTime;
            }
            else
            {
                _camera.m_Lens.OrthographicSize = 2.0f;
                fade.StartFadeOut();
                startFade = true;
                player.isGoal = false;
                timer = 0.0f;
            }
        }
        if(fade != null && startFade)
        {
            if (fade.IsFadeOutComplete())
            {
                Debug.Log("Faded");
                SceneManager.LoadScene("Stage" + nextStageNum);
            } 
        }
    }
}
