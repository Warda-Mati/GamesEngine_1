﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShootingStar : MonoBehaviour
{
    public int speed;

    public int lifeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed *Time.deltaTime);
        Destroy(this.gameObject,lifeTime);
    }
}
