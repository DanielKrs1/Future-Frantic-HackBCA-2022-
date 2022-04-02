using UnityEngine;

public class ClickShip : MonoBehaviour {
    public float speed;
    public float timeBeforeAttack;
    public float timeVariation;
    public Transform firePoint;
    public GameObject bullet;
    public GameObject explosionEffect;

    private float attackTimer;

    private Vector2 startPosition;
    private Vector2 targetPosition;
    private bool hasAttacked;

    private void Start() {
        targetPosition = EnemySpawner.GetRandomPosition();
        startPosition = targetPosition.normalized * EnemySpawner.enemySpawnRadius_Static;
        transform.position = startPosition;
        attackTimer = Random.Range(timeBeforeAttack - timeVariation, timeBeforeAttack + timeVariation);
    }

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);

        if (hasAttacked)
            return;

        attackTimer -= Time.deltaTime;

        if (attackTimer <= 0) {
            hasAttacked = true;
            Instantiate(bullet, firePoint.position, Quaternion.identity);
            targetPosition = startPosition;
            Destroy(gameObject, 10f);
        }
    }

    private void OnMouseDown() {
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}