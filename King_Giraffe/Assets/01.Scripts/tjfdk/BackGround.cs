using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Windows.Speech;
using UnityEngine.Video;

public class BackGround : MonoBehaviour
{
    public static BackGround instance;

    [SerializeField] private GameObject menuBackGround;
    [SerializeField] private GameObject gameBackGround;

    public int turnCount = 0;

    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Update() {

        // if (GameManager.instance.isStop == false) {

            if (menuBackGround != null) {

                menuBackGround.transform.position += Vector3.left * 100f * Time.deltaTime;
                if (menuBackGround.transform.position.x <= -970)
                    menuBackGround.transform.position = new Vector3(970, 540, 0);
            }

            if (gameBackGround != null) {
                
                // 이동하고 <- 개어려움;;
                
                // if 스크롤 해줘야하니?
                if (gameBackGround.transform.position.x <= -970) {

                    gameBackGround.transform.position = new Vector3(970, 540, 0); // 위치 다시 돌리고
                    turnCount++; // 반복 횟수 체크
                    ObstacleManager.instance.ObsCount(); // 장애물 확인
                }
            }
        // }

    }
}
