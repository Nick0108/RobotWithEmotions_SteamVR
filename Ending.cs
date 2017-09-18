using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour {

    public CanvasGroup[] Lines;
    public float timer;
    public int LinesNum;
    public int LinesIndex;
    public float LineInterval = 6.0f;
    public SteamVR_LoadLevel loadLevel;

    private void Start()
    {
        foreach(CanvasGroup CG in Lines)
        {
            CG.gameObject.SetActive(true);
            CG.alpha = 0;
        }
        LinesNum = Lines.Length;
        LinesIndex = 0;
    }

    private void Update()
    {
        ShowTheLine();
    }

    void ShowTheLine()
    {
        timer += Time.deltaTime;
        if (timer < LineInterval / 3)
        {
            Fadein(Lines[LinesIndex]);
        }
        else if (timer > LineInterval * 2 / 3)
        {
            Fadeout(Lines[LinesIndex]);
        }
        if (timer > LineInterval)
        {
            LinesIndex++;
            if (LinesIndex > LinesNum-1)
            {
                LinesIndex = LinesNum-1;
                loadLevel.levelName = "Beginning";
                loadLevel.Trigger();
                return;
            }
            timer = 0;
        }
    }

    void Fadeout(CanvasGroup canvas, float time = 1.0f)
    {
        if (canvas.alpha > 0)
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
