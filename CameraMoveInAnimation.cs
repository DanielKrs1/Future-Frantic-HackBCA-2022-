using UnityEngine;
using UnityEngine.Events;

public class CameraMoveInAnimation : MonoBehaviour {
    public Vector2 offset;
    public float speed;

    public UnityEvent OnFinished;

    private readonly Vector3 targetPosition = new Vector3(0, 0, -10);

    private void Start() {
        transform.position = offset;
    }

    private void Update() {
        Vector3 direction = targetPosition - transform.position;
        float moveAmount = speed * Time.deltaTime;

        if (moveAmount >= direction.magnitude) {
            transform.position = targetPosition;
            enabled = false;
            OnFinished.Invoke();
            return;
        }

        transform.position += direction.normalized * moveAmount;
    }
}