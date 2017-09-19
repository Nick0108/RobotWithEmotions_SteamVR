using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionVisible : MonoBehaviour {

    public MeshRenderer[] CollectionRenderers;

    public void NightChangeCollectionMaterial()
    {
        foreach(MeshRenderer i in CollectionRenderers)
        {
            foreach(Material j in i.materials)
            {
                j.SetFloat("_RimBool", 1f);
            }
        }
    }

    public void DayChangeCollectionMaterial()
    {
        foreach (MeshRenderer i in CollectionRenderers)
        {
            foreach (Material j in i.materials)
            {
                j.SetFloat("_RimBool", 0);
            }
        }
    }
}
