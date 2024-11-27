using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public Transform parent;
    
    public float spawnRate = 3f;
    
    void Start()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(3);
        
        while (GameManager.Instance.gameActive)
        {
            GameObject.Instantiate(prefabs[Random.Range(0, prefabs.Length)], parent.position, Quaternion.identity, parent);
            
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
