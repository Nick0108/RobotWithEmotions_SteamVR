using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionSys : MonoBehaviour {

    public List<GameObject> EmotionalBalls;
    /*
        the EmotionalBall should be place by order like this:
        0-Empty
        1-HappyBall,
        2-FearBall,
        3-AngryBall,
        4-SadBall
    */
    public int currentIndex;
    public int currentmaxIndex;
    public bool IndexIsLock = false;

    private void Start()
    {
        currentIndex = 0;
        currentmaxIndex = 0;
        InitEmotionBalls();
    }
    // Update is called once per frame
    public void SwipeRight()
    {
        if (!IndexIsLock)
        {
            currentIndex++;
            if (currentIndex > currentmaxIndex)
            {
                currentIndex = 0;
            }
            InitEmotionBalls();
            EmotionalBalls[currentIndex].SetActive(true);
        }
    }
    public void SwipeLeft()
    {
        if (!IndexIsLock)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = currentmaxIndex;
            }
            InitEmotionBalls();
            EmotionalBalls[currentIndex].SetActive(true);
        }
    }

    public void InitBalls()
    {
        if (!IndexIsLock)
        {
            InitEmotionBalls();
            currentIndex = 0;
            EmotionalBalls[currentIndex].SetActive(true);
        }
    }

    void InitEmotionBalls()
    {
        foreach (GameObject i in EmotionalBalls)
        {
            i.SetActive(false);
        }
    }
}
