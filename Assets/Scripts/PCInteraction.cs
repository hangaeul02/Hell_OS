using UnityEngine;

public class PCInteraction : MonoBehaviour
{
    public Camera mainCamera;
    public Transform monitorFocusPoint; // 모니터 바로 앞의 Transform
    public float transitionSpeed = 5f;

    private bool isFocusing = false;
    private Vector3 originalPos;
    private Quaternion originalRot;

    void Start()
    {
        originalPos = mainCamera.transform.position;
        originalRot = mainCamera.transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isFocusing)
        {
            CheckClick();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isFocusing)
        {
            isFocusing = false;
            Cursor.lockState = CursorLockMode.Locked; // 다시 시점 자유롭게
        }

        // 시점 이동 보간
        Vector3 targetPos = isFocusing ? monitorFocusPoint.position : originalPos;
        Quaternion targetRot = isFocusing ? monitorFocusPoint.rotation : originalRot;

        mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPos, Time.deltaTime * transitionSpeed);
        mainCamera.transform.rotation = Quaternion.Slerp(mainCamera.transform.rotation, targetRot, Time.deltaTime * transitionSpeed);
    }

    void CheckClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Computer"))
            {
                isFocusing = true;
                Cursor.lockState = CursorLockMode.None; // 마우스 커서 활성화
            }
        }
    }
}