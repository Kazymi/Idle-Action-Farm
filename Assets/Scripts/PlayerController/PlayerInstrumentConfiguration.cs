using System;
using UnityEngine;

[Serializable]
public class PlayerInstrumentConfiguration
{
    [SerializeField] private InstrumentType instrumentType;
    [SerializeField] private GameObject instrument;

    public InstrumentType InstrumentType => instrumentType;

    public GameObject Instrument => instrument;
}