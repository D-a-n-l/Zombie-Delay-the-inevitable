using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] private Transform[] positionSpawn;

    private void Start()
    {
        StartCoroutine(nameof(Spawn));
    }

    private IEnumerator Spawn()
    {
        int posSpawn = Random.Range(0, positionSpawn.Length);

        GameObject enemy = Instantiate(enemyPrefab, positionSpawn[posSpawn].position, transform.rotation);

        yield return new WaitForSeconds(5f);

        //StartCoroutine(nameof(Spawn));
    }
}