using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    //private float startPosX,  startPosY;
    private bool isBeingHeld = false;

    private void Update()
    {
        if (isBeingHeld)
        {
            Vector2 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 dir = new Vector2(parent.transform.position.x - mousePos.x, parent.transform.position.y - mousePos.y);
            // 방향은 내 위치 - 마우스 포지션

            Debug.Log(dir.normalized);
            if ((dir.normalized.x > 0 && dir.normalized.y < 0) || (dir.normalized.x < 0 && dir.normalized.y < 0)) return;

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            //float angle = Mathf.Clamp(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, 0f, 180f);
            
            //Debug.Log(angle);       // 0 ~ 180까지

            parent.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);      // Z축을 변경해줌
            //parent.transform.rotation = Quaternion.AngleAxis(Mathf.Clamp(angle - 90, -90, 90), Vector3.forward);      // Z축을 변경해줌
        }
    }

    // parent 의 각도는 -90 ~ 90 임.

    private void OnMouseDown()
    {
        Debug.Log("눌림");
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //startPosX = mousePos.x - transform.position.x;
            //startPosY = mousePos.y - transform.position.y;

            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}
