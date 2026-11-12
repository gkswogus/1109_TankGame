using UnityEngine;

public class CameraCollison : MonoBehaviour
{
    [Header("카메라 충돌 설정")]
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private float offset = 0.1f;

    [SerializeField] private LayerMask obstacleLayer;

    private Vector3 defaultPosition;

    private void Start()
    {
        // 원래 카메라 위치 저장
        defaultPosition = transform.localPosition;
    }

    private void LateUpdate()
    {
        // 원래 카메라 위치로 초기화
        transform.localPosition = defaultPosition;

        // 카메라 피벗 위치
        Vector3 origin = transform.parent.position;

        // 카메라가 있어야 할 위치
        Vector3 direction = transform.position - origin;

        float distance = direction.magnitude;

        if (Physics.SphereCast(
            origin,
            checkRadius,
            direction.normalized,
            out RaycastHit hit,
            distance,
            obstacleLayer))
        {
            // 장애물 앞쪽으로 카메라 이동
            float hitDistance = hit.distance - offset;

            transform.position =
                origin + direction.normalized * Mathf.Max(0f, hitDistance);
        }
    }
}
