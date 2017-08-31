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
        if (startbook.EventNowHappen)
        {
            UTCplayable.Play();
            startbook.EventNowHappen = false;
        }
        if (Get)
            UTCplayable.Resume();
        else if (UTCplayable.time > 12.42)
        {
            UTCplayable.Pause();
            Happyball.SetActive(true);
        }
            
        if (UTCplayable.time > 19.15)
        {
            UTCplayable.Stop();
            UTC.SetActive(false);
        }
    }

    
}
