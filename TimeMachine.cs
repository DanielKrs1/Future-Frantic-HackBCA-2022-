using UnityEngine;

public class TimeMachine : MonoBehaviour {
    public GameObject explosionEffect;

    public static void Destroy() {
        TimeMachine t = FindObjectOfType<TimeMachine>();
        if (t != null)
            Destroy(t.gameObject);

        Instantiate(t.explosionEffect);
    }
}