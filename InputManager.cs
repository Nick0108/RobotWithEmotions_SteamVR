using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    
    //basic to identify the controller
    public SteamVR_TrackedObject TrackOBJ;
    public SteamVR_Controller.Device device;

    //determine which hand
    public bool isLefthand = false;

    public bool testing = false;
    
    // Use this for initialization
    void Start () {
        TrackOBJ = GetComponent<SteamVR_TrackedObject>();
   }
	
	// Update is called once per frame
	void Update () {

        device = SteamVR_Controller.Input((int)TrackOBJ.index);

    }
}
