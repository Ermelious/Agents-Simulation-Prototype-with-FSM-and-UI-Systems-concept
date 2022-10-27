using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GlobalUIEnum;

public class UIControlPanel : AbstractUIPanel
{
    public override Enum GetID()
    {
        return PanelID.ControlPanel;
    }
}
