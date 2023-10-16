using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Threading.Tasks;
using BackEnd;
using TMPro;
using UnityEngine.SceneManagement;

public class BackendManager : MonoBehaviour
{
    private static BackendManager _instance = null;

    public string userName = "";
    [SerializeField] private TMP_InputField inputField;
        
    [SerializeField] private GameObject nickInputPanel;
    [SerializeField] private TextMeshProUGUI _1st;
    [SerializeField] private TextMeshProUGUI _1stScore;
    [SerializeField] private TextMeshProUGUI _2st;
    [SerializeField] private TextMeshProUGUI _2stSocre;
    [SerializeField] private TextMeshProUGUI _3st;
    [SerializeField] private TextMeshProUGUI _3stScore;
    [SerializeField] private TextMeshProUGUI _myRanking;
    [SerializeField] private TextMeshProUGUI _myRankingSocre;
    
    int num;

    public static BackendManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new BackendManager();
            }

            return _instance;
        }
    }

    private void Awake()
    {
        userName = inputField.GetComponent<TMP_InputField>().text;
    }

    void Start()
    {
        inputField.onSubmit.AddListener((inputField) => {NickName();});

        var bro = Backend.Initialize(true); // ??? ????

        // ??? ?????? ???? ????
        if (bro.IsSuccess())
        {
            Debug.Log("???? ???? : " + bro); // ?????? ??? statusCode 204 Success
        }
        else
        {
            Debug.LogError("???? ???? : " + bro); // ?????? ??? statusCode 400?? ???? ???
        }

        StartCoroutine(SignUpAndLoginCoroutine());
    }



    private IEnumerator SignUpAndLoginCoroutine()
    {
        num = Random.Range(0, 9999);

        //userName = userInputName.text;  

        #region 로그인 회원가입
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

        //BackendGameData.Instance.GameDataUpdate();
        #endregion

        GetRanking();

        yield return new WaitForSeconds(2f);

        Debug.Log("?????? ????????.");
    }

    public void RankingInsert()
    {
        BackendRank.Instance.RankInsert((float)GameManager.instance.score);   
    }

    public void GetRanking()
    {
        BackendRank.Instance.RankGet(_1st, _2st, _3st, _1stScore, _2stSocre, _3stScore, _myRanking, _myRankingSocre);
    }

    public void NickName()
    {
        userName = inputField.text;

        if (userName != "")
        {
            BackendLogin.Instance.UpdateNickname(userName);
        }

        Debug.Log(userName);
        SceneManager.LoadScene("Menu");
        nickInputPanel.SetActive(false);
    }
}