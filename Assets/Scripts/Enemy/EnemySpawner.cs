using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform parent;

    public float spawnDelay = 3f;
    public float spawnRate = 8f;
    
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    /// <summary>
    /// After the spawn delay, start spawning random enemies at the specified spawn rate.
    /// </summary>
    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(spawnDelay);
        
        while (GameManager.Instance.gameActive)
        {
            GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Length)], parent.position, Quaternion.identity, parent);
            
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
