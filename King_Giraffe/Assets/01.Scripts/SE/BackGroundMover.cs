using UnityEngine;
using UnityEngine.Events;

public class BackGroundMover : MonoBehaviour
{
    public UnityEvent<float> move;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject obsPos;
    private float nowplayerX;
    private float moveX;

    private void Start()
    {
        nowplayerX = player.position.x;
    }

    private void FixedUpdate()
    {
        if (nowplayerX < player.position.x)        // �÷��̾�� �� ũ��
        {
            moveX = 19.2f;
        }
        else if (nowplayerX > player.position.x)
        {
            moveX = -19.2f;
        }
        nowplayerX = player.position.x;
        
    }

    private void OnTriggerExit2D(Collider2D collision)          // ��������
    {
        if (!collision.CompareTag("Player"))        // �÷��̾� �ƴϸ� ����
            return;

        transform.position = new Vector3(transform.position.x + (moveX * 2), transform.position.y, 0);
        if (obsPos != null)
            obsPos.transform.position = new Vector3(transform.position.x, transform.position.y, 0);

        if (moveX > 0) // 뒤로 후진한 게 아니라면...
        {
            BackGround.instance.turnCount++; // 화면 넘어간 수 체크
            ObstacleManager.instance.ObsCount(); // 장애물 생성
            PointManager.Instance.SpawnPoint();
        }

        move?.Invoke(moveX);
    }
}
