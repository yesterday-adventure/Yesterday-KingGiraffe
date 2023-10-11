using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleManager : MonoBehaviour
{
    public static ObstacleManager instance;

    [SerializeField] int curObsCount = 0; // 현재 장애물 개수
    [SerializeField] int addObsCount = 0; // 추가될 장애물 개수
    [SerializeField] GameObject obstacle;

    class ObstaclePos {

        public GameObject pos;
        public bool use;
    }

    [SerializeField] List<ObstaclePos> obsPosList;

    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void ObsCount() {
        
        if (BackGround.instance.turnCount % 5 == 0)
            curObsCount++;
    }

    public void SpawnObs() {

        for (int i = 0; i < curObsCount; ++i) { // 장애물 생성

            int ran = Random.Range(0, obsPosList.Count); // 랜덤

            if (obsPosList[ran].use == true)        
                i--;

            Instantiate(obstacle, obsPosList[ran].pos.transform.position, Quaternion.identity);
            obsPosList[ran].use = true;
        }
    }
}
