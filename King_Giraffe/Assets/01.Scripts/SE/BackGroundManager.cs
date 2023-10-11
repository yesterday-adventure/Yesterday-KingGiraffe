using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;
    [SerializeField] [Range(0.05f, 1f)] private float cloudSpeed = 0.1f;
    private float movex = 38.4f;        // �÷��̾ �����ӿ� ���� ������ ���������� ����

    private void LateUpdate()
    {
        foreach (var cloud in clouds)
        {
            cloud.transform.Translate(Vector3.left * Time.deltaTime * cloudSpeed);

            if (cloud.transform.position.x < -19.2f)
            {
                cloud.transform.position = new Vector3(38.4f, 0, 0);
            }
        }
    }
}
