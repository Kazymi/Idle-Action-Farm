using System.Collections.Generic;
using UnityEngine;

public class PlayerInstrumentActivator
{
    private readonly Dictionary<InstrumentType, Instrument> _instruments = new Dictionary<InstrumentType, Instrument>();

    public PlayerInstrumentActivator(List<PlayerInstrumentConfiguration> playerInstrumentConfigurations)
    {
        foreach (var playerInstrument in playerInstrumentConfigurations)
        {
            _instruments.Add(playerInstrument.InstrumentType, playerInstrument.Instrument);
        }
    }

    public void SetInstrumentActivation(InstrumentType instrumentType, bool value)
    {
        _instruments[instrumentType].ActivateInstrument(value);
    }
}