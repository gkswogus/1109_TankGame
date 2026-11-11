using System;
using UnityEditor.Search;
using UnityEngine;

public class PlayerFollowCamera : MonoBehaviour
{
    [Header("카메라 설정")]
    public Transform target;
    public float mouseSensitivity = 3.0f;
    public float minPitch = -45f;
    public float maxPitch = 75f;

    private float yaw;
    private float pitch;
    void Start()
    {
        yaw = transform.eulerAngles.y;
        pitch = 10f;

    }
    private void Update()
    {
 /*      Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
*/
    }

    void LateUpdate()
    {
        if (target == null) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;

        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        // 카메라 회전
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);

        // 플레이어 위치 따라가기
        transform.position = target.position;
    }
}