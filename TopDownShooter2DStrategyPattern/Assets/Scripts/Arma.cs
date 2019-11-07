using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] protected sbyte damage;

    public sbyte getDamage() { return damage; }
}
