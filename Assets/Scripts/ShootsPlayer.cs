using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootsPlayer : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    [SerializeField] private Transform positionShoots;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, positionShoots.position, transform.rotation);
    }
}