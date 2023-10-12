using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    /*
    1. 구름은 계속해서 움직이고 플레이어가 일정이상 이동할 때마다 뒷 배경이 이동함.
    2. 구름은 플레이어가 이동할 때마다 수치값이 더해지거나 빼져야함.


    */

    [SerializeField] private GameObject[] clouds;
    [SerializeField] [Range(0.05f, 1f)] private float cloudSpeed = 0.1f;
    private float movex = 38.4f;        // 플레이어가 움직임에 따라 구름이 움직여지는 정도

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

    /*private void OnTriggerExit2D(Collider2D collision)          // 나가지면
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
