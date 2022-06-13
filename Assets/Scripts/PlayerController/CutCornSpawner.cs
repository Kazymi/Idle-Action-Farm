using UnityEngine;

public class CutCornSpawner
{
    private readonly IPool<MonoPooled> _poolCutCorns;
    private const int AmountCornsInPool = 4;

    public CutCornSpawner(MonoPooled prefab, Transform parent)
    {
        var factory = new FactoryMonoObject<MonoPooled>(prefab.gameObject, parent);
        _poolCutCorns = new Pool<MonoPooled>(factory, AmountCornsInPool);
        ServiceLocator.Subscribe<CutCornSpawner>(this);
    }

    ~CutCornSpawner()
    {
        ServiceLocator.Unsubscribe<CutCornSpawner>();
    }

    public void SpawnCutCorn(Vector3 position)
    {
        var newCorn = _poolCutCorns.Pull();
        newCorn.transform.position = position;
    }
}