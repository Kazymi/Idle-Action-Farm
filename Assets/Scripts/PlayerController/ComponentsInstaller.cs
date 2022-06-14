using System;
using System.Collections.Generic;
using UnityEngine;

public class ComponentsInstaller : MonoBehaviour
{
    [SerializeField] private MonoPooled cutCornPrefab;
    [SerializeField] private List<PlayerInstrumentConfiguration> playerInstrumentConfigurations;
    [SerializeField] private List<VFXConfiguration> vfxConfigurations;

    private PlayerInstrumentActivator _playerInstrumentActivator;
    private CutCornSpawner _cutCornSpawner;
    private PlayerParameters _playerParameters;
    private VFXSpawner _vfxSpawner;
    private void Awake()
    {
       _playerInstrumentActivator = new PlayerInstrumentActivator(playerInstrumentConfigurations);
       _cutCornSpawner = new CutCornSpawner(cutCornPrefab, transform);
       _playerParameters = new PlayerParameters();
       _vfxSpawner = new VFXSpawner(vfxConfigurations, transform);
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<PlayerInstrumentActivator>(_playerInstrumentActivator);
        ServiceLocator.Subscribe<CutCornSpawner>(_cutCornSpawner);
        ServiceLocator.Subscribe<PlayerParameters>(_playerParameters);
        ServiceLocator.Subscribe<VFXSpawner>(_vfxSpawner);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<PlayerInstrumentActivator>();
        ServiceLocator.Unsubscribe<CutCornSpawner>();
        ServiceLocator.Unsubscribe<VFXSpawner>();
        ServiceLocator.Unsubscribe<PlayerParameters>();
    }
}