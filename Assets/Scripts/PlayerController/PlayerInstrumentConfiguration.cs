using System;
using UnityEngine;

[Serializable]
public class PlayerInstrumentConfiguration
{
    [SerializeField] private InstrumentType instrumentType;
    [SerializeField] private Instrument instrument;

    public InstrumentType InstrumentType => instrumentType;

    public Instrument Instrument => instrument;
}