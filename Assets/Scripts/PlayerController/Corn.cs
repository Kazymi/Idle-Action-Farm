using System.Collections.Generic;
using UnityEngine;

public class Corn : MonoBehaviour
{
    [SerializeField] private CornConfiguration cornConfiguration;
    [SerializeField] private Transform centerOfCorn;
    [SerializeField] private List<Transform> partsOfCorn;

    private float _timeOfLastGrowth;
    private int _currentAmountParts;
    private CutCornSpawner _cornSpawner;
    public bool IsCornActive => _currentAmountParts > 0;

    private void Start()
    {
        _cornSpawner = ServiceLocator.GetService<CutCornSpawner>();
        _currentAmountParts = partsOfCorn.Count;
    }

    private void Update()
    {
        RecalculateCornSpawner();
    }

    private void RecalculateCornSpawner()
    {
        if (_currentAmountParts > 0)
        {
            return;
        }

        if (_timeOfLastGrowth < 0)
        {
            RespawnCorn();
            _timeOfLastGrowth = cornConfiguration.RespawnTime;
        }
        else
        {
            _timeOfLastGrowth -= Time.deltaTime;
        }
    }

    private void RespawnCorn()
    {
        foreach (var part in partsOfCorn)
        {
            part.gameObject.SetActive(true);
        }
        _currentAmountParts++;
    }

    public void CuteCorn()
    {
        if (IsCornActive == false)
        {
            return;
        }

        partsOfCorn[_currentAmountParts - 1].gameObject.SetActive(false);
        _cornSpawner.SpawnCutCorn(centerOfCorn.position);
        _timeOfLastGrowth = cornConfiguration.RespawnTime;
        _currentAmountParts--;
    }
}