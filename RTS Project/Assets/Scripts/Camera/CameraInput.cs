using UnityEngine;
using UnityEngine.InputSystem;

public class CameraInput : MonoBehaviour
{
    public float MoveSpeed = 1f;
    public InputActionAsset Controls;
    private string actionMapName = "Camera";
    private string moveActionName = "Move";
    private string rotateActionName = "Rotate";
    private string zoomActionName = "Zoom";

    private InputAction moveAction;
    private InputAction rotateAction;
    private InputAction zoomAction;

    public Vector2 MoveInput { get; private set; }
    public float RotateInput { get; private set; }
    public Vector2 ZoomInput { get; private set; }

    public static CameraInput Instance { get; private set; }


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        moveAction = Controls.FindActionMap(actionMapName).FindAction(moveActionName);
        rotateAction = Controls.FindActionMap(actionMapName).FindAction(rotateActionName);
        zoomAction = Controls.FindActionMap(actionMapName).FindAction(zoomActionName);
        registerInputActions();
    }

    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
        zoomAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
        zoomAction.Disable();
    }

    private void registerInputActions()
    {
        moveAction.performed += context => MoveInput = context.ReadValue<Vector2>();
        moveAction.canceled += context => MoveInput = Vector2.zero;

        rotateAction.performed += context => RotateInput = context.ReadValue<float>();
        rotateAction.canceled += context => RotateInput = 0f;

        zoomAction.performed += context => ZoomInput = context.ReadValue<Vector2>();
        zoomAction.canceled += context => ZoomInput = Vector2.zero;
    }

}
