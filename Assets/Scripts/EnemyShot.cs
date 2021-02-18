using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public Transform playerPos;
    public float speed;
    public float distanciaFrenado;
    public float distanciaRetraso;
    public float distanciaDeteccion;

    Animator anim;
    public Transform punto_disparo;
    public GameObject bala;
    public GameObject balaLeft;
    private float tiempo;
    GameObject bulletEnemy;
    
    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 150f)]
    float rayDistance = 50f;
    [SerializeField]
    LayerMask playerLayer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        bulletEnemy = GameObject.Find("FirePointEnemy");
    }

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(Physics2D.Raycast(transform.position, Vector2.right, rayDistance, playerLayer) || Physics2D.Raycast(transform.position, Vector2.left, rayDistance, playerLayer))
        {
            anim.SetBool("seen", true);
            if(Vector2.Distance(transform.position, playerPos.position) > distanciaFrenado)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed*Time.deltaTime);    
            }

            if(Vector2.Distance(transform.position, playerPos.position) < distanciaRetraso)
            {
                transform.position = Vector2.MoveTowards(transform.position, playerPos.position, -speed*Time.deltaTime);    
            }

            if(Vector2.Distance(transform.position, playerPos.position) < distanciaFrenado && Vector2.Distance(transform.position, playerPos.position) > distanciaRetraso)
            {
                transform.position = transform.position;
            }

            if(playerPos.position.x>this.transform.position.x)
            {
                this.transform.localScale = new Vector2(1,1);
                bulletEnemy.transform.eulerAngles = new Vector3(0f,0f,0f);
            }
            else
            {
                this.transform.localScale = new Vector2(-1,1);
                bulletEnemy.transform.eulerAngles = new Vector3(0f,180f,0f);
            }

            tiempo += Time.deltaTime;
            if(tiempo >= .85)
            {
                if(playerPos.position.x>this.transform.position.x)
                {
                    Instantiate(bala, punto_disparo.position, Quaternion.identity);
                    tiempo = 0;
                }
                else
                {
                    Instantiate(balaLeft, punto_disparo.position, Quaternion.identity);
                    tiempo = 0;
                }
            }
        }
        else {anim.SetBool("seen", false);}
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.right * rayDistance);
        Gizmos.DrawRay(transform.position, Vector2.left * rayDistance);
    }
}
