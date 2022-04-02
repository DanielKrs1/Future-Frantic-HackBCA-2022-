using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {
    private static DontDestroyOnLoad i;

    private void Awake() {
        if (i != null)
            Destroy(gameObject);

        i = this;
        DontDestroyOnLoad(gameObject);
    }
}