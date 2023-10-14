using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ButtonManager_Game : MonoBehaviour
{
    static public ButtonManager_Game instance;

    [Header("GameOver")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gradeTxt1, gradeTxt2, rankTxt, nickTxt;
    [SerializeField] private GameObject win, best;
    public float grade, bestGrade;
    public int rank;

    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }
    private void Start() {

        if (gameOverPanel != null) {

            gameOverPanel.SetActive(false); // 판넬 활성화 초기화
            gameOverPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // 판넬 사이즈 초기화
        }

        win.SetActive(false); // 이미지 활성화 초기화
        best.SetActive(false); // 이미지 활성화 초기화
    }

    public void GameOverPanel() {

        GameManager.instance.isStop = true; // 게임 정지
        grade = GameManager.instance.score; // 현재 점수 받아오기
        rank = BackendRank.Instance.i_rank; // 현재 등수 받아오기
        bestGrade = PlayerPrefs.GetFloat("닉네임", 0.0f); // bestGrade 받아오기

        if (rank == 1) win.SetActive(true); // 1등이라면 1등 이미지를 활성화하고 
        else rankTxt.text = rank.ToString(); // 아니라면 등수를 표시한다.

        if (bestGrade < grade) { // 현재 점수가 최고 점수보다 높다면

            PlayerPrefs.SetFloat("닉네임", grade); // 최고 점수 갱신
            best.SetActive(true); // 최고점 이미지를 활성화
        }

        gradeTxt1.text = "버틴 시간 " + grade.ToString("N2") + "초"; // 현재 점수 표시
        gradeTxt2.text = grade.ToString("N2") + "초"; // 현재 점수 표시
        nickTxt.text = "#" + "닉네임" + " " + "등수"; // 플레이어 닉네임 표시

        gameOverPanel.SetActive(true); // 판넬 활성화
        gameOverPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo); // 판넬 활성화 효과
    }
    
    public void MenuScene() {

        SceneManager.LoadScene("Menu");
    }

    public void GameScene() {

        SceneManager.LoadScene("Game");
    }
}
