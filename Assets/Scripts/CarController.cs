using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameManager gameManager;
    public float gasConsumeInterval = 1f; // 가스를 소비하는 간격 (초)
    public int gasConsumeAmount = 10; // 한 번에 소비할 가스 양
    
    private float timer = 0f;
    
    private Vector2 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (targetPosition.x < 0 && clickPosition.x > 0)    // 1번째 줄에서 오른쪽 클릭
            {
                targetPosition = new Vector2(0, transform.position.y); // 2번째 줄로 이동
            }
            else if (targetPosition.x == 0 && clickPosition.x < 0)  // 2번째 줄에서 왼쪽 클릭
            {
                targetPosition = new Vector2(-2, transform.position.y); // 1번째 줄로 이동
            }
            else if (targetPosition.x == 0 && clickPosition.x > 0)  // 2번째 줄에서 오른쪽 클릭
            {
                targetPosition = new Vector2(2, transform.position.y); // 3번째 줄로 이동
            }
            else if (targetPosition.x > 0 && clickPosition.x < 0)   // 3번째 줄에서 왼쪽 클릭
            {
                targetPosition = new Vector2(0, transform.position.y); // 2번째 줄로 이동
            }

            // if (clickPosition.x > 0 && targetPosition.x < 0)
            // {
            //     targetPosition = new Vector2(clickPosition.x, transform.position.y);
            // }
            // else if (clickPosition.x < 0 && targetPosition.x > 0)
            // {
            //     targetPosition = new Vector2(clickPosition.x, transform.position.y);
            // }
            
            // targetPosition = new Vector2(clickPosition.x, transform.position.y);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        
        timer += Time.deltaTime;

        if (timer >= gasConsumeInterval)
        {
            gameManager.ConsumeGas(gasConsumeAmount); // 가스 소비
            timer = 0f; // 타이머 초기화
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gas"))
        {
            gameManager.AddGas(30);
            Destroy(other.gameObject);
        }
    }

    public void ResetCarPosition()
    {
        transform.position = new Vector2(0, -2);
    }
}