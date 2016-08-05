using UnityEngine;
using System.Collections;

public class EnemiesArealSpawn : MonoBehaviour {

    public GameObject devil;

    public float respawnCooldown = 0;

    Transform[] points;
    Vector2 spawnPos;



	void Start () {
        points = GetComponentsInChildren<Transform>();
        StartCoroutine(spawningEnemy(respawnCooldown));
    }
	
    IEnumerator spawningEnemy(float t)
    {
        yield return new WaitForSeconds(t);
        spawnDevil();
        StartCoroutine(spawningEnemy(respawnCooldown));
        yield return null;
        
    }

	void Update () {
	
	}

    void spawnDevil()
    {
        spawnPos = new Vector2(
            Random.Range(points[1].transform.position.x, points[2].transform.position.x),
            points[1].transform.position.y
            );

        Instantiate(devil, spawnPos, Quaternion.identity);
    }
}
