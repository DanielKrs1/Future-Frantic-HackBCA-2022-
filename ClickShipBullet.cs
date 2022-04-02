using UnityEngine;

public class ClickShipBullet : MonoBehaviour {
    public float speed;

    private Vector3 moveDirection;

    private void Start() {
        moveDirection = -transform.position.normalized;
        Destroy(gameObject, 10f);
    }

    private void Update() {
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.GetComponent<TimeMachine>()) {
            GameManager.GameOver();
            Destroy(gameObject);
        }
    }
}