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

    /*private void OnTriggerExit2D(Collider2D collision)          // ��������
    {
        if (!collision.CompareTag("Area"))
            return;

        Vector3 playerPos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;

        float diffx = Mathf.Abs(playerPos.x - myPos.x);
        float diffy = Mathf.Abs(playerPos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirx = playerDir.x < 0 ? -1 : 1;
        float diry = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag)
        {
            case "Ground":
                {
                    if (diffx > diffy)
                    {
                        transform.Translate(Vector2.right * dirx * 40);
                    }
                    else if (diffx < diffy)
                    {
                        transform.Translate(Vector2.up * diry * 40);
                    }
                }
                break;
            case "Enemy":
                {
                    transform.Translate(playerDir * 20 + new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f));
                }
                break;
        }
    }*/
}
