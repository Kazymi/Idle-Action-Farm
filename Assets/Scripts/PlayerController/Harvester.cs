using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    public bool HarvesterInField { get; private set; }

    public void SetHarvesterInField(bool inField)
    {
        HarvesterInField = inField;
    }
}