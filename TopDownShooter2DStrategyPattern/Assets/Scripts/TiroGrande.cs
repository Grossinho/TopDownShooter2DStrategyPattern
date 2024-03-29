﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroGrande : Arma, IArma
{

    private float speed;
    private Transform firePoint;

    void Start()
    {
        firePoint = GetComponentInChildren<Transform>().GetChild(0);
        speed = 5;
    }

    public void Atirar()
    {
        GameObject bullet = Instantiate(Resources.Load("BulletGrande", typeof(GameObject)))
            as GameObject;
        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;
        bullet.GetComponent<Rigidbody2D>().velocity = transform.up * speed;

    }
}
