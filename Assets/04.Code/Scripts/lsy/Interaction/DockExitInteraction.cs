using UnityEngine;

public class DockExitInteraction : MonoBehaviour, IInteractable
{
    private CameraMove _cameraMove;
    private UserMove _userMove;
    public GameObject parentObject;
    public GameObject childObjectUser;
    public MoveBoatCurve moveBoatCurve;
    public void Start()
    {
        _cameraMove = Camera.main.GetComponent<CameraMove>();
        // FIXME : 실제 유저 이동 스크립트로 변경 필요
        _userMove = GameObject.FindWithTag("User").GetComponent<UserMove>();
    }
    public void Interact()
    {
        moveBoatCurve.isBoatMoving = false;
        childObjectUser.transform.SetParent(parentObject.transform);
        
        childObjectUser.transform.localPosition = Vector3.zero;
        childObjectUser.transform.localRotation = Quaternion.identity;
        childObjectUser.transform.localScale = Vector3.one;
        
        Debug.Log("DockInteraction : active");
        _cameraMove.SetCurObjectToFollowUser();
        _userMove.enabled = true;
        
    }
}
