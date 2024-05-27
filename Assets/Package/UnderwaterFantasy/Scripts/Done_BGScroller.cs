using UnityEngine;
using System.Collections;

public class Done_BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileWidth;

    private Vector3 startPosition;
    private bool isScrolling = true; // Kayma kontrolü için boolean

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (isScrolling)
        {
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileWidth);
            transform.position = startPosition + Vector3.left * newPosition;
        }
    }

    public void SetScrolling(bool scrolling)
    {
        isScrolling = scrolling;
    }
}
