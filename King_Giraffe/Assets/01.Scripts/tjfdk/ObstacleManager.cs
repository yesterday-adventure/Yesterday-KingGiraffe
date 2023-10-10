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
    [SerializeField] List<GameObject> obsPosList;

    private void Awake() {
        
        if (instance == null) instance = this;
        else Destroy(this);
    }

    public void ObsCount() {
        
        if (BackGround.instance.turnCount % 5 == 0)
            curObsCount++;
    }

    public void SpawnObs() {

        for (int i = 0; i < curObsCount; ++i) {

            Instantiate(obstacle, obsPosList[Random.Range(0, obsPosList.Count)].transform.position, Quaternion.identity);
        }
    }
}
