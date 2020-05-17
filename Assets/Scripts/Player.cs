using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //属性值
    public float moveSpeed = 3;

    //引用
    private SpriteRenderer sr;
    public Sprite[] tankSprite;  //上 右 下 左

    //初始化
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        Move();

        
    }

    //坦克的移动方法
    private void Move()
    {
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.up * v * moveSpeed * Time.deltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprite[2];
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
        }

        if (v != 0)
        {
            return;
        }

        float h = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * h * moveSpeed * Time.deltaTime, Space.World);
        //注：Time.deltaTime（按每秒移动 不加是按没帧移动） Space.World（按世界坐标轴移动）

        if (h < 0)
        {
            sr.sprite = tankSprite[3];
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
        }
    }
}
