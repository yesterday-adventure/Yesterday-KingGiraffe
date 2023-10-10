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
    [SerializeField] private bool isSetting = false;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject settingSavePanel;

    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TextMeshProUGUI gradeTxt1, gradeTxt2, rankTxt, nickTxt;
    [SerializeField] private GameObject win, best;
    public float grade, bestGrade;
    public int rank;

    private void Awake() {

        if (instance == null) instance = this;
        else Destroy(this);
        
        if (gameOverPanel != null) {

            gameOverPanel.SetActive(false);
            gameOverPanel.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        if (win != null)
            win.SetActive(false);

        if (best != null)
            best.SetActive(false);
    }

    public void SettingPanel() {

        if (isSetting) {
            
            isSetting = !isSetting; // 현재 판넬 상태 반전
            settingPanel.transform.DOScale(0.25f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => {
                settingSavePanel.SetActive(!settingSavePanel.activeSelf); // 보호 판넬 비활성화
                settingPanel.SetActive(!settingPanel.activeSelf);}); // 판넬 비활성화
        }
        else {
            
            isSetting = !isSetting; // 현재 판넬 상태 반전
                settingPanel.SetActive(!settingPanel.activeSelf); // 판넬 활성화
                settingPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => {
                settingSavePanel.SetActive(!settingSavePanel.activeSelf);}); // 보호 판넬 활성화
        }
        
    }

    public void GameOverPanel() {

        GameManager.instance.isStop = true;
        grade = GameManager.instance.timer;

        if (rank == 1) win.SetActive(true);
        else rankTxt.text = rank.ToString();

        if (bestGrade < grade)
            best.SetActive(true);

        gradeTxt1.text = "버틴 시간 " + grade.ToString("N2") + "초";
        gradeTxt2.text = grade.ToString("N2") + "초";
        nickTxt.text = "#" + "닉네임";

        gameOverPanel.SetActive(true);
        gameOverPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo);
    }

    public void GameScene() {

        SceneManager.LoadScene("tjfdk");
    }

    public void MenuScene() {

        SceneManager.LoadScene("Menu");
    }
}
