using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HidingSpotComponent : MonoBehaviour
{
    [SerializeField] BoolAnnouncerVariable isHiding;
    [SerializeField] BoolAnnouncerVariable checkPlayerCaught;
    [SerializeField] InputAction exitAction;
    [SerializeField] GameObject hideCamera;
    [SerializeField] float getInTime = 1.5f;
    [SerializeField] float closeDoorTime = 0.7f;
    private Vector3 hidePos;
    private Quaternion hideRot;
    private Vector3 playerPos;
    private Quaternion playerRot;
    // Start is called before the first frame update
    void Start()
    {
        exitAction.performed += LeaveHideSpot;

        hidePos = hideCamera.transform.position;
        hideRot = hideCamera.transform.rotation;
    }

    public void InitHide(){
        InputSystemHandler.instance.SetInputActive(false);
        playerPos = PlayerCameraHandler.instance.position;
        playerRot = PlayerCameraHandler.instance.rotation;
        hideCamera.transform.position = playerPos;
        hideCamera.transform.rotation = playerRot;
        PlayerCameraHandler.instance.LendCameraTo(hideCamera.transform);
        checkPlayerCaught.RaiseEvent();
        StartCoroutine(GetIn());
    }

    IEnumerator GetIn(){
        var timer = 0f;
        var alpha = 0f;
        var initialPos = hideCamera.transform.position;
        var initialRot = hideCamera.transform.rotation;

        while(alpha < 1f){
            timer += Time.deltaTime;
            alpha = timer / getInTime;
            hideCamera.transform.position = Vector3.Lerp(initialPos, hidePos, alpha);
            hideCamera.transform.rotation = Quaternion.Lerp(initialRot, hideRot, alpha);
            yield return null;
        }

        //Replace with animation
        UI_TextDisplay.Instance.DisplayText("Closing door...", closeDoorTime - 1);
        GlobalTimerManager.instance.RegisterForTimer(Hide, closeDoorTime);
    }

    public void Hide(){
        if(checkPlayerCaught.value){
            //Add like shuffling sound or something
            return;
        }

        isHiding.value = true;
        exitAction.Enable();
        UI_TextDisplay.Instance.DisplayText("Press E to exit", -1);
    }

    public void LeaveHideSpot(InputAction.CallbackContext context){
        UI_TextDisplay.Instance.FadeOutText();
        isHiding.value = false;
        exitAction.Disable();

        StartCoroutine(GetOut());
    }

    IEnumerator GetOut(){
        var timer = 0f;
        var alpha = 0f;

        while(alpha < 1f){
            timer += Time.deltaTime;
            alpha = timer / getInTime;
            hideCamera.transform.position = Vector3.Lerp(hidePos, playerPos, alpha);
            hideCamera.transform.rotation = Quaternion.Lerp(hideRot, playerRot, alpha);
            yield return null;
        }

        PlayerCameraHandler.instance.ReturnCamera();
        InputSystemHandler.instance.SetInputActive(true);
    }

    private void OnDestroy() {
        exitAction.performed -= LeaveHideSpot;
        PlayerCameraHandler.instance.ReturnCamera();
        InputSystemHandler.instance.SetInputActive(true);
    }
}
