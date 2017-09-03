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
        if (currentChapter == Chapter.Chapter3)
        {
            
            if (!isChangeWeather)
            {
                if (player.transform.position.x > 3f && player.transform.position.z < -15f)
                {
                    changeSkybox.currentSkyBox = ChangeSkybox.skybox.Falling;
                    changeSkybox.CheckCurrentSky();
                    isChangeWeather = true;
                }
            }
            
            if (NotCry)
            {
                if (!isNotCry)
                {
                    foreach (SkinnedMeshRenderer M in meshRenders)
                    {
                        M.material.shader = TransparentShader;
                    }
                    chapter3AudioSource.clip = chapter3AudioClips[2];
                    chapter3AudioSource.loop = true;
                    chapter3AudioSource.Play();
                    isNotCry = true;
                }
            }
            if (Disappear)
            {
                UTC03.SetActive(false);
                UTCplayable03.Stop();
                Elephant.GetComponent<Rigidbody>().isKinematic = false;
                fearBall.SetActive(true);
                Disappear = false;
                chapter3AudioSource.loop = false;
                chapter3AudioSource.Stop();
            }
            if (GetFearBall)
            {
                TimeLine4.SetActive(true);
                currentChapter = Chapter.Chapter4;
            }
        }
    }
}
