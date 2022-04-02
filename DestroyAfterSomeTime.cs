using UnityEngine;

public class DestroyAfterSomeTime : MonoBehaviour {
    void Start() {
        Destroy(gameObject, 10f);
    }
}