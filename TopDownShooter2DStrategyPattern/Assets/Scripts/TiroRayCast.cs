using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroRayCast : Arma, IArma
{
    Transform firePoint;
    LineRenderer linha;

    
    void Start()
    {
        firePoint = GetComponentInChildren<Transform>().GetChild(0);
        linha = GetComponentInChildren<LineRenderer>();
        damage = 3;
    }

    public void Atirar()
    {
        StartCoroutine(TiroRaio());
        
    }

    IEnumerator TiroRaio()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);

        if (hitInfo)
        {
            if (hitInfo.transform.gameObject.CompareTag("Enemy"))
            {
                hitInfo.transform.gameObject.GetComponent<EnemyController>().TomaDano(damage);

                GameObject explosion = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
                explosion.transform.position = hitInfo.point;
                explosion.transform.rotation = hitInfo.transform.rotation;

                linha.SetPosition(0, firePoint.position);
                linha.SetPosition(1, hitInfo.point);
            }
        }
        else
        {
            linha.SetPosition(0, firePoint.position);
            linha.SetPosition(1, firePoint.position + firePoint.up * 100);
        }
        linha.enabled = true;
        yield return new WaitForSeconds(0.02f);
        linha.enabled = false;
    
    }
}
