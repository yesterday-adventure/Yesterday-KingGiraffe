using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject gameObj, bg1, bg2;
    [SerializeField] private float maxSpeed, daleySpeed;
    [SerializeField] private float delay;
    float speed;

    Rigidbody2D rigid;
    Animator animator;

    private void Awake() {
        
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        speed = maxSpeed; // 속도 초기화
    }

    private void Update() {
        
        rigid.velocity = Vector3.right * speed; // 사육사 이동
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (!other.transform.CompareTag("Obs")) { // 플레이어와 충돌했다면

            Debug.Log("플레이어와 충돌");
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Destroy(gameObj.gameObject);
            Destroy(bg1.GetComponent<BackGroundMover>());
            Destroy(bg2.GetComponent<BackGroundMover>());
            GameManager.instance.isStop = true;
            ButtonManager_Game.instance.GameOverPanel(); // 게임오버
        } 
        else if(other.transform.CompareTag("Obs")) { // 장애물과 충돌했다면

            Debug.Log("장애물과 충돌");
            SoundManager.instance.PlaySFX("hit");
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
