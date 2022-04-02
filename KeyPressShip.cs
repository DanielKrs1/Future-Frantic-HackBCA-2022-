using UnityEngine;
using TMPro;

public class KeyPressShip : MonoBehaviour {
    public TextMeshProUGUI text;
    public GameObject explosionEffect;
    public float baseSpeed;
    public float speedVariation;

    private float speed;
    private Vector3 moveDirection;
    private KeyCode key;

    private void Start() {
        speed = Random.Range(baseSpeed - speedVariation, baseSpeed + speedVariation);
        transform.position = Random.insideUnitCircle.normalized * EnemySpawner.enemySpawnRadius_Static;
        moveDirection = -transform.position.normalized;
        Destroy(gameObject, 30f);
        key = (KeyCode)Random.Range(97, 123);
        text.text = "Press " + key.ToString();
    }

    private void Update() {
        if (Input.GetKeyDown(key)) {
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<TimeMachine>()) {
            Destroy(gameObject);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            GameManager.GameOver();
        }
    }
}