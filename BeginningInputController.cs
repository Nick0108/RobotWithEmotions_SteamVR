using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningInputController : MonoBehaviour {

    //SteamVR_TrackedObject TrackOBJ;
    //SteamVR_Controller.Device device;
    
    public LineRenderer Line;
    public LayerMask layer;

	// Use this for initialization
	void Start () {
        //TrackOBJ = GetComponent<SteamVR_TrackedObject>();
        if(Line==null)
            Line = GetComponent<LineRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        //device = SteamVR_Controller.Input((int)TrackOBJ.index);

        //if (device.GetTouch(SteamVR_Controller.ButtonMask.Touchpad))
        //{
            Line.gameObject.SetActive(true);
            Line.positionCount = 2;
            Line.SetPosition(0, transform.position);
            Line.SetPosition(1, transform.position + transform.up * 10);
            RaycastHit hitInfo;
            if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 10, layer))
            {
                hitInfo.transform.gameObject.GetComponent<Beginning>().OnPointButton();
            }
        //}
	}
}
