using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;

    [Header("Enemy")]
    [SerializeField] private GameObject enemy; // 사육사
    
    [Header("Obstacle")]
    [SerializeField] int curObsCount = 0; // 현재 장애물 개수
    [SerializeField] List<GameObject> obsstacleList; // 장애물 리스트
    //[SerializeField] List<GameObject> obsPosList; // 장애물 생성 위치 리스트
    //[SerializeField] List<bool> obsPosVisitList = new List<bool>();
    [SerializeField] List<GameObject> curObs = new List<GameObject>();

    [SerializeField] private GameObject _player;

    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this.gameObject);
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.I))
            SpawnObs();
        else if (Input.GetKeyDown(KeyCode.O))
            ObsCount();
    }

    public void Reset() {

        foreach (GameObject obs in curObs)
            Destroy(obs);
            
        curObs.Clear();
    }

    private void EnemySpawn() { // 사육사를 생성

        // 사육사 소환!
        enemy.SetActive(true);
    }

    public void ObsCount() { // 장애물 개수 증가
        
        if (BackGround.instance.turnCount % 5 == 0 && curObsCount < 3)
            curObsCount++;
        
        SpawnObs();
    }

    public void SpawnObs() { // 장애물 생성

        for (int i = 0; i < curObsCount; ++i) { // 장애물 생성

            int ran = Random.Range((int)_player.transform.position.x + 20
                , (int)_player.transform.position.x + 40); // 랜덤
            Debug.Log(ran);

            Vector2 dir = new Vector2(ran, -4.3f);
            curObs.Add(Instantiate(obsstacleList[Random.Range(0, obsstacleList.Count)], dir, Quaternion.identity));
        }
    }
}
