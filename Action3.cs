using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;


public class Action3 : MonoBehaviour
{
    public PlayableDirector UTCplayable;
    public GameObject UTC;
    public GameObject UTCObject;
    public Shader TransparentShader;

    public bool BeginToCry = false;
    public bool NotCry = false;
    public bool Disappear = false;

    public GameObject Elephant;

    private SkinnedMeshRenderer[] meshRenders;
    private void Start()
    {
        meshRenders = UTCObject.GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        
        if (BeginToCry)
        {
            UTCplayable.Play();
            if(transform.localPosition != Vector3.zero)
            {
                UTCObject.transform.localPosition = Vector3.zero;
                UTCObject.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        if (NotCry)
        {
            foreach(SkinnedMeshRenderer M in meshRenders)
            {
                M.material.shader=TransparentShader;
                NotCry = false;
            }
        }
        if (Disappear)
        {
            UTC.SetActive(false);
            Elephant.GetComponent<Rigidbody>().isKinematic = false;
            Disappear = false;
        }
    }
}
