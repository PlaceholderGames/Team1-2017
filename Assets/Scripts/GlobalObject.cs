using UnityEngine;

public class GlobalObject : MonoBehaviour
{
    public Vector3 Position;
    public int Asteroids = 500;
    public static GlobalObject Instance;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}