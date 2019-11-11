using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] string nomearma;

    float movement;
    Rigidbody2D rb2d;
    Vector3 mousePosition;
    Quaternion rotation;
    IArma arma;

    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        configArma(nomearma);
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            arma.Atirar();
    }

    private void FixedUpdate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rotation = 
            Quaternion.LookRotation(transform.position - mousePosition, Vector3.forward);

        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        movement = Input.GetAxis("Vertical");
        rb2d.AddForce(gameObject.transform.up * movement * speed);
    }

    public void configArma(string tag)
    {
        switch (tag)
        {
            case "Pickup":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroSimples>();
                break;
            case "PickupGrande":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroGrande>();
                break;
            case "UFO":
                RemoveArma();
                this.arma = gameObject.AddComponent<TiroRayCast>();
                break;
            default:
                break;
        }
    }

    void RemoveArma()
    {
        // PARA EVITAR A CRIACAO DE MULTIPLOS COMPONENTES DO MESMO TIPO NO GAMEOBJECT
        Component c = gameObject.GetComponent<IArma>() as Component;
        if (c != null) Destroy(c);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy"))
            configArma(collision.tag);
    }
}
