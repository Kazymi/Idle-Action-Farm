using UnityEngine;

public class UICoinSpawner
{
    private readonly Vector3 _startPosition;
    private readonly Vector3 _endPosition;
    private IPool<UICoin> _coinPool;

    private const int AmountCoinInPool = 4;

    public UICoinSpawner(UICoin prefab, Transform parent, Vector3 startPosition, Vector3 endPosition)
    {
        _startPosition = startPosition;
        _endPosition = endPosition;
        var factory = new FactoryMonoObject<UICoin>(prefab.gameObject, parent);
        _coinPool = new Pool<UICoin>(factory, AmountCoinInPool);
    }

    public void SpawnCoin()
    {
        var coin = _coinPool.Pull();
        coin.Initialize(_startPosition, _endPosition);
    }
}