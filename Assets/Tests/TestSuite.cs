using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    private GameManager _gameManager;

    [SetUp]
    public void SetUp()
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/GameManager");

        GameObject managerObject = Object.Instantiate(prefab);
        
        _gameManager = managerObject.GetComponent<GameManager>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(_gameManager.gameObject);
    }
    
    [UnityTest]
    public IEnumerator SpawnCube()
    {
        GameObject spawnedCube = _gameManager.SpawnCube();        
        
        yield return null;
        
        // Unity's null is different to C#'s null, Assert.IsNull != UnityEngine.Assertions.Assert.IsNull
        UnityEngine.Assertions.Assert.IsNotNull(spawnedCube); 
        
        Object.Destroy(spawnedCube);
    }

    [UnityTest]
    public IEnumerator CubeMovingDown()
    {
        GameObject spawnedCube = _gameManager.SpawnCube();

        float initialYPos = spawnedCube.transform.position.y;
        
        yield return new WaitForSeconds(0.1f);

        Assert.Less(spawnedCube.transform.position.y, initialYPos);
        
        Object.Destroy(spawnedCube);
    }
}
