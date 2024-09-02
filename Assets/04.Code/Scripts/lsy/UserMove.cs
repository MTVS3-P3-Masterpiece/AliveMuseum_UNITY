using UnityEngine;

public class UserMove : MonoBehaviour
{
    private CharacterController cc;
    public float moveSpeed = 7f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        
        Vector3 dir = new Vector3(h, 0f, v);
        dir.Normalize();
        
        cc.Move(moveSpeed * Time.deltaTime * dir);
    }
}
