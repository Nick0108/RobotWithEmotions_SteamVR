using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructorUI : MonoBehaviour {

    public GameManager gameManager;
    public GameObject player;
    public GameObject[] CanvasOBJs;
    public Text CollectionsText;

    private bool GethappyBall_UI = false;
    private bool GetFearBall_UI = false;
    private bool GetAngryBall_UI = false;
    private bool Opendoor_UI = false;

    private int currnetCollectionsNum;

    // Use this for initialization
    void Start () {
		foreach(GameObject i in CanvasOBJs)
        {
            i.SetActive(false);
        }
        CanvasOBJs[0].SetActive(true);
        StartCoroutine(CanvasOBJdisappear(CanvasOBJs[0],20.0f));
        currnetCollectionsNum = GameManager.collectionNum;
    }
	
	// Update is called once per frame
	void Update () {
        if (!GethappyBall_UI)
        {
            if (gameManager.GetHappyBall)
            {
            
                CanvasOBJs[1].SetActive(true);
                CanvasOBJs[2].SetActive(true);
                StartCoroutine(CanvasOBJdisappear(CanvasOBJs[1]));
                StartCoroutine(CanvasOBJdisappear(CanvasOBJs[2]));
                GethappyBall_UI = true;
            }
        }

        if (!GetFearBall_UI)
        {
            if (gameManager.GetFearBall)
            {
                CanvasOBJs[3].SetActive(true);
                CanvasOBJs[4].SetActive(true);
                StartCoroutine(CanvasOBJdisappear(CanvasOBJs[3]));
                StartCoroutine(CanvasOBJdisappear(CanvasOBJs[4]));
                GetFearBall_UI = true;
            }
        }

        if (!GetAngryBall_UI)
        {
            if (gameManager.GetAngryBall)
            {
                CanvasOBJs[5].SetActive(true);
                StartCoroutine(CanvasOBJdisappear(CanvasOBJs[5]));
                GetAngryBall_UI = true;
            }
        }

        if (!Opendoor_UI)
        {
            if (Vector3.Distance(player.transform.position, CanvasOBJs[6].transform.position)<5.0f)
            {
                CanvasOBJs[6].SetActive(true);
                StartCoroutine(CanvasOBJdisappear(CanvasOBJs[6],15.0f));
                Opendoor_UI = true;
            }
        }
        if (GameManager.collectionNum != currnetCollectionsNum)
        {
            CanvasOBJs[7].SetActive(true);
            CollectionsText.text = GameManager.collectionNum + "/20";
            StartCoroutine(CanvasOBJdisappear(CanvasOBJs[7], 5.0f));
            currnetCollectionsNum = GameManager.collectionNum;
        }
    }

    IEnumerator CanvasOBJdisappear(GameObject OBJ,float second = 10.0f)
    {
        yield return new WaitForSeconds(second);
        OBJ.SetActive(false);
    }
}
