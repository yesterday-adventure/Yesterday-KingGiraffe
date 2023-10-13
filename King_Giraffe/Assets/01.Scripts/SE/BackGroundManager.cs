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
    [SerializeField] [Range(0.05f, 7f)] private float cloudSpeed = 0.1f;
    private float movex = -19.2f;        // �÷��̾ �����ӿ� ���� ������ ���������� ����

    public void OnCloudsMove(float moveX)
    {
        movex += moveX;
        foreach (var cloud in clouds)
        {
            cloud.transform.position = new Vector3(cloud.transform.position.x + moveX , cloud.transform.position.y, 0);
        }
    }

    private void LateUpdate()
    {
        foreach (var cloud in clouds)
        {
            cloud.transform.Translate(Vector3.left * Time.deltaTime * cloudSpeed);

            if (cloud.transform.position.x < movex + (movex / 2))
            {
                cloud.transform.position = new Vector3((movex * -2f) + (movex / 2), 0, 0);
            }
        }
    }
}
