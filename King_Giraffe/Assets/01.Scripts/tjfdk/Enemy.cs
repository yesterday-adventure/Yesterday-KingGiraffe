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
        speed = maxSpeed; // 속도 초기화
    }

    private void Update() {
        
        rigid.velocity = Vector3.right * speed; // 사육사 이동

        if (GameManager.instance.isStop == true) // 게임이 끝났다면
            rigid.velocity = Vector3.zero; // 사육사 정지
    }

    private void OnCollisionEnter2D(Collision2D other) { 
        
        if (other.transform.CompareTag("Player")) { // 플레이어와 충돌했다면

            ButtonManager.instance.GameOverPanel(); // 게임오버
        } 
        else if (other.transform.CompareTag("Obs")) { // 장애물과 충돌했다면

            StartCoroutine(Ispeed()); // 스턴
            Destroy(other.gameObject); // 장애물 삭제
        }
    }

    IEnumerator Ispeed() { // 스턴

        speed = daleySpeed; // 속도를 낮추고
        yield return new WaitForSeconds(delay); // n초 지났다면
        speed = maxSpeed; // 속도 정상화
    }
}
