using UnityEngine;

public class UserMove : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed = 7f;
    public Camera camera;
    
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");  
        float v = Input.GetAxis("Vertical");


        Vector3 dir = new Vector3(h, 0, v).normalized;

        Quaternion cameraRotationY = Quaternion.Euler(0, camera.transform.rotation.eulerAngles.y, 0);
        Vector3 move = cameraRotationY * dir * Time.deltaTime * moveSpeed;
        
        cc.Move(move);
    }
}
