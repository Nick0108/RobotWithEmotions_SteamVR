using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    
    public EmotionSys EmotionalBall;
    public ChangeSkybox mySkybox;
    public GameObject spotLight;

    public GameObject Sword;

    //basic to identify the controller
    public SteamVR_TrackedObject TrackOBJ;
    public SteamVR_Controller.Device device;

    //for garbing and throwing
    public GameObject MoveableOBJRelease;
    public float throwForce = 1.5f;
    public GameObject HandCol;
    public GameObject HandModel;

    //determine which hand
    public bool isLefthand = false;

    //for Touchpad to change the balls
    private float Touchcurrent_x;
    private float TouchLast_x;
    private float SwipeSum_x;
    private float distance_x;
    private bool hasSwipeLeft_x;
    private bool hasSwipeRight_x;

    //Teleporting(happy ball)
    public GameObject TeleporterTargetObject;
    public GameObject Player;
    public LayerMask TeleporterLayer;
    public LineRenderer TeleportLine;
    private Vector3 TeleporterLocation;
    public bool isCanTeleport = false;
    public bool TeleportOBJ = false;
    public BeziercurveLine CurveLine;

    public bool testing = false;
    
    // Use this for initialization
    void Start () {
        TrackOBJ = GetComponent<SteamVR_TrackedObject>();
        TeleportLine.gameObject.SetActive(false);
        TeleporterTargetObject.SetActive(false);
        TouchLast_x = 0;

        mySkybox.currentSkyBox = ChangeSkybox.skybox.Day;
        mySkybox.CheckCurrentSky();
    }
	
	// Update is called once per frame
	void Update () {
        if (testing)
        {

            testing = false;
        }

        device = SteamVR_Controller.Input((int)TrackOBJ.index);
        //for only right hand
        if (!isLefthand)
        {
            if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                //Record the Axis of x on firstTouch
                TouchLast_x = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
            }
                //Swipe the touchpad to change the emotionalball
                if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Touchcurrent_x = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad).x;
                distance_x = Touchcurrent_x - TouchLast_x;
                TouchLast_x = Touchcurrent_x;
                SwipeSum_x += distance_x;

                if (!hasSwipeRight_x)
                {
                    if (SwipeSum_x > 0.5f)
                    {
                        SwipeSum_x = 0;
                        SwipeRight();
                        hasSwipeRight_x = true;
                        hasSwipeLeft_x = false;
                    }
                }
                if (!hasSwipeLeft_x)
                {
                    if (SwipeSum_x < -0.5f)
                    {
                        SwipeSum_x = 0;
                        SwipeLeft();
                        hasSwipeRight_x = false;
                        hasSwipeLeft_x = true;
                    }
                }
            }
            //when finger leave the touchpad, the calculate will init
            if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad))
            {
                Touchcurrent_x = 0;
                TouchLast_x = 0;
                distance_x = 0;
                SwipeSum_x = 0;
                hasSwipeLeft_x = false;
                hasSwipeRight_x = false;
            }
            //Pressdown the touchpad, can init the Emotionalball to Empty
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
            {
                InitEmotionalBalls();
            }
            //when using the happy ball
            if(EmotionalBall.currentIndex == 1)
            {
                if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
                {
                    isCanTeleport = false;
                    TeleportOBJ = false;
                    TeleportLine.gameObject.SetActive(true);
                    RaycastHit hitInfo;
                    if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 5.0f, TeleporterLayer))
                    {
                        TeleporterLocation = hitInfo.point;
                        TeleportLine.positionCount = 2;
                        TeleportLine.SetPosition(0, transform.position);
                        TeleportLine.SetPosition(1, TeleporterLocation);
                        //Debug.Log(hitInfo.collider.gameObject.tag + "===" +(hitInfo.collider.CompareTag("TeleportArea")));
                        if (hitInfo.collider.CompareTag("TeleportArea"))
                            isCanTeleport = true;
                        TeleportOBJ = true;
                    }
                    else
                    {
                        Vector3 TempDirectionPoint = transform.position + transform.forward * 5;
                        RaycastHit groundRayhit;
                        if (Physics.Raycast(TempDirectionPoint, -Vector3.up, out groundRayhit, 7.0f, TeleporterLayer))
                        {
                            //TeleporterLocation = new Vector3(transform.position.x + transform.forward.x * 15, groundRayhit.transform.position.y, transform.position.z + transform.forward.z * 15);
                            TeleporterLocation = groundRayhit.point;
                            CurveLine.DrawLine(TeleportLine, transform.position, TempDirectionPoint, TeleporterLocation, 20);
                            //Debug.Log(groundRayhit.collider.gameObject.tag + "===" + (groundRayhit.collider.CompareTag("TeleportArea")));
                            if (groundRayhit.collider.CompareTag("TeleportArea"))
                                isCanTeleport = true;
                            TeleportOBJ = true;
                        }
                        else
                        {
                            TeleportLine.positionCount = 2;
                            TeleportLine.SetPosition(0, transform.position);
                            TeleportLine.SetPosition(1, TempDirectionPoint);
                            TeleportOBJ = false;
                            isCanTeleport = false;
                        }
                    }
                    if (TeleportOBJ)
                    {
                        TeleporterTargetObject.transform.position = TeleporterLocation + (Vector3.up * 0.001f);
                        TeleporterTargetObject.SetActive(true);
                    }
                }
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    if (isCanTeleport)
                        Player.transform.position = TeleporterLocation;
                    TeleportLine.gameObject.SetActive(false);
                    TeleporterTargetObject.SetActive(false);
                }
            }
            //when using the fear ball
            if (EmotionalBall.currentIndex == 2)
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    ChangeAndCheckSkybox();
                }
            }
            //when using the angry ball
            if (EmotionalBall.currentIndex == 3)
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    Sword.SetActive(true);
                }
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    Sword.SetActive(false);
                }
            }
            //when using the sad ball
            if (EmotionalBall.currentIndex == 4)
            {
                if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
                {
                    spotLight.SetActive(true);
                }
                if (device.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))
                {
                    spotLight.SetActive(false);
                }
            }
        }
        else
        {
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                HandCol.SetActive(true);
                HandModel.SetActive(false);
            }
            if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
            {
                HandCol.SetActive(false);
                HandModel.SetActive(true);
            }
        }
    }

    void SwipeLeft()
    {
        EmotionalBall.SwipeLeft();
    }
    void SwipeRight()
    {
        EmotionalBall.SwipeRight();
    }
    void InitEmotionalBalls()
    {
        EmotionalBall.InitBalls();
    }


    void ChangeAndCheckSkybox()
    {
        mySkybox.currentSkyBox++;
        if (mySkybox.currentSkyBox > ChangeSkybox.skybox.Night)
            mySkybox.currentSkyBox = ChangeSkybox.skybox.Day;
        //Debug.Log(mySkybox.currentSkyBox);
        mySkybox.CheckCurrentSky();
    }

    private void OnTriggerStay(Collider other)
    {
        //Grabing and Throwing
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            GrabbingObj(other);
        }
        if (device.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            ThrowingObj(other);
        }
    }

    void GrabbingObj(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("EmotionalBall"))
            {
                other.GetComponent<EmotionalBallOBJ>().PickupBall();
                device.TriggerHapticPulse(2000);
            }
            if (other.CompareTag("Collectable"))
            {
                other.gameObject.GetComponent<Collectable>().Read();
                if (other.gameObject.GetComponent<Collectable>().CanHold)
                {
                    other.transform.SetParent(gameObject.transform);
                    other.GetComponent<Rigidbody>().isKinematic = true;
                }
                device.TriggerHapticPulse(2000);
            }
            if (other.CompareTag("Door"))
            {
                other.gameObject.GetComponent<DoorOpen>().isOpen = true;
                other.gameObject.GetComponent<DoorOpen>().ControllDoor();
                device.TriggerHapticPulse(2000);
            }
        }
    }

    void ThrowingObj(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            other.GetComponent<Collectable>().Release();
            if (other.GetComponent<Collectable>().CanHold)
            {
                other.transform.SetParent(MoveableOBJRelease.transform);
                Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();
                otherRigidbody.isKinematic = false;
                otherRigidbody.velocity = device.velocity * throwForce;
                otherRigidbody.angularVelocity = device.angularVelocity;
            }
        }
    }
}
