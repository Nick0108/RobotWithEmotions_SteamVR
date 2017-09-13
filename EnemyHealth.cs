using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public float Health = 10.0f;
    public Slider HP;
    public bool Alive = true;
    //public GameManager gameManager;

    public float currentHP;

    private void Start()
    {
        HP.maxValue = Health;
        HP.minValue = 0;
        currentHP = HP.value = 10.0f;
    }

    public void GetHurt()
    {
        if (Alive)
        {
            currentHP--;
            if (currentHP <= 0)
            {
                currentHP = 0;
                Alive = false;
                HP.gameObject.SetActive(false);
                GameManager.KillEnemyNum++;
                Debug.Log(GameManager.KillEnemyNum);
            }
            HP.value = currentHP;
        }
    }
}
