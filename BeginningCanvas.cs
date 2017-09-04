using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningCanvas : MonoBehaviour {
    public CanvasGroup Line1;
    public CanvasGroup Line2;
    public CanvasGroup Line3;
    public CanvasGroup Line4;
    public CanvasGroup Line5;
    public CanvasGroup Line6;
    public CanvasGroup Line7;
    public CanvasGroup StartButon;
    public float TimeLine;
    public float FadeTime = 1.2f;
    public SteamVR_LoadLevel loadLevel;

    private bool Begin = false;
    private bool Question = false;

    private float FadeInTimer;
    private float FadeOutTimer;

    public bool testing = false;

    private void Start()
    {
        TimeLine = 0.00f;
    }

    private void Update()
    {
        if (Begin)
        {
            TimeLine += Time.deltaTime;
            Fadeout(StartButon);
            if (TimeLine > 1.5f && TimeLine < 1.5f + FadeTime) 
            {
                StartButon.gameObject.SetActive(false);
                Fadein(Line1);
            }
            if (TimeLine > 2.7f && TimeLine < 2.7f + FadeTime)
            {
                Fadein(Line2);
            }
            if (TimeLine > 7.0f && TimeLine < 7.0f + FadeTime)
            {
                Fadeout(Line1);
                Fadeout(Line2);
            }
            if (TimeLine > 8.2f && TimeLine < 8.2f + FadeTime)
            {
                Fadein(Line3);
            }
            if (TimeLine > 9.4f && TimeLine < 9.4f + FadeTime)
            {
                Fadein(Line4);
            }
            if (TimeLine > 11.0f)
                Begin = false;
        }
        if (Question)
        {
            TimeLine += Time.deltaTime;
            Fadeout(Line3);
            Fadeout(Line4);
            if (TimeLine > 12.2f && TimeLine < 12.2f + FadeTime)
            {
                Line4.gameObject.SetActive(false);
                Fadein(Line5);
            }
            if (TimeLine > 13.5f && TimeLine < 13.5f + FadeTime)
            {
                Fadein(Line6);
            }
            if (TimeLine > 19.7f && TimeLine < 19.7f + FadeTime)
            {
                Fadeout(Line5);
                Fadeout(Line6);
            }
            if (TimeLine > 21.0f && TimeLine < 21.0f + FadeTime)
            {
                Fadein(Line7);
            }
            if (TimeLine > 22.2f && TimeLine < 22.2f + FadeTime)
            {
                Fadeout(Line7);
            }
            if (TimeLine > 27.0f)
            {
                Question = false;
                loadLevel.Trigger();
            }
                
        }
    }

    public void StartGame()
    {
        Begin = true;
    }

    public void ContinueGame()
    {
        Question = true;
    }

    void Fadeout(CanvasGroup canvas,float time = 1.0f)
    {
        if (canvas.alpha >0)
        {
            canvas.alpha -= (Time.deltaTime / time);
        }
    }

    void Fadein(CanvasGroup canvas, float time = 1.0f)
    {
        if (canvas.alpha < 1)
        {
            canvas.alpha += (Time.deltaTime / time);
        }
    }
}
