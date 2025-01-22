using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * (scrollSpeed * Time.deltaTime));

        if (transform.position.y <= -10)
        {
            transform.position = new Vector3(0, 10, 1); // 무한 스크롤 효과
        }
    }
}