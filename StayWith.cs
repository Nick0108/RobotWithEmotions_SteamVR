using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StayWith : MonoBehaviour
{

    public float stayTime = 30.0f;
    public float currentStayTime = 0.0f;
    public float distance = 4.5f;
    public float lookAngle = 30;
    public Transform playerCamera;
    public GameManager gameManager;
    public Canvas hint;
    public Canvas hint2;

    private Vector3 hintPos = new Vector3(0, 0, 5f);


    private Vector3 distanceVector;

    private void Update()
    {
        distanceVector = transform.position - playerCamera.position;
        //Debug.Log(distanceVector.magnitude);
        if(distanceVector.magnitude <= 9)
        {
            if (distanceVector.magnitude <= distance)
            {
                hint.gameObject.SetActive(false);
                if (Vector3.Angle(distanceVector,playerCamera.forward) < lookAngle)
                {
                    hint2.gameObject.SetActive(false);
                    //Debug.Log("Look At Her");
                    currentStayTime += Time.deltaTime;
                    if (currentStayTime > stayTime / 2)
                    {
                        gameManager.NotCry = true;
                    }
                    if (currentStayTime > stayTime)
                    {
                        gameManager.Disappear = true;
                        hint.transform.SetParent(gameObject.transform);
                        hint2.transform.SetParent(gameObject.transform);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    hint2.gameObject.SetActive(true);
                    hint2.transform.SetParent(playerCamera);
                    hint2.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    hint2.transform.localPosition = hintPos;
                }
            }
            else
            {
                hint2.gameObject.SetActive(false);
                hint.gameObject.SetActive(true);
                hint.transform.SetParent(playerCamera);
                hint.transform.localRotation = Quaternion.Euler(0, 0, 0);
                hint.transform.localPosition = hintPos;
            }
        }
        
    }
}
