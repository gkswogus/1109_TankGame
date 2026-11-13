using System.Collections;
using System.Collections.Generic;
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


    //적 총알 충돌 시 카메라 돌려주는 부분
    [Header("피격 회전 설정 낮을수록빠름, 높을수록 느림")]
    [SerializeField] private float hitRotateDuration = 0.5f;

    private bool isHitRotating;
    private float hitElapsed;

    public void PlayHitEffect()
    {
        if (isHitRotating)
            return;

        StartCoroutine(RotateHit());
    }

    private IEnumerator RotateHit()
    {
        isHitRotating = true;

        float elapsed = 0f;

        while (elapsed < hitRotateDuration)
        {
            elapsed += Time.deltaTime;

            float angle = Mathf.Lerp(
                0f, 360f, elapsed / hitRotateDuration);

            transform.localRotation =
                Quaternion.Euler(0f, 0f, angle);

            yield return null;
        }

        transform.localRotation = Quaternion.identity;

        isHitRotating = false;
    }
}
