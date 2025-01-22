using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float moveSpeed = 3f; // 이동 속도

    void Update()
    {
        transform.Translate(Vector2.down * (moveSpeed * Time.deltaTime));

        // 화면 밖으로 벗어나면 삭제
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }
}