using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InstrumentInteraction : MonoBehaviour, IInteractable
{
    public Button introButton;
    public GameObject RhythmUI;
    public void Start()
    {
        // _cameraMove = Camera.main.GetComponent<CameraMove>();
        // // FIXME : 실제 유저 이동 스크립트로 변경 필요
        // _userMove = GameObject.FindWithTag("Player").GetComponent<UserMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("User"))
        {
            StartCoroutine(ButtonSetActive());
        }
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
    
    IEnumerator ButtonSetActive()
    {
        introButton.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        introButton.gameObject.SetActive(false);
    }

    public void ClickRhythmButton()
    {
        RhythmUI.SetActive(true);
    }
}
