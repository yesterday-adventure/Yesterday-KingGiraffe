using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeadController : MonoBehaviour
{
    // 1. �� �Ӹ��� �����̼��� �����ͼ� 90, -90���� ����ؼ� �̵�.
    // 1- 2. �����η��̾� �������� �������ϰ�
    // 2. ���� ���̸� ���� ����

    [SerializeField] private GameObject parent;
    [SerializeField] [Range(1f, 30f)] private float speed = 15;
    [SerializeField]private bool right = true;      // true -90�� ������ �̵�, ��������.
    private bool gameOver = false;

    private void Update()
    {
        if (!gameOver)
        {
            if (right)      // ���� ���������� �̵�.
            {
                //parent.transform.rotation = new Vector3(0, 0, 0);
                parent.transform.Rotate(0, 0, -(Time.deltaTime * speed));
            }
            else
            {
                parent.transform.Rotate(0, 0, Time.deltaTime * speed);
            }


            Debug.Log(parent.transform.eulerAngles.z);

            if (parent.transform.eulerAngles.z > 90 && parent.transform.eulerAngles.z < 270)        // 90���� ũ�� 270���� ������
            {
                gameOver = true;
                GameOver();
            }
        }
    }

    //private void LateUpdate()
    //{
    //    if (parent.transform.rotation.x > 0)        // ���ʿ� ������, ���߿� �÷��̾ ���� �ǵ帱 �� ȣ��� �Լ��� ����
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
        Debug.Log("���ӳ�!");
    }
}
