using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractUIAsset : MonoBehaviour
{
    public abstract Enum GetID();

    public static Dictionary<Enum, T> GetAllUIAssetsInChildren<T> (Transform parent, ref Dictionary<Enum, T> dictionary) where T : AbstractUIAsset
    {
        foreach (T panel in parent.GetComponentsInChildren<T>())
            dictionary.Add(panel.GetID(), panel);
        return dictionary;
    }
}