using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] float startPosition;
    [SerializeField] float endPosition;
    [SerializeField] int index;

    void Update()
    {
        if (index == 1)         //왼쪽으로 이동
        {
            transform.Translate(-1 * (speed * Time.deltaTime), 0, 0);
            if (transform.position.x <= endPosition)
            {
                transform.Translate(-1 * (endPosition - startPosition), 0, 0);

                //파이프의 함수 호출
                SendMessage("ChangePosition", SendMessageOptions.DontRequireReceiver);
            }
        }
        if (index == 2)         //위로 이동
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            if (transform.position.y >= endPosition)
            {
                transform.Translate(0, -1 * (endPosition - startPosition), 0);
            }
        }
    }
}
