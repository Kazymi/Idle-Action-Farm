using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Harvester : MonoBehaviour
{
    [SerializeField] private Transform harvesterPosition;
    [SerializeField] private HarvestConfiguration harvestConfiguration;
    [SerializeField] private LayerMask cornMask;

    private float _cooldown;
    public Corn CurrentCorn { get; private set; }

    private void Update()
    {
        RecalculateCoolDown();
    }

    private void RecalculateCoolDown()
    {
        if (_cooldown < 0)
        {
            _cooldown = harvestConfiguration.LookingTime;
            LookingCorn();
        }
        else
        {
            _cooldown -= Time.deltaTime;
        }
    }
    private void LookingCorn()
    {
        var foundCorns = Physics.OverlapSphere(harvesterPosition.position, harvestConfiguration.Radius, cornMask).Where(
            t =>
            {
                var corn = t.GetComponent<Corn>();
                if (corn == false || corn.IsCornActive == false) return false;
                return corn;
            });
        CurrentCorn = GetNearestCorn(foundCorns);
    }

    private Corn GetNearestCorn(IEnumerable<Collider> colliders)
    {
        var enumerable = colliders as Collider[] ?? colliders.ToArray();
        if (enumerable.Any() == false)
        {
            return null;
        }

        var nearest = enumerable.OrderBy(x => Vector3.Distance(transform.position, x.transform.position))
            .FirstOrDefault();
        return nearest.GetComponent<Corn>();
    }

    public void CuteCorn()
    {
        if (CurrentCorn == null)
        {
            return;
        }
        CurrentCorn.CuteCorn();
    }
}