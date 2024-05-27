using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class kapı : MonoBehaviour
{
    public float targetXPosition = 1.416f;
    public float moveDuration = 2f;

    void Start()
    {
        StartCoroutine(MoveToTargetPosition());
    }

    IEnumerator MoveToTargetPosition()
    {
        float time = 0;
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = new Vector3(targetXPosition, startPosition.y, startPosition.z);

        while (time < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / moveDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
    }
}