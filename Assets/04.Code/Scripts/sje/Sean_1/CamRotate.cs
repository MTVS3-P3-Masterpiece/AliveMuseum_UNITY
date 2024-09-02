using UnityEngine;

public class CamRotate : MonoBehaviour
{
    
    public float rotSpeed = 200f;
    private float mx = 0;
    private float my = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        float mouse_X = Input.GetAxis("Mouse X");
        float mouse_Y = Input.GetAxis("Mouse Y");
        
        mx += mouse_X * rotSpeed * Time.deltaTime * 2  ; 
        my += mouse_Y * rotSpeed * Time.deltaTime * 2  ;
        
        my = Mathf.Clamp(my, -90f, 90f);
        transform.eulerAngles = new Vector3(-my, mx, 0);
    }
}