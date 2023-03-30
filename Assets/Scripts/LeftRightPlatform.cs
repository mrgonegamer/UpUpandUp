using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : MonoBehaviour
{
    public float speed = 1.0f; // Speed of the movement
    public float leftDistance = 3.0f; // Distance to move left
    public float rightDistance = 3.0f; // Distance to move right
    public float pauseTime = 1.0f; // Time to pause at the left and right positions

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(LeftAndRightCoroutine());
    }

    IEnumerator LeftAndRightCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, transform.position, transform.position + Vector3.left * leftDistance, speed));
            yield return new WaitForSeconds(pauseTime);
            yield return StartCoroutine(MoveObject(transform, transform.position, transform.position + Vector3.right * rightDistance, speed));
            yield return new WaitForSeconds(pauseTime);
        }
    }

    IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector3.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
