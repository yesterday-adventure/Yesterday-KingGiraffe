using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using BackEnd;
using TMPro;

public class BackendManager : MonoBehaviour
{
    [SerializeField] public string userName = "";
    [SerializeField] private TMP_InputField inputField;

    [SerializeField] private TextMeshProUGUI _1st;
    [SerializeField] private TextMeshProUGUI _1stScore;
    [SerializeField] private TextMeshProUGUI _2st;
    [SerializeField] private TextMeshProUGUI _2stSocre;
    [SerializeField] private TextMeshProUGUI _3st;
    [SerializeField] private TextMeshProUGUI _3stScore;
    [SerializeField] private TextMeshProUGUI _myRanking;
    [SerializeField] private TextMeshProUGUI _myRankingSocre;
    
    int num;

    private void Awake()
    {
        userName = inputField.GetComponent<TMP_InputField>().text;
    }

    void Start()
    {
        var bro = Backend.Initialize(true); // �ڳ� �ʱ�ȭ

        // �ڳ� �ʱ�ȭ�� ���� ���䰪
        if (bro.IsSuccess())
        {
            Debug.Log("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 204 Success
        }
        else
        {
            Debug.LogError("�ʱ�ȭ ���� : " + bro); // ������ ��� statusCode 400�� ���� �߻�
        }

        StartCoroutine(SignUpAndLoginCoroutine());
    }

    private IEnumerator SignUpAndLoginCoroutine()
    {
        num = Random.Range(0, 9999);

        //userName = userInputName.text;  

        #region ȸ������ �α���
        BackendLogin.Instance.CustomSignUp("user" + num.ToString(), "1234");
        BackendLogin.Instance.CustomLogin("user" + num.ToString(), "1234");
        #endregion

        #region ������
        BackendGameData.Instance.GameDataGet();

        if (BackendGameData.userData == null)
        {
            BackendGameData.Instance.GameDataInsert();
        }

        BackendGameData.Instance.SocreUp();

        BackendGameData.Instance.GameDataUpdate();
        #endregion

        BackendRank.Instance.RankInsert((float)1.4);
        //BackendRank.Instance.RankInsert((float)GameManager.instance.score);

        BackendRank.Instance.RankGet(_1st, _2st, _3st, _1stScore, _2stSocre, _3stScore, _myRanking, _myRankingSocre);
        //BackendRank.Instance.RankGet();

        yield return new WaitForSeconds(2f);

        Debug.Log("�׽�Ʈ�� �����մϴ�.");
    }

    public void NickName()
    {
        userName = inputField.text;

        if (userName != "")
        {
            BackendLogin.Instance.UpdateNickname(userName);
        }
    }
}