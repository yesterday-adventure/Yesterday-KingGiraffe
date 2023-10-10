using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxSpeed, daleySpeed;
    [SerializeField] private float delay;
    float speed;

    Rigidbody2D rigid;

    private void Awake() {
        
        rigid = GetComponent<Rigidbody2D>();
        speed = maxSpeed;
    }

    private void Update() {
        
        rigid.velocity = Vector3.right * speed;

        if (GameManager.instance.isStop == true)
            rigid.velocity = Vector3.zero;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.transform.CompareTag("Player")) {

            ButtonManager.instance.GameOverPanel();
        } 
        else if (other.transform.CompareTag("Obs")) {

            StartCoroutine(Ispeed());
            Destroy(other.gameObject);
        }
    }

    IEnumerator Ispeed() {

        speed = daleySpeed;
        yield return new WaitForSeconds(delay);
        speed = maxSpeed;
    }
}
