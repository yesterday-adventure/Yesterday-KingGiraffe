using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstaclePos {

    public GameObject pos;
    public bool use;
}

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;

    [Header("Enemy")]
    [SerializeField] private GameObject enemy; // 사육사
    
    [Header("Obstacle")]
    [SerializeField] int curObsCount = 0; // 현재 장애물 개수
    [SerializeField] List<GameObject> obsstacleList; // 장애물 리스트
    [SerializeField] List<ObstaclePos> obsPosList; // 장애물 생성 위치 리스트

    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this);
    }

    private void EnemySpawn() { // 사육사를 생성

        // 사육사 소환!
        enemy.SetActive(true);
    }

    public void ObsCount() { // 장애물 개수 증가
        
        if (BackGround.instance.turnCount % 5 == 0)
            curObsCount++;
    }

    public void SpawnObs() { // 장애물 생성

        for (int i = 0; i < curObsCount; ++i) { // 장애물 생성

            int ran = Random.Range(0, obsPosList.Count); // 랜덤

            if (obsPosList[ran].use == true)        
                i--;

            Instantiate(obsstacleList[Random.Range(0, obsPosList.Count)], obsPosList[ran].pos.transform.position, Quaternion.identity);
            obsPosList[ran].use = true;
        }
    }
}
