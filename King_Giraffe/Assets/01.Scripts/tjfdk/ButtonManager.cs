using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private bool isSetting = false;
    [SerializeField] private GameObject settingPanel;
    [SerializeField] private GameObject settingSavePanel;

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

    public void EnterGame() {

        SceneManager.LoadScene("tjfdk");
    }
}
