using UnityEngine;

public class DockEnterInteraction : MonoBehaviour, IInteractable
{
    private CameraMove _cameraMove;
    private UserMove _userMove;
    public MoveBoatCurve _moveBoatCurve;
    public void Start()
    {
        _cameraMove = Camera.main.GetComponent<CameraMove>();
        // FIXME : 실제 유저 이동 스크립트로 변경 필요
        _userMove = GameObject.FindWithTag("User").GetComponent<UserMove>();
    }
    public void Interact()
    {
        Debug.Log("DockInteraction : active");
        _cameraMove.SetCurObjectToFollowBoat();
        _userMove.enabled = false;
        _moveBoatCurve.StartMoveBoatCourse1();
    }
}
