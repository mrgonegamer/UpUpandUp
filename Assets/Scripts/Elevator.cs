using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float speed = 1.0f; // Speed of the movement
    public float upDistance = 3.0f; // Distance to move up
    public float downDistance = 3.0f; // Distance to move down
    public float pauseTime = 1.0f; // Time to pause at the top and bottom positions

    private Vector3 startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(UpAndDownCoroutine());
    }

    IEnumerator UpAndDownCoroutine()
    {
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, transform.position, transform.position + Vector3.up * upDistance, speed));
            yield return new WaitForSeconds(pauseTime);
            yield return StartCoroutine(MoveObject(transform, transform.position, transform.position + Vector3.down * downDistance, speed));
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
