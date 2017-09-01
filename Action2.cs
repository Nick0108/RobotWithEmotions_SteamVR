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
        if (currentChapter == Chapter.Chapter2)
        {
            if (door.isOpen || door2.isOpen)
            {
                start02 = true;
            }

            if (!hasPlay)
            {
                if (start02)
                {
                    UTCplayable02.Play();
                    hasPlay = true;
                }
            }
            if (UTCplayable02.time > 8.8)
            {
                UTC02.SetActive(false);
                currentChapter = Chapter.Chapter3;
            }
        }
    }
}
