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
        if (nowplayerX < player.position.x)        // �÷��̾�� �� ũ��
        {
            moveX = 19.2f;
        }
        else if (nowplayerX > player.position.x)
        {
            moveX = -19.2f;
        }
        nowplayerX = player.position.x;
        
    }

    private void OnTriggerExit2D(Collider2D collision)          // ��������
    {
        if (!collision.CompareTag("Player"))        // �÷��̾� �ƴϸ� ����
            return;

        Debug.Log("dsdf");
        transform.position = new Vector3(transform.position.x + (moveX * 2), transform.position.y, 0);
        move?.Invoke(moveX);
    }
}
