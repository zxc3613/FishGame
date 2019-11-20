using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float minPosistionY;
    [SerializeField] float maxPosistionY;

    private void Start()
    {
        ChangePosition();
    }
    //랜덤값으로 Y이동
    public void ChangePosition()
    {
        float positionY = Random.Range(minPosistionY, maxPosistionY);
        transform.localPosition = new Vector3(transform.localPosition.x, positionY, transform.localPosition.z);
    }
}
