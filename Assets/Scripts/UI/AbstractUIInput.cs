using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class AbstractUIInput : AbstractUIAsset
{
    [Header("Auto Assign")]
    [SerializeField]
    private TMP_InputField tmp_InputField;
    public TMP_InputField Tmp_InputField => tmp_InputField;

    private void OnValidate()
    {
        tmp_InputField = GetComponent<TMP_InputField>();
    }
}
