using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    Rigidbody2D _rigid;
    [SerializeField] private float speed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>(); 
    }
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        Vector2 dir = new Vector2(-1, 0);
        _rigid.velocity = dir * speed;
    }
}
