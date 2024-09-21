using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    
    public float rotSpeed = 200f;
    private float mx = 0;
    void Start()
    {
        
    }
  
    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X");
        mx += mouse_X * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, mx, 0);

    }
}