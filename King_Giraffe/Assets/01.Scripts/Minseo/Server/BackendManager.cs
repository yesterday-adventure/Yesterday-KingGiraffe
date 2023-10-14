using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using BackEnd;
using TMPro;

public class BackendManager : MonoBehaviour
{
    [SerializeField] private string userName = "";
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
        var bro = Backend.Initialize(true); // 뒤끝 초기화

        // 뒤끝 초기화에 대한 응답값
        if (bro.IsSuccess())
        {
            Debug.Log("초기화 성공 : " + bro); // 성공일 경우 statusCode 204 Success
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro); // 실패일 경우 statusCode 400대 에러 발생
        }

        StartCoroutine(SignUpAndLoginCoroutine());
    }

    private IEnumerator SignUpAndLoginCoroutine()
    {
        num = Random.Range(0, 9999);

        //userName = userInputName.text;  

        #region 회원가입 로그인
        BackendLogin.Instance.CustomSignUp("user" + num.ToString(), "1234");
        BackendLogin.Instance.CustomLogin("user" + num.ToString(), "1234");
        #endregion

        #region 데이터
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

        Debug.Log("테스트를 종료합니다.");
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