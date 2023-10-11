using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private GameObject target; // ī�޶� ���� ���
    [SerializeField] private float moveSpeed; // ī�޶� ���� �ӵ�
    private Vector3 targetPosition; // ����� ���� ��ġ
    private Camera mainCam;

    private void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        // this�� ī�޶� �ǹ� (z���� ī�޶��� �״�� ����)
        //targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, mainCam.transform.position.z);

        // vectorA -> B���� T�� �ӵ��� �̵�
        mainCam.transform.position = Vector3.Lerp(mainCam.transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
