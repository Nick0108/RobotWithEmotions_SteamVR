using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public float AttackInterval = 1.0f;
    private float timer;

    private void Start()
    {
        timer = 0;
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (timer > AttackInterval)
            {
                collision.gameObject.GetComponent<EnemyHealth>().GetHurt();
                timer = 0;
            }
        }
    }
}
