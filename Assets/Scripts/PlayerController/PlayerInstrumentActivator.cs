using System.Collections.Generic;
using UnityEngine;

public class PlayerInstrumentActivator
{
    private readonly Dictionary<InstrumentType, GameObject> _instruments = new Dictionary<InstrumentType, GameObject>();

    public PlayerInstrumentActivator(List<PlayerInstrumentConfiguration> playerInstrumentConfigurations)
    {
        ServiceLocator.Subscribe<PlayerInstrumentActivator>(this);
        foreach (var playerInstrument in playerInstrumentConfigurations)
        {
            _instruments.Add(playerInstrument.InstrumentType, playerInstrument.Instrument);
        }
    }

    ~PlayerInstrumentActivator()
    {
        ServiceLocator.Unsubscribe<PlayerInstrumentActivator>();
    }

    public void SetInstrumentActivation(InstrumentType instrumentType, bool value)
    {
        _instruments[instrumentType].SetActive(value);
    }
}