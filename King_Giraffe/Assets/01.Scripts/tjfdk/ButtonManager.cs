using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using UnityEditor;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    [Header("Setting")]
    [SerializeField] private bool isSetting = false;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject settingSavePanel;


    [Header("Ranking")]
    [SerializeField] private bool isRanking = false;
    [SerializeField] private GameObject rankingPanel;
    [SerializeField] private GameObject rankingSavePanel;

    [Header("GameOver")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gradeTxt1, gradeTxt2, rankTxt, nickTxt;
    [SerializeField] private GameObject win, best;
    public float grade, bestGrade;
    public int rank;

    private void Awake() {

        if (instance == null) instance = this;
        else Destroy(this.gameObject);
        
        if (gameOverPanel != null) {

            gameOverPanel.SetActive(false); // 판넬 활성화 초기화
            gameOverPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // 판넬 사이즈 초기화
        }

        win?.SetActive(false); // 이미지 활성화 초기화
        best?.SetActive(false); // 이미지 활성화 초기화
    }

    public void SettingPanel()
    {

        if (isSetting)
        {

            isSetting = !isSetting; // 현재 판넬 상태 반전
            settingPanel.transform.DOScale(0.25f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() =>
            {
                settingSavePanel.SetActive(!settingSavePanel.activeSelf); // 보호 판넬 비활성화
                settingPanel.SetActive(!settingPanel.activeSelf);
            }); // 판넬 비활성화
        }
        else
        {

            isSetting = !isSetting; // 현재 판넬 상태 반전
            settingPanel.SetActive(!settingPanel.activeSelf); // 판넬 활성화
            settingPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() =>
            {
                settingSavePanel.SetActive(!settingSavePanel.activeSelf);
            }); // 보호 판넬 활성화
        }

    }

    public void RankingPanel()
    {

        if (isRanking)
        {

            isRanking = !isRanking; // 현재 판넬 상태 반전
            rankingPanel.transform.DOScale(0.25f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => {
                rankingSavePanel.SetActive(!rankingSavePanel.activeSelf); // 보호 판넬 비활성화
                rankingPanel.SetActive(!rankingPanel.activeSelf);
            }); // 판넬 비활성화
        }
        else
        {

            isRanking = !isRanking; // 현재 판넬 상태 반전
            rankingPanel.SetActive(!rankingPanel.activeSelf); // 판넬 활성화
            rankingPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => {
                rankingSavePanel.SetActive(!rankingSavePanel.activeSelf);
            }); // 보호 판넬 활성화
        }

    }

    public void GameOverPanel() {

        GameManager.instance.isStop = true; // 게임 정지
        grade = GameManager.instance.score; // 현재 점수 받아오기
        // bestGrade 불러오기?,, 이건...

        if (rank == 1) win.SetActive(true); // 1등이라면 1등 이미지를 활성화하고 
        else rankTxt.text = rank.ToString(); // 아니라면 등수를 표시한다.

        if (bestGrade < grade) // 현재 점수가 최고 점수보다 높다면
            best.SetActive(true); // 최고점 이미지를 활성화

        gradeTxt1.text = "버틴 시간 " + grade.ToString("N2") + "초"; // 현재 점수 표시
        gradeTxt2.text = grade.ToString("N2") + "초"; // 현재 점수 표시
        nickTxt.text = "#" + "닉네임"; // 플레이어 닉네임 표시

        gameOverPanel.SetActive(true); // 판넬 활성화
        gameOverPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo); // 판넬 활성화 효과
    }

    public void GameScene() {

        SceneManager.LoadScene("tjfdk");
    }

    public void MenuScene() {

        SceneManager.LoadScene("Menu");
    }
}
