using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour {

    public GameManager gameManager;
    public AudioSource BGMSource;
    public AudioClip[] BGMs;

    private bool BGM_2_played = false;
    private bool BGM_3_played = false;
    private bool BGM_4_played = false;
    private bool BGM_5_played = false;

    // Use this for initialization
    void Start () {
        BGMSource.clip = BGMs[0];
        BGMSource.loop = true;
        BGMSource.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (!BGM_2_played)
        {
            if (gameManager.isChangeWeather2)
            {
                BGMSource.clip = BGMs[1];
                BGMSource.loop = true;
                BGMSource.Play();
                BGM_2_played = true;
            }
        }
        if (!BGM_3_played)
        {
            if (gameManager.isChangeWeather)
            {
                BGMSource.clip = BGMs[2];
                BGMSource.loop = true;
                BGMSource.Play();
                BGM_3_played = true;
            }
        }
        if (!BGM_4_played)
        {
            if (gameManager.Cp4_ToVoice2Timer>7)
            {
                BGMSource.clip = BGMs[3];
                BGMSource.loop = true;
                BGMSource.Play();
                BGM_4_played = true;
            }
        }
        if (!BGM_5_played)
        {
            if (GameManager.currentChapter == GameManager.Chapter.Chapter5)
            {
                BGMSource.clip = BGMs[4];
                BGMSource.loop = true;
                BGMSource.Play();
                BGM_5_played = true;
            }
        }
    }
}
