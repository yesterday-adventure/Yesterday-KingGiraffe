using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadController : MonoBehaviour
{
    // 1. 내 머리의 로테이션을 가져와서 90, -90으로 계속해서 이동.
    // 1- 2. 오더인레이어 변경으로 디테일하게
    // 2. 목이 꺽이면 게임 종료

    [SerializeField] private GameObject parent;
    [SerializeField] [Range(1f, 30f)] private float speed = 15;
    [SerializeField]private bool right = true;      // true -90도 쪽으로 이동, 오른쪽임.
    private bool gameOver = false;

    private void Update()
    {
        if (!gameOver)
        {
            if (right)      // 목이 오른쪽으로 이동.
            {
                //parent.transform.rotation = new Vector3(0, 0, 0);
                parent.transform.Rotate(0, 0, -(Time.deltaTime * speed));
            }
            else
            {
                parent.transform.Rotate(0, 0, Time.deltaTime * speed);
            }


            Debug.Log(parent.transform.eulerAngles.z);

            if (parent.transform.eulerAngles.z > 90 && parent.transform.eulerAngles.z < 270)        // 90보다 크고 270보다 작으면
            {
                gameOver = true;
                GameOver();
            }
        }
    }

    //private void LateUpdate()
    //{
    //    if (parent.transform.rotation.x > 0)        // 왼쪽에 가깝냐, 나중에 플레이어가 목을 건드릴 때 호출될 함수로 빼기
    //    {
    //        right = false;
    //    }
    //    else
    //    {
    //        right = true;
    //    }
    //}

    private void GameOver()
    {
        Debug.Log("게임끝!");
    }
}
