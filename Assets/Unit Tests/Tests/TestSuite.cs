using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class TestSuite
{
    private Game _game;
    
    [UnityTest]
    public IEnumerator AsteroidsMoveDown()
    {
        GameObject gameGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Game"));
        _game = gameGameObject.GetComponent<Game>();

        GameObject asteriod = _game.GetSpawner().SpawnAsteroid();

        float initialYPos = asteriod.transform.position.y;

        yield return new WaitForSeconds(0.1f);
        
        Assert.Less(asteriod.transform.position.y, initialYPos);
        
        Object.Destroy(_game.gameObject);
    }

}

