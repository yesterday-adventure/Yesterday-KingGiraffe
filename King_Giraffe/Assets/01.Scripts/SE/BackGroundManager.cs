using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    /*
    1. ������ ����ؼ� �����̰� �÷��̾ �����̻� �̵��� ������ �� ����� �̵���.
    2. ������ �÷��̾ �̵��� ������ ��ġ���� �������ų� ��������.
    */

    [SerializeField] private GameObject[] clouds;
    [SerializeField] private GameObject cloudSet;
    [SerializeField] [Range(0.05f, 7f)] private float cloudSpeed = 0.1f;
    private float movex = -19.2f;        // �÷��̾ �����ӿ� ���� ������ ���������� ����

    public void OnCloudsMove(float moveX)       // �޹���� �����̸� ������ �����̰�
    {
        cloudSet.transform.position = new Vector3(cloudSet.transform.position.x + moveX, cloudSet.transform.position.y, 0);
    }

    private void LateUpdate()
    {
        foreach (var cloud in clouds)
        {
            cloud.transform.Translate(Vector3.left * Time.deltaTime * cloudSpeed);

            if (cloud.transform.localPosition.x < movex + (movex / 2))
            {
                cloud.transform.localPosition = new Vector3((movex * -2f) + (movex / 2), 0, 0);
            }
        }
    }
}
