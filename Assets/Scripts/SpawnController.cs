using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    #region Variables
    public GameObject enemyPrefab, player;
    public float minDelay, maxDelay, offset;
    private Vector3 spawnPos;
    #endregion

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

        spawnPos = new Vector3(player.transform.position.x + Random.Range(-offset, offset), player.transform.position.y, player.transform.position.z);

        GameObject g = Instantiate(enemyPrefab);
        g.transform.position = spawnPos;

        StartCoroutine(SpawnEnemies());
    }
}
