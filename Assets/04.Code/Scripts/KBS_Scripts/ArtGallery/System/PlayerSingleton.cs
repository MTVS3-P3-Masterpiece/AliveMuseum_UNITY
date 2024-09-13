using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public static PlayerSingleton instance = null;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
