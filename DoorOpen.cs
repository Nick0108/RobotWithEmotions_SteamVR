using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public bool isOpen =false;
    public bool isLeftDoor = false;
    private Vector3 OpenRotation = new Vector3(0, 90f, 0);
    //private Vector3 closeRightRotation = new Vector3(0, 180f, 0);
    public GameObject plane;
    public GameObject plane2;
    public bool hasEvent = false;
    public bool EventNowHappen = false;
    public bool isLock = false;
    public AudioSource OpendoorAudio;

    public bool testingOpen = false; 

    private void Start()
    {
        if (OpendoorAudio == null)
        {
            OpendoorAudio = GetComponent<AudioSource>();
        }
    }

    public void ControllDoor()
    {
        if (!isLock)
        {
            if (isOpen)
            {
                OpendoorAudio.Play();
                iTween.RotateTo(gameObject, iTween.Hash(
                "rotation", OpenRotation,
                "islocal", true,
                "time", 1.0f
                ));
                plane.SetActive(true);
                plane2.SetActive(true);
            }
            /*else
            {
                if (isLeftDoor)
                {
                    iTween.RotateTo(gameObject, iTween.Hash(
                    "rotation", Vector3.zero,
                    "islocal", true,
                    "time", 1.0f
                    ));
                }
                else
                {
                    iTween.RotateTo(gameObject, iTween.Hash(
                    "rotation", closeRightRotation,
                    "islocal", true,
                    "time", 1.0f
                    ));
                }
            }*/
            if (hasEvent)
            {
                EventNowHappen = true;
            }
        }
    }

    //testing
   /*
      private void Update()
    {
        if (testingOpen)
        {
            ControllDoor();
            testingOpen = false;
        }
    }
    */
}
