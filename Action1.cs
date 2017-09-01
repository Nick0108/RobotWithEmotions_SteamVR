using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;


public class Action1 : MonoBehaviour {
    public PlayableDirector UTCplayable;
    public Readable startbook;
    public GameObject Happyball;
    public bool Get = false;
    public GameObject UTC;

    void Update () {
        if (currentChapter == Chapter.Chapter1)
        {
            if (startbook.EventNowHappen)
            {
                UTCplayable01.Play();
                startbook.EventNowHappen = false;
            }
            if (GetHappyBall)
                UTCplayable01.Resume();
            else if (UTCplayable01.time > 12.42)
            {
                UTCplayable01.Pause();
                Happyball.SetActive(true);
            }

            if (UTCplayable01.time > 19.15)
            {
                UTCplayable01.Stop();
                UTC01.SetActive(false);
                currentChapter = Chapter.Chapter2;
            }
        }
    }

    
}
