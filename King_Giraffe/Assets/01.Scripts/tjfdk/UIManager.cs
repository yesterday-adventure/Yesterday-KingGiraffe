using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEditor.SearchService;

public class UIManager : MonoBehaviour
{
    // public static UIManager instance;
    static public UIManager instance;        

    [Header("BeginAnim")]
    [SerializeField] private GameObject warning;
    [SerializeField] private int tweeningCount = 5;
    [SerializeField] private float tweenDuring = 0.5f, enemySpawnTime;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI timerTxt;

    [Header("CutScene")]
    [SerializeField] private List<Image> cutSceneList;

    // private void Awake()
    // {
    //     if (instance == null)                
    //         instance = this;               
    //     else                                  
    //         Destroy(this.gameObject);
    // }
    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start() {
        
        if (warning != null) { // 시작 UI

            warning.transform?.DOScale(0.85f, tweenDuring).SetEase(Ease.Linear).SetLoops(tweeningCount, LoopType.Yoyo).OnComplete(() => { warning.SetActive(false);});
            GameManager.instance.Invoke("EnemySpawn", enemySpawnTime);
        }
    }

    private void Update() {
        
        if (GameManager.instance.isStop == false && timerTxt != null) { // 현재 타이머
                
                if (timerTxt != null) {

                    GameManager.instance.score += Time.deltaTime;
                    timerTxt.text = GameManager.instance.score.ToString("N2") + "초";
                }
        }
    }

    public void CutScene() {

        foreach (Image scene in cutSceneList) {

            scene.material.DOFade(1f, 3f).SetLoops(1, LoopType.Yoyo).OnComplete(() => {});
        }
    }
}
