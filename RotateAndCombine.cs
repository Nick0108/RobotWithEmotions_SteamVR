using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndCombine : MonoBehaviour {

    public Transform HappyBall;
    public Transform FearBall;
    public Transform AngryBall;
    public Transform SadBall;
    public bool Combine;

    public float RotateSpeed = 1.0f;
    public float CombineSpeed = 0.1f;

    // Update is called once per frame
    void Update () {
        if (Combine)
        {
            gameObject.transform.Rotate(Vector3.up * RotateSpeed);
            if (FearBall.localPosition.x >= 0)
            {
                HappyBall.localPosition += new Vector3(-Time.deltaTime * CombineSpeed, 0, Time.deltaTime * CombineSpeed);
                FearBall.localPosition += new Vector3(-Time.deltaTime * CombineSpeed, 0, -Time.deltaTime * CombineSpeed);
                AngryBall.localPosition += new Vector3(Time.deltaTime * CombineSpeed, 0, Time.deltaTime * CombineSpeed);
                SadBall.localPosition += new Vector3(Time.deltaTime * CombineSpeed, 0, -Time.deltaTime * CombineSpeed);
            }
        }
	}
}
