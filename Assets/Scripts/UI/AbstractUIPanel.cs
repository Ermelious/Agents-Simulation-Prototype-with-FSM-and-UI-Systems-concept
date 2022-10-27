using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public abstract class AbstractUIPanel : AbstractUIAsset
{
    [Header("Required")]
    [SerializeField]
    private Enum Id;
    [Header("Auto Assign")]
    [SerializeField]
    private List<AbstractUIInput> inputs;
    private Dictionary<Enum, AbstractUIInput> inputsDictionary = new Dictionary<Enum, AbstractUIInput>();

    public Dictionary<Enum, AbstractUIInput> InputsDictionary
    {
        get 
        { 
            if (inputsDictionary.Count == 0)
                InitializeDictionary();
            return inputsDictionary;
        }
    }

    private void OnValidate()
    {
        inputs = GetComponentsInChildren<AbstractUIInput>().ToList();
    }

    private void InitializeDictionary()
    {
        foreach (AbstractUIInput input in inputs)
            inputsDictionary.Add(input.GetID(), input);
    }
}
