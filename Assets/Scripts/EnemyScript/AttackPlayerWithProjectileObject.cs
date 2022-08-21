using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerWithProjectileObject : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject projectileObj;
    public void ShootProjectileObject()
    {
        GameObject poision = Instantiate(projectileObj, firePoint.position, transform.rotation);
    }
}
