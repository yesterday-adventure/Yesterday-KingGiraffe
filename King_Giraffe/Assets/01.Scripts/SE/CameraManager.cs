using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject target; // 카메라가 따라갈 대상
    [SerializeField] private float moveSpeed; // 카메라가 따라갈 속도
    private Vector3 targetPosition; // 대상의 현재 위치
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    private void LateUpdate()
    {
        // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
        //targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        targetPosition = new Vector3(target.transform.position.x, mainCam.transform.position.y, mainCam.transform.position.z);

        //Debug.Log(targetPosition);

        // vectorA -> B까지 T의 속도로 이동
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
