using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] sbyte vida;
    [SerializeField] float velocidade;

    Rigidbody2D rb2d;
    Vector3 zAnguloEuler;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        zAnguloEuler = Vector3.zero;
    }

    
    void FixedUpdate()
    {
        zAnguloEuler.z = Mathf.Atan2(
            GameController.instancia.GetPlayerPosition().y - transform.position.y,
            GameController.instancia.GetPlayerPosition().x - transform.position.x
            ) * Mathf.Rad2Deg - 90;

        transform.eulerAngles = zAnguloEuler;
        rb2d.AddForce(gameObject.transform.up * velocidade);
    }

    public void TomaDano(sbyte dano)
    {
        vida -= dano;
        if (vida <= 0) Destroy(gameObject);
    }
}
