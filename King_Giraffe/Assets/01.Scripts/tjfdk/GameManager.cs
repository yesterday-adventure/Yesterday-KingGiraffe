using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isStop = false;

    public float timer = 0;
    [SerializeField] private TextMeshProUGUI timerTxt;
    [SerializeField] private GameObject warning, enemy;
    [SerializeField] private int tweeningCount = 5;
    [SerializeField] private float tweenDuring = 0.5f, enemySpawnTime;
    
    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this);
    }

    private void Start() {
        
        // 말풍선 깜빢x2
        warning.transform.DOScale(0.85f, tweenDuring).SetEase(Ease.Linear).SetLoops(tweeningCount, LoopType.Yoyo).OnComplete(() => { warning.SetActive(false);});

        // n초 후에 함수 실행
        Invoke("EnemySpawn", enemySpawnTime);
    }

    private void EnemySpawn() {

        // 사육사 소환!
        enemy.SetActive(true);
    }

    private void Update() {

        if (GameManager.instance.isStop == false) {
            
            timer += Time.deltaTime;
            timerTxt.text = timer.ToString("N2") + "초";
        }
    }
}
