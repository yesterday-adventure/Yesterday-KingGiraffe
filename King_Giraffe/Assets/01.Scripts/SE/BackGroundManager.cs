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
    [SerializeField] private GameObject cloudSet;
    [SerializeField] [Range(0.05f, 7f)] private float cloudSpeed = 0.1f;
    private float movex = -19.2f;        // 플레이어가 움직임에 따라 구름이 움직여지는 정도

    public void OnCloudsMove(float moveX)       // 뒷배경이 움직이면 구름도 움직이게
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
