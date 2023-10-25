using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject cutScene;
    public bool isStop = false;
    public float score = 0.0f;
    
    private void Awake() {

        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Start() {

        SoundManager.instance.PlayBGM("BGM");

        PlayerPrefs.SetInt("Tutorial", PlayerPrefs.GetInt("Tutorial", 0));

        if (PlayerPrefs.GetInt("Tutorial") == 0)
        {

            UIManager.instance.CutScene();
            PlayerPrefs.Save();
        }
        else
            cutScene.SetActive(false);
    }
}
