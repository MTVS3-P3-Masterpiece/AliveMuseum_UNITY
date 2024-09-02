using UnityEngine;

public class PlayerKeyInput : MonoBehaviour
{
    public CheckInteraction _checkInteraction;
    void Start()
    {
        //_checkInteraction.GetComponent<CheckInteraction>();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            _checkInteraction.OnInteraction();
        }
    }
}
