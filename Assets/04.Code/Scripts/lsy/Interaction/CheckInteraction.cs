using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class CheckInteraction : MonoBehaviour
{
    #region SerializeField

    // [SerializeField] private TMP_Text _interactText;
    [SerializeField] private float _checkRate = 0.05f;
    [SerializeField] private float _maxDistance = 10.0f;
    [SerializeField] private LayerMask _layerMask;

    #endregion

    #region private field

    private float _lastCheckTime;

    private GameObject _curGameObject;
    private IInteractable _curInteractable;

    private Camera _camera;

    #endregion

    public GameObject user;
    void Awake()
    {
        _camera = Camera.main;
        //_layerMask = LayerMask.GetMask("Interactable");
    }

    void Update(){
        Debug.DrawRay(transform.position, transform.forward * _maxDistance, Color.yellow);
        if (Time.time - _lastCheckTime > _checkRate)
        {
            _lastCheckTime = Time.time;

            //Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            //, _layerMask
            if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
            {
                Debug.Log("Exist");
                if (hit.collider.gameObject != _curGameObject)
                {
                    _curGameObject = hit.collider.gameObject;
                    _curInteractable = hit.collider.GetComponent<IInteractable>();
                    // SetPromptText();
                }
            }
            else
            {
                Debug.Log("null");
                _curGameObject = null;
                _curInteractable = null;
                // _interactText.gameObject.SetActive(false);
            }
        }
    }
    
    // private void SetPromptText()
    // {
    //     _interactText.gameObject.SetActive(true);
    //     _interactText.text = _curInteractable.GetInteractText();
    // }

    //InputAction.CallbackContext callbackContext
    public void OnInteraction()
    {
        Debug.Log("OnInteract");
        // Debug.Log($"OnInteract, {callbackContext.phase} {_curInteractable}");
        //
        //callbackContext.phase == InputActionPhase.Started && 
        if (_curInteractable != null)
        {
            // {
            _curInteractable.Interact();
        }
        // _interactText.gameObject.SetActive(false);
        //}

    }

}
