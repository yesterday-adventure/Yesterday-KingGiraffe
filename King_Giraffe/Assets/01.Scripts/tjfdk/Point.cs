using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("leg"))
        {
            PointManager.Instance.curPoint += 1;
            if (PointManager.Instance.curPoint >= PointManager.Instance.pointMax)
                PointManager.Instance.canDash = true;
            Destroy(gameObject);
        }
    }
}
