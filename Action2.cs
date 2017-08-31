using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

    public class Action2 : MonoBehaviour {
    public PlayableDirector UTCplayable;
    public GameObject UTC;
    public bool start = false;
    private bool hasPlay = false;


    private void Update()
    {
        if (!hasPlay)
        {
            if (start)
            {
                UTCplayable.Play();
                hasPlay = true;
            } 
        }
        if (UTCplayable.time > 8.8)
            UTC.SetActive(false);
    }
}
