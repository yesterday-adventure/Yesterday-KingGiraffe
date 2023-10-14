using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackGroundMover : MonoBehaviour
{
    public UnityEvent<float> move;

    [SerializeField] private Transform player;
    private float nowplayerX;
    private float moveX;

    private void Start()
    {
        nowplayerX = player.position.x;
    }

    private void FixedUpdate()
    {
        if (nowplayerX < player.position.x)        // 플레이어꺼가 더 크면
        {
            moveX = 19.2f;
        }
        else if (nowplayerX > player.position.x)
        {
            moveX = -19.2f;
        }
        nowplayerX = player.position.x;
        
    }

    private void OnTriggerExit2D(Collider2D collision)          // 나가지면
    {
        if (!collision.CompareTag("Player"))        // 플레이어 아니면 나가
            return;

        Debug.Log("dsdf");
        transform.position = new Vector3(transform.position.x + (moveX * 2), transform.position.y, 0);
        move?.Invoke(moveX);
    }
}
