
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using TMPro;

// �ڳ� SDK namespace �߰�
using BackEnd;

public class BackendRank
{
    private static BackendRank _instance = null;

    public int i_rank;

    [SerializeField] private TextMeshProUGUI _1st;
    [SerializeField] private TextMeshProUGUI _2st;
    [SerializeField] private TextMeshProUGUI _3st;
    [SerializeField] private TextMeshProUGUI _myRanking;

    public static BackendRank Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendRank();
            }

            return _instance;
        }
    }
    
     
    public void RankInsert(float score)
    {
        string rankUUID = "b2c6b260-6915-11ee-87dc-6333dd683f21";

        string tableName = "KingGireaffe";
        string rowInDate = string.Empty;

        // ��ŷ�� �����ϱ� ���ؼ��� ���� �����Ϳ��� ����ϴ� �������� inDate���� �ʿ��մϴ�.  
        // ���� �����͸� �ҷ��� ��, �ش� �������� inDate���� �����ϴ� �۾��� �ؾ��մϴ�.  
        Debug.Log("������ ��ȸ�� �õ��մϴ�.");
        var bro = Backend.GameData.GetMyData(tableName, new Where());

        if (bro.IsSuccess() == false)
        {
            Debug.LogError("������ ��ȸ �� ������ �߻��߽��ϴ� : " + bro);
            return;
        }

        Debug.Log("������ ��ȸ�� �����߽��ϴ� : " + bro);

        if (bro.FlattenRows().Count > 0)
        {
            rowInDate = bro.FlattenRows()[0]["inDate"].ToString();
        }
        else
        {
            Debug.Log("�����Ͱ� �������� �ʽ��ϴ�. ������ ������ �õ��մϴ�.");
            var bro2 = Backend.GameData.Insert(tableName);

            if (bro2.IsSuccess() == false)
            {
                Debug.LogError("������ ���� �� ������ �߻��߽��ϴ� : " + bro2);
                return;
            }

            Debug.Log("������ ���Կ� �����߽��ϴ� : " + bro2);

            rowInDate = bro2.GetInDate();
        }

        Debug.Log("�� ���� ������ rowInDate : " + rowInDate); // ����� rowIndate�� ���� ������ �����ϴ�.  

        Param param = new Param();
        param.Add("score", score);

        // ����� rowIndate�� ���� �����Ϳ� param������ ������ �����ϰ� ��ŷ�� �����͸� ������Ʈ�մϴ�.  
        Debug.Log("��ŷ ������ �õ��մϴ�.");
        var rankBro = Backend.URank.User.UpdateUserScore(rankUUID, tableName, rowInDate, param);

        if (rankBro.IsSuccess() == false)
        {
            Debug.LogError("��ŷ ��� �� ������ �߻��߽��ϴ�. : " + rankBro);
            return;
        }

        Debug.Log("��ŷ ���Կ� �����߽��ϴ�. : " + rankBro);
    }


    //public void RankGet()
    //{
    //    string rankUUID = "b2c6b260-6915-11ee-87dc-6333dd683f21";
    //    var bro = Backend.URank.User.GetRankList(rankUUID);

    //    if (bro.IsSuccess() == false)
    //    {
    //        Debug.LogError("��ŷ ��ȸ�� ������ �߻��߽��ϴ�. : " + bro);
    //        return;
    //    }
    //    Debug.Log("��ŷ ��ȸ�� �����߽��ϴ�. : " + bro);

    //    Debug.Log("�� ��ŷ ��� ���� �� : " + bro.GetFlattenJSON()["totalCount"].ToString());

    //    foreach (LitJson.JsonData jsonData in bro.FlattenRows())
    //    {
    //        StringBuilder info = new StringBuilder();

    //        info.AppendLine("���� : " + jsonData["rank"].ToString());
    //        info.AppendLine("�г��� : " + jsonData["nickname"].ToString());
    //        info.AppendLine("���� : " + jsonData["score"].ToString());
    //        info.AppendLine();
    //        Debug.Log(info);
    //    }

    //}

    public void RankGet(TextMeshProUGUI _1st, TextMeshProUGUI _2st, TextMeshProUGUI _3st, TextMeshProUGUI _1stS, TextMeshProUGUI _2stS, TextMeshProUGUI _3stS, TextMeshProUGUI _MyR, TextMeshProUGUI _MyRS)
    {

        string rankUUID = "b2c6b260-6915-11ee-87dc-6333dd683f21";
        var bro = Backend.URank.User.GetRankList(rankUUID);

        if (bro.IsSuccess() == false)
        {
            Debug.LogError("��ŷ ��ȸ�� ������ �߻��߽��ϴ�. : " + bro);
            return;
        }
        Debug.Log("��ŷ ��ȸ�� �����߽��ϴ�. : " + bro);

        if (bro.FlattenRows().Count >= 3)
        {
            for (int i = 0; i < 3; i++)
            {
                LitJson.JsonData jsonData = bro.FlattenRows()[i];

                StringBuilder info = new StringBuilder();
                StringBuilder info_s = new StringBuilder();

                StringBuilder info_my = new StringBuilder();
                StringBuilder info_mys = new StringBuilder();

                info_my.AppendLine($"{jsonData["rank"].ToString()}    #{jsonData["nickname"].ToString()}");
                info_mys.AppendLine($"{jsonData["score"].ToString()} ��");

                info.AppendLine($"{jsonData["rank"].ToString()}    #{jsonData["nickname"].ToString()}");
                info_s.AppendLine($"{jsonData["score"].ToString()} ��");

                i_rank = (int)jsonData["rank"];

                if (i == 0)
                {
                    _1st.text = info.ToString();
                    _1stS.text = info_s.ToString();
                }
                else if (i == 1)
                {
                    _2st.text = info.ToString();
                    _2stS.text = info_s.ToString();
                }
                else if (i == 2)
                {
                    _3st.text = info.ToString();
                    _3stS.text = info_s.ToString();
                }

                _MyR.text = info_my.ToString();
                _MyRS.text = info_mys.ToString();
            }
        }
        else
        {
            Debug.Log("Not enough ranking data to display.");
        }
    }
}