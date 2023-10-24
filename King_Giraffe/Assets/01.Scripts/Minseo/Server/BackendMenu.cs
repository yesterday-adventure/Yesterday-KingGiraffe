using BackEnd;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackendMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _1st;
    [SerializeField] private TextMeshProUGUI _1stScore;
    [SerializeField] private TextMeshProUGUI _2st;
    [SerializeField] private TextMeshProUGUI _2stSocre;
    [SerializeField] private TextMeshProUGUI _3st;
    [SerializeField] private TextMeshProUGUI _3stScore;
    [SerializeField] private TextMeshProUGUI _myRanking;
    [SerializeField] private TextMeshProUGUI _myRankingSocre;

    private void Start()
    {
        GetRanking();
        Debug.Log(BackendManager.Instance.userName);
    }

    public void GetRanking()
    {
        BackendRank.Instance.RankGet(_1st, _2st, _3st, _1stScore, _2stSocre, _3stScore, _myRanking, _myRankingSocre);
    }

    public void RankingInsert(float score)
    {
        BackendRank.Instance.RankInsert(score);
    }
}
