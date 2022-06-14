using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class VFXSpawner
{
    private readonly Dictionary<VFXType, IPool<TemporaryMonoPooled>> _pools =
        new Dictionary<VFXType, IPool<TemporaryMonoPooled>>();

    private const int AmountElementsInPool = 2;
    public VFXSpawner(List<VFXConfiguration> vfxConfigurations,Transform parent)
    {
        foreach (var vfxConfiguration in vfxConfigurations)
        {
            var factory = new FactoryMonoObject<TemporaryMonoPooled>(vfxConfiguration.Prefab.gameObject,parent);
            _pools.Add(vfxConfiguration.VFXType,new Pool<TemporaryMonoPooled>(factory,AmountElementsInPool));
        }
    }

    public void SpawnVFX(Vector3 position,VFXType vfxType)
    {
        var effect = _pools[vfxType].Pull();
        effect.transform.position = position;
    }
    
}