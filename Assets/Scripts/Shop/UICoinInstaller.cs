using UnityEngine;

public class UICoinInstaller : MonoBehaviour
{
    [SerializeField] private UICoin prefab;
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;

    private UICoinSpawner _uiCoinSpawner;

    private void Awake()
    {
        _uiCoinSpawner = new UICoinSpawner(prefab, transform, startPosition.position, endPosition.position);
    }

    private void OnEnable()
    {
        ServiceLocator.Subscribe<UICoinSpawner>(_uiCoinSpawner);
    }

    private void OnDisable()
    {
        ServiceLocator.Unsubscribe<UICoinSpawner>();
    }
}