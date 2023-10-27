using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Enemy Instance;

    [SerializeField] private GameObject gameObj, player, bg1, bg2;
    [SerializeField] private float maxSpeed, daleySpeed;
    [SerializeField] private float delay;
    [SerializeField] private Color hitColor;
    float speed;
    bool start = false;

    public float startDistance, curDistance;

    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer spriteRenderer;

    private void Awake() {

        if (Instance == null)
        {
            Instance = this;
        }

        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        speed = maxSpeed; // 속도 초기화

        Invoke("Spawn", 15f);

        startDistance = Vector3.Distance(player.transform.position, transform.position);
    }

    private void Spawn() { start = true; }

    private void Update() {
        
        if (start)
            rigid.velocity = Vector3.right * speed; // 사육사 이동

        curDistance = Vector3.Distance(player.transform.position, transform.position);
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if (!other.transform.CompareTag("Obs")) { // 플레이어와 충돌했다면

            Destroy(this.gameObject);
            Destroy(other.gameObject);
            Destroy(gameObj.gameObject);
            Destroy(bg1.GetComponent<BackGroundMover>());
            Destroy(bg2.GetComponent<BackGroundMover>());
            GameManager.instance.isStop = true;
            ButtonManager_Game.instance.GameOverPanel(); // 게임오버
        } 
        else if(other.transform.CompareTag("Obs")) { // 장애물과 충돌했다면

            SoundManager.instance.PlaySFX("hit");
            StartCoroutine(Ispeed()); // 스턴
            Destroy(other.gameObject); // 장애물 삭제
        }
    }

    IEnumerator Ispeed() { // 스턴

        speed = daleySpeed; // 속도를 낮추고
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(delay); // n초 지났다면
        speed = maxSpeed; // 속도 정상화
        spriteRenderer.color = Color.white;
    }
}
