using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;
using UnityEditor;
using Unity.Burst.Intrinsics;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;

    [Header("Setting")]
    [SerializeField] private bool isSetting = false;
    [SerializeField] private GameObject settingPanel;


    [Header("Ranking")]
    [SerializeField] private bool isRanking = false;
    [SerializeField] private GameObject rankingPanel;

    

    private void Awake() {

        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start() {
        
        settingPanel.SetActive(false);
        rankingPanel.SetActive(false);
        settingPanel.transform.localScale = new Vector3(0.25f, 0.25f, 1);
        rankingPanel.transform.localScale = new Vector3(0.25f, 0.25f, 1);
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void SettingPanel()
    {

        if (isSetting) // 판넬이 켜져있다면
        {

            isSetting = !isSetting; // 현재 판넬 상태 반전
            settingPanel.transform.DOScale(0.25f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() =>
            {
                settingPanel.SetActive(!settingPanel.activeSelf);
            }); // 판넬 비활성화
        }
        else // 꺼져있다면
        {

            isSetting = !isSetting; // 현재 판넬 상태 반전
            settingPanel.SetActive(!settingPanel.activeSelf); // 판넬 활성화
            settingPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => {});
        }

    }

    public void RankingPanel()
    {

        if (isRanking)
        {

            isRanking = !isRanking; // 현재 판넬 상태 반전
            rankingPanel.transform.DOScale(0.25f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => {
                rankingPanel.SetActive(!rankingPanel.activeSelf);
            }); // 판넬 비활성화
        }
        else
        {

            isRanking = !isRanking; // 현재 판넬 상태 반전
            rankingPanel.SetActive(!rankingPanel.activeSelf); // 판넬 활성화
            rankingPanel.transform.DOScale(1f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() => {});
        }

    }

    public void GameScene() {

        SceneManager.LoadScene("Game");
    }
}
