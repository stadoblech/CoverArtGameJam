using UnityEngine;
using System.Collections;

public class EnemiesSpawnHandler : MonoBehaviour {

    public GameObject devil;
    public GameObject ghost;

    public float devilMinRespawn;
    public float devilMaxRespawn;

    public float ghostMinRespawn;
    public float ghostMaxRespawn;

    Transform[] points;
    Vector2 devilSpawnPoint;
    Vector2 ghostSpawnPoint;


	void OnEnable() {
        points = GetComponentsInChildren<Transform>();
        StartCoroutine(spawningDevil(getDevilRespawn()));
        StartCoroutine(spawningGhost(getGhostRespawn()));
    }

    #region devil spawn
    IEnumerator spawningDevil(float t)
    {
        yield return new WaitForSeconds(t);
        spawnDevil();
        StartCoroutine(spawningDevil(getDevilRespawn()));
        yield return null;
        
    }

    void spawnDevil()
    {
        devilSpawnPoint = new Vector2(
            Random.Range(points[1].transform.position.x, points[2].transform.position.x),
            points[1].transform.position.y
            );

        Instantiate(devil, devilSpawnPoint, Quaternion.identity);
    }

    float getDevilRespawn()
    {
        return Random.Range(devilMinRespawn, devilMinRespawn);
    }
    #endregion

    #region ghost spawn

    IEnumerator spawningGhost(float t)
    {
        yield return new WaitForSeconds(t);
        spawnGhost();
        StartCoroutine(spawningGhost(getGhostRespawn()));
        yield return null;

    }

    void spawnGhost()
    {
        int sp = Random.Range(3,5);

        ghostSpawnPoint = points[sp].transform.position;

        Instantiate(ghost, ghostSpawnPoint, Quaternion.identity);
    }

    

    float getGhostRespawn()
    {
        return Random.Range(ghostMinRespawn, ghostMaxRespawn);
    }
    #endregion
}
