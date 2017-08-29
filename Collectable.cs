using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour {

    public Canvas ReadableContent;
    public Canvas HearableContent;
    //judge the OBJ's attribute
    public bool isNecessary = false;
    public bool hasReadCanvas = false;
    public bool hasVoice = false;
    public bool hasEvent = false;
    public bool CanHold = false;

    public bool isCollected = false;
    //public bool isRead = false;
    public bool isHeard = false;
    public bool EventNowHappen = false;

    private AudioSource AudioSou;

    private void Start()
    {
        if (hasVoice)
        {
            AudioSou = GetComponent<AudioSource>();
        }
        if (hasReadCanvas && ReadableContent == null) 
        {
            ReadableContent = GetComponentInChildren<Canvas>();
            ReadableContent.gameObject.SetActive(false);
        }
    }

    public void Read()
    {
        if (!isCollected)
        {
            if(isNecessary)
                GameManager.collectionNum++;
            isCollected = true;
            Debug.Log("collectionNum:"+ GameManager.collectionNum);
        }
        if (hasReadCanvas)
        {
            ReadableContent.gameObject.SetActive(true);
        }
        if (hasVoice)
        {
            if (!isHeard)
            {
                AudioSou.Play();
                isHeard = true;
                HearableContent.gameObject.SetActive(true);
                StartCoroutine(AudioContent());
            }
        }
    }

    public void Release()
    {
        if (hasEvent)
        {
            EventNowHappen = true;
        }
        if (hasReadCanvas)
        {
            ReadableContent.gameObject.SetActive(false);
        }
    }

    IEnumerator AudioContent()
    {
        yield return new WaitForSeconds(5);
        HearableContent.gameObject.SetActive(false);
    }
}
