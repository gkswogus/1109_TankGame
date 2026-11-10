using UnityEngine;
using UnityEngine.UIElements;

public class PlayerFollowCamera : MonoBehaviour
{
    public Transform target;

    [Header("카메라 설정")]
    public Vector3 offset = new Vector3(0, 4, -4);
    public float smoothTime = 0.2f;
    public float fixedXAngle = 30f;

    private Vector3 velocity;

    private void Start()
    {
        if (target == null)
        {
            Debug.LogError("Player가 없습니다.");
            return;
        }

        transform.position = target.TransformPoint(offset);
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 dest = target.TransformPoint(offset);

        transform.position = Vector3.SmoothDamp(
            transform.position,
            dest,
            ref velocity,
            smoothTime
        );

        Quaternion targetRotation = target.rotation * Quaternion.Euler(fixedXAngle, 0, 0);

        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            targetRotation,
            10f * Time.deltaTime
        );
    }
}
