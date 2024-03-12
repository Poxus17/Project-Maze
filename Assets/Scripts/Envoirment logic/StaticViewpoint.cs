using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class StaticViewpoint : MonoBehaviour
{
    [SerializeField] float transitionTime = 1f;
    [SerializeField] bool changeMode = true;
    [SerializeField] Transform cameraRoot;
    [SerializeField] string viewInteractionTag;
    [SerializeField] StringVariable interactionTag;
    [SerializeField] InputAction exitBind;
    [SerializeField] UnityEvent onExit;
    private Vector3 viewPosition;
    private Quaternion viewRotation;
    private Vector3 playerPos;
    private Quaternion playerRot;
    private LayerMask defaultLayerMask;

    private void Start(){
        viewPosition = cameraRoot.position;
        viewRotation = cameraRoot.rotation;
        defaultLayerMask = gameObject.layer;
        exitBind.performed += ExitStaticViewpoint;
    }

    public void EnterStaticViewpoint(){
        cameraRoot.position = PlayerCameraHandler.instance.position;
        cameraRoot.rotation = PlayerCameraHandler.instance.rotation;
        PlayerCameraHandler.instance.LendCameraTo(cameraRoot);
        
        if(changeMode)
            InputSystemHandler.instance.SetUIMode(true);

        if(viewInteractionTag != "")
            interactionTag.value = viewInteractionTag;

        gameObject.layer = LayerMask.NameToLayer("Default");

        PlayerCameraHandler.instance.TransitionLender(viewPosition, viewRotation);

        exitBind.Enable();
    }

    public void ExitStaticViewpoint(InputAction.CallbackContext context){
        cameraRoot.position = viewPosition;
        cameraRoot.rotation = viewRotation;

        PlayerCameraHandler.instance.ReturnCamera(PostTransition);
        exitBind.Disable();
    }

    public void PostTransition(){
        if(changeMode)
            InputSystemHandler.instance.SetUIMode(false);

        if(viewInteractionTag != "")
            interactionTag.RestoreDefault();

        gameObject.layer = defaultLayerMask;
        PlayerCameraHandler.instance.EndCameraLend();
    }
    void OnDestroy(){
        exitBind.performed -= ExitStaticViewpoint;
        PlayerCameraHandler.instance.EndCameraLend();
    }
}
