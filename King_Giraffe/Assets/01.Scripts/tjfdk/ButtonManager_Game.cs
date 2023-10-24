using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ButtonManager_Game : MonoBehaviour
{
    static public ButtonManager_Game instance;

    private BackendMenu _backendMenu;

    [Header("GameOver")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gradeTxt1, gradeTxt2, rankTxt;
    [SerializeField] private GameObject best;
    public float grade, bestGrade;

    private void Awake() {
        _backendMenu = GetComponent<BackendMenu>();
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    private void Start() {

        if (gameOverPanel != null) {

            gameOverPanel.SetActive(false); // 판넬 활성화 초기화
            gameOverPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // 판넬 사이즈 초기화
        }
        best.SetActive(false); // 이미지 활성화 초기화
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.T))
            GameOverPanel();
    }

    public void GameOverPanel() {

        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySFX("over");

        grade = GameManager.instance.score; // 현재 점수 받아오기
        Debug.Log(GameManager.instance.score);
        //_backendMenu.RankingInsert((float)GameManager.instance.score);

        gradeTxt1.text = "버틴 시간 " + grade.ToString("N2") + "초"; // 현재 점수 표시
        gradeTxt2.text = grade.ToString("N2") + "초"; // 현재 점수 표시
        rankTxt.text = BackendManager.Instance.userName;

        gameOverPanel.SetActive(true); // 판넬 활성화
        gameOverPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo); // 판넬 활성화 효과
    }
    
    public void MenuScene() {

        SoundManager.instance.PlaySFX("click");
        SceneManager.LoadScene("Menu");
    }

    public void GameScene() {

        SoundManager.instance.PlaySFX("click");
        SceneManager.LoadScene("Game");
    }
}
