using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    Animator anim;
    

    
    void Start()
    {
        anim = GetComponent<Animator>();
        Invoke("Die",
            Mathf.CeilToInt(
                anim.GetCurrentAnimatorStateInfo(0).length
                )
            );
            
    }

    void Die()
    {
        Destroy(gameObject);
    }
    
}
