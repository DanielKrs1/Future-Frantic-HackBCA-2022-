using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public static float enemySpawnRadius_Static;

    public Transform enemyMovePointsParent;
    public float enemySpawnRadius;
    public GameObject clickShip;
    public GameObject keyPressShip;

    private static Vector3[] enemyMovePoints;

    private void Start() {
        enemySpawnRadius_Static = enemySpawnRadius;
        enemyMovePoints = new Vector3[enemyMovePointsParent.childCount];
        for (int i = 0; i < enemyMovePointsParent.childCount; i++)
            enemyMovePoints[i] = enemyMovePointsParent.GetChild(i).position;

        StartCoroutine(Spawn());
    }

    public static Vector3 GetRandomPosition() {
        return enemyMovePoints[Random.Range(0, enemyMovePoints.Length)];
    }

    private IEnumerator Spawn() {
        float spawnInterval = 2f;

        while (true) {
            if (Random.Range(0, 2) == 1)
                Instantiate(clickShip);
            else
                Instantiate(keyPressShip);

            yield return new WaitForSeconds(spawnInterval);
            spawnInterval *= 0.99f;
        }

    }

    public void Enable() {
        enabled = true;
    }

    private void OnDisable() {
        StopAllCoroutines();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(Vector3.zero, enemySpawnRadius);
    }
}