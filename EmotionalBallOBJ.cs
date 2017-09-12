using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmotionalBallOBJ : MonoBehaviour {

    public enum EmotionBall
    {
        HappyBall,
        FearBall,
        AngryBall,
        SadBall,
        Empty
    }
    public GameManager gameManager;
    public EmotionSys E_sys;
    public int ToMaxIndex;
    public EmotionBall thisBall;

    public void PickupBall()
    {
        switch (thisBall)
        {
            case EmotionBall.HappyBall:
                PickupHappyBall();
                break;
            case EmotionBall.FearBall:
                PickupFearBall();
                break;
            case EmotionBall.AngryBall:
                PickupAngryBall();
                break;
            case EmotionBall.SadBall:
                PickupSadBall();
                break;
            case EmotionBall.Empty:
                PickupEmpty();
                break;
        }
        E_sys.currentmaxIndex = ToMaxIndex;
        E_sys.InitBalls();
        for(int i = 0; i < ToMaxIndex; i++)
        {
            E_sys.SwipeRight();
        }
        gameObject.SetActive(false);
    }

    public void PickupHappyBall()
    {
        gameManager.GetHappyBall = true;
    }

    public void PickupFearBall()
    {
        gameManager.GetFearBall = true;
    }
    public void PickupAngryBall()
    {
        gameManager.GetAngryBall = true;
    }
    public void PickupSadBall()
    {
        gameManager.GetSadBall = true;
    }
    public void PickupEmpty()
    {
        gameManager.GetLastBall = true;
    }
}
