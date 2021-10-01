using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GManager : MonoBehaviour
{
    public static GManager instance = null;
    [HideInInspector] public float BGMSoundValue = 0.05f;
    [HideInInspector] public float SESoundValue = 0.3f;
    private CinemachineVirtualCamera _camera;
    public bool isBGMPlayed = false;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {

    }

    private void Update()
    {
    }

}
