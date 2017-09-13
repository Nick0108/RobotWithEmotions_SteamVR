using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public float Health = 10.0f;
    public Slider HP;
    public bool Alive = true;
    public GameManager gameManager;

    public float currentHP;

    private void Start()
    {
        HP.maxValue = Health;
        HP.minValue = 0;
        currentHP = HP.value = Health;
    }

    public void GetHurt()
    {
        if (gameManager.GetAngryBall)
        {
            if (Alive)
            {
                //HP.gameObject.SetActive(true);
                currentHP--;
                if (currentHP <= 0)
                {
                    currentHP = 0;
                    Alive = false;
                    HP.gameObject.SetActive(false);
                }
                HP.value = currentHP;
            }
        }
        else
        {
            HP.gameObject.SetActive(false);
        }
    }
}
