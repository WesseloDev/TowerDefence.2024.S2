using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _cube;

    void Start()
    {
        SpawnCube(_cube);
    }

    public GameObject SpawnCube()
    {
        return SpawnCube(_cube);
    }
    
    public GameObject SpawnCube(GameObject cube)
    {
        GameObject spawnedCube = Instantiate(cube, transform.position, transform.rotation);

        return spawnedCube;
    }

    private void LogError(string error)
    {
        Debug.Log("GAME ERROR: " + error);
    }
}
