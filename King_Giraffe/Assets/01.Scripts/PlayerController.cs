using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 1. 마우스 클릭을 해서 레이를 발사 후 얻어온 오브젝트의 태크가 leg 일 때
    // 2. 그의 부모를 움직여서 다리가 움직이게 해주기

    // 움직임 관련
    private bool moving = false;        // 지금 움직이는가.
    private GameObject parent;          // 부모 오브젝트. 움직임 위해서
    private LegParent nowLeg;       // 스크립트 캐싱

    // 레이관련
    private Camera main;        // 카메라 캐싱
    private RaycastHit2D hit;       // 맞는 오브젝트
    private Vector3 mousePos;       // 지금 마우스 포지션

    private void Start()
    {
        main = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePos = main.ScreenToWorldPoint(Input.mousePosition);         // 처음 확인만 하려고
            hit = Physics2D.Raycast(mousePos, transform.forward, 15f);
            if (hit)
            {
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

        // 90도 감지하기 만들기
        if (moving)
        {
            if (!nowLeg.NinetyEuler()) return;

            //Debug.Log(hit.collider.gameObject.name + "다리 움직임");
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 dir = new Vector2(parent.transform.position.x - mousePos.x, parent.transform.position.y - mousePos.y);            // 다리
            //Vector2 dir = new Vector2(mousePos.x - parent.transform.position.x, mousePos.y - parent.transform.position.y);            // 머리
            //if ((dir.normalized.x > 0 && dir.normalized.y < 0) || (dir.normalized.x < 0 && dir.normalized.y < 0)) return;           // 90도 까지만

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            parent.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

            nowLeg.NinetyEuler();
        }
    }
}
