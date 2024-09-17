using UnityEngine;

public class InstrumentInteraction : MonoBehaviour, IInteractable
{
    public GameObject RhythmUI;
    public void Start()
    {
        // _cameraMove = Camera.main.GetComponent<CameraMove>();
        // // FIXME : 실제 유저 이동 스크립트로 변경 필요
        // _userMove = GameObject.FindWithTag("Player").GetComponent<UserMove>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            RhythmUI.SetActive(false);
        }
    }
    public void Interact()
    {
        RhythmUI.SetActive(true);

    }
}
