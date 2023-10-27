using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

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

    [Header("Point")]
    [SerializeField] private Slider dashGage;

    [Header("Location")]
    [SerializeField] private Slider locationGage;

    [Header("CutScene")]
    [SerializeField] private List<Image> cutSceneList;

    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start() {
        
        if (warning != null) { // 시작 UI

            warning.transform?.DOScale(0.85f, tweenDuring).SetEase(Ease.Linear).SetLoops(tweeningCount, LoopType.Yoyo).OnComplete(() => { warning.SetActive(false);});
        }

        if (dashGage != null)
        {
            dashGage.maxValue = PointManager.Instance.pointMax;
            dashGage.value = 0;
        }

        if (locationGage != null)
        {
            locationGage.maxValue = Enemy.Instance.startDistance;
            locationGage.value = locationGage.maxValue;
        }
    }

    private void Update() {
        
        if (GameManager.instance.isStop == false && timerTxt != null) { // 현재 타이머
                
            if (timerTxt != null) {

                GameManager.instance.score += Time.deltaTime;
                timerTxt.text = GameManager.instance.score.ToString("N2") + "초";
            }
        }
        
        if (dashGage != null)
            dashGage.value = PointManager.Instance.curPoint;

        if (locationGage != null)
            locationGage.value = Enemy.Instance.curDistance;
    }

    public void CutScene() {

        foreach (Image scene in cutSceneList) {

            scene.DOFade(0f, 2.5f).OnComplete(() => {});

            if (cutSceneList[1] == scene)
                SoundManager.instance.PlaySFX("");
        }
    }
}
