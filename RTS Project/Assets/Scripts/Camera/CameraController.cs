using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CameraInput cameraInput;

    public float MoveSpeed = 10f;
    public float RotateSpeed = 90f;
    public float ZoomSpeed = 1f;
    public CinemachineFreeLook VirtualCam;


    private void Start()
    {
        cameraInput = CameraInput.Instance;
    }

    private void Update()
    {
        handleMovement();
    }

    private void handleMovement()
    {
        if (cameraInput.MoveInput.magnitude > 0f)
        {
            Vector3 moveVector = new Vector3(cameraInput.MoveInput.x, 0f, cameraInput.MoveInput.y) * MoveSpeed * Time.deltaTime;
            transform.Translate(moveVector, Space.Self);
        }

        if (cameraInput.RotateInput != 0f)
        {
            Vector3 rotateVector = new Vector3(0f, cameraInput.RotateInput, 0f) * RotateSpeed * Time.deltaTime;
            transform.Rotate(rotateVector);
        }

        VirtualCam.m_YAxis.m_InputAxisValue = cameraInput.ZoomInput * ZoomSpeed * Time.deltaTime;
    }
}
