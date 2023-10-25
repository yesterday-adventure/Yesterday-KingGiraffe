using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 1. ���콺 Ŭ���� �ؼ� ���̸� �߻� �� ���� ������Ʈ�� ��ũ�� leg �� ��
    // 2. ���� �θ� �������� �ٸ��� �����̰� ���ֱ�

    // ������ ����
    [SerializeField] GameObject playerParentX, groundX, playerX;       // �÷��̾� ��� �ݶ��̴� ����
    private bool moving = false;        // ���� �����̴°�.
    private bool ishead = false;
    private GameObject parent;          // �θ� ������Ʈ. ������ ���ؼ�
    private LegParent nowLeg;       // ��ũ��Ʈ ĳ��
    private Vector2 dir;

    // ���̰���
    private Camera main;        // ī�޶� ĳ��
    private RaycastHit2D hit;       // �´� ������Ʈ
    private Vector3 mousePos;       // ���� ���콺 ������

    // ��������
    private Rigidbody2D playerBody;
    [SerializeField] private Vector2 dash = new Vector2(10, 5);

    private void Start()
    {
        main = Camera.main;
        playerBody = playerX.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = main.ScreenToWorldPoint(Input.mousePosition);         // ó�� Ȯ�θ� �Ϸ���
            hit = Physics2D.Raycast(mousePos, transform.forward, 15f);
            if (hit)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("leg"))
                {
                    moving = true;
                    nowLeg = hit.collider.gameObject.GetComponent<LegParent>();
                    parent = nowLeg.parent;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            moving=false;
        }

        // 90�� �����ϱ� �����
        if (moving)
        {
            if (!nowLeg.NinetyEuler()) return;

            //Debug.Log(hit.collider.gameObject.name + "�ٸ� ������");
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!nowLeg.isHead)     // �Ӹ��� �ƴϰ� �ٸ���
            {
                dir = new Vector2(parent.transform.position.x - mousePos.x, parent.transform.position.y - mousePos.y);            // �ٸ�
            }
            else
            {
                // �Ӹ��̸�
                dir = new Vector2(mousePos.x - parent.transform.position.x, mousePos.y - parent.transform.position.y);            // �Ӹ�
            }
            //if ((dir.normalized.x > 0 && dir.normalized.y < 0) || (dir.normalized.x < 0 && dir.normalized.y < 0)) return;           // 90�� ������

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            parent.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            nowLeg.NinetyEuler();
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Dash();
    }

    public void Dash()
    {
        if (PointManager.Instance.canDash)
        {
            playerBody.AddForce(new Vector2(dash.x, dash.y), ForceMode2D.Impulse);
            PointManager.Instance.ResetDash();
        }
    }

    private void FixedUpdate()
    {
        playerParentX.transform.position = new Vector3(playerX.transform.localPosition.x, 0, 0);
        groundX.transform.position = new Vector3(playerX.transform.localPosition.x, -5.71f, 0);
    }
}
