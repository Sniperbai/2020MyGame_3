﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{//属性值
    public float moveSpeed = 3;
    private Vector3 bulletEulerAngles;
    private float v;
    private float h;


    //引用
    private SpriteRenderer sr;
    public Sprite[] tankSprite;  //上 右 下 左
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;

    //计时器
    private float timeVal;
    private float timeValChangeDirection = 4;

    //初始化
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        //攻击的时间间隔
        if (timeVal >= 3)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    //坦克的攻击方法
    private void Attack()
    {
        //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度
        Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bulletEulerAngles));
        timeVal = 3;
    }


    //坦克的移动方法
    private void Move()
    {
        if (timeValChangeDirection >= 4)
        {
            int num = Random.Range(0, 8);
            if (num > 5)
            {
                v = -1;
                h = 0;
            }
            else if (num == 0)
            {
                v = -1;
                h = 0;
            }
            else if (num > 0 && num <= 2)
            {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 4)
            {
                h = 1;
                v = 0;
            }

            timeValChangeDirection = 0;
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;
        }

        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bulletEulerAngles = new Vector3(0, 0, -180);
        }
        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
            return;
        }

        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        //注：Time.deltaTime（按每秒移动 不加是按没帧移动） Space.World（按世界坐标轴移动）

        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }
        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        }
    }


    //坦克的死亡方法
    private void Die()
    {
        

        //播放爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);

        //死亡
        Destroy(gameObject);
    }
}
