using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControlPanelInput : AbstractUIInput
{
    public enum ID { AmountOfBuses, AmountOfCivilians }
    [Header("Required")]
    [SerializeField]
    private ID id;

    public override Enum GetID()
    {
        return id;
    }
}
