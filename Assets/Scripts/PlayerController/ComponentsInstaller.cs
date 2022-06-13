using System.Collections.Generic;
using UnityEngine;

public class ComponentsInstaller : MonoBehaviour
{
    [SerializeField] private MonoPooled cutCornPrefab;
    [SerializeField] private List<PlayerInstrumentConfiguration> playerInstrumentConfigurations;
    private void Awake()
    {
        var playerInstrumentSpawner = new PlayerInstrumentActivator(playerInstrumentConfigurations);
        var cutCornSpawner = new CutCornSpawner(cutCornPrefab, transform);
    }
}