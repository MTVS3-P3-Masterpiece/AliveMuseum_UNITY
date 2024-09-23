using UnityEngine;

public class NetworkManagerSingleton : MonoBehaviour
{
    
    public static NetworkManagerSingleton instance = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}

