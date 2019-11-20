using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    [SerializeField] float jumpVelocity;
    [SerializeField] float maxHeight;
    [SerializeField] GameObject sprite;
    [SerializeField] FlashImage flashImage;
  
    Rigidbody2D rb;
    bool isDead;        //피쉬의 죽음을 만들 불타입 변수
    public bool IsDead      //프라퍼티로 읽을 수 있도록 만듬
    {
        get { return isDead; }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //위로 점프하게 한다.
        if (Input.GetButtonDown("Fire1") && transform.position.y < maxHeight)
        {
            //죽지 않았으면 계속한다.
            if (!isDead && rb.isKinematic == false)
                GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, jumpVelocity);
        }

        //회전값을 줘서 스크립트가 회전한다.
        float angle;
        //죽었으면 180만큼 회전
        if (isDead)
        {
            angle = Mathf.Lerp(sprite.transform.localPosition.z, 180f, Time.time / 3);
        }
        else
        {
            angle = Mathf.Atan2(rb.velocity.y, 8) * Mathf.Rad2Deg;
        }

        sprite.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, angle);
    }

    //콜라이더에 피쉬가 닿았다면 호출될 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Camera.main.SendMessage("Shake");

        flashImage.StartFlash();

        isDead = true;
    }

    public void SetKinematic(bool value)
    {
        rb.isKinematic = value;
    }
}
