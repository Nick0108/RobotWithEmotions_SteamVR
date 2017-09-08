using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkybox : MonoBehaviour {

    public enum skybox
    {
        Day = 0,
        Falling = 1,
        Night = 2
    }
    public skybox currentSkyBox;

    public Material[] skyMats;
    public Light[] dirLights;
    public CollectionVisible collectionVisible;

    private Color NightSkyColor = new Color(0.21323f, 0.2626775f, 0.5f);
    private Color NightEquaorColor = new Color(0.2083694f, 0.2205688f, 0.3014706f);
    private Color NightGroundColor = new Color(0.2737349f, 0.3038719f, 0.4485294f);

    private Color FallingSkyColor = new Color(0.5735294f, 0.5735294f, 0.5735294f);
    private Color FallingEquaorColor = new Color(0.2647059f, 0.2356849f, 0.1732264f);
    private Color FallingGroundColor = new Color(0.5294118f, 0.437597f, 0.3542388f);


    // Use this for initialization
    void Start () {
        currentSkyBox = skybox.Day;
    }
	
	// Update is called once per frame
	public void CheckCurrentSky () {
        switch (currentSkyBox)
        {
            case skybox.Day : ChangeToDay();
                break;
            case skybox.Falling: ChangeToFalling();
                break;
            case skybox.Night:ChangeToNight();
                break;
            default:ChangeToDay();
                break;
        }
    }

    void ChangeToDay()
    {
        RenderSettings.skybox = skyMats[0];
        dirLights[0].gameObject.SetActive(true);
        dirLights[1].gameObject.SetActive(false);
        dirLights[2].gameObject.SetActive(false);
        RenderSettings.sun = dirLights[0];

        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Skybox;
        collectionVisible.DayChangeCollectionMaterial();
    }
    void ChangeToFalling()
    {
        RenderSettings.skybox = skyMats[1];
        dirLights[0].gameObject.SetActive(false);
        dirLights[1].gameObject.SetActive(true);
        dirLights[2].gameObject.SetActive(false);
        RenderSettings.sun = dirLights[1];

        RenderSettings.ambientSkyColor = FallingSkyColor;
        RenderSettings.ambientEquatorColor = FallingEquaorColor;
        RenderSettings.ambientGroundColor = FallingGroundColor;
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
    }
    void ChangeToNight()
    {
        RenderSettings.skybox = skyMats[2];
        dirLights[0].gameObject.SetActive(false);
        dirLights[1].gameObject.SetActive(false);
        dirLights[2].gameObject.SetActive(true);
        RenderSettings.sun = dirLights[2];

        RenderSettings.ambientSkyColor = NightSkyColor;
        RenderSettings.ambientEquatorColor = NightEquaorColor;
        RenderSettings.ambientGroundColor = NightGroundColor;
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
        collectionVisible.NightChangeCollectionMaterial();
    }
}
