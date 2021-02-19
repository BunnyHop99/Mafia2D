using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyshoot2 : MonoBehaviour
{
    public Transform playerPos;

    Animator anim;
    public Transform punto_disparo;
    public GameObject bala;
    public GameObject balaLeft;
    private float tiempo;
    GameObject bulletEnemy2;

    [SerializeField, Range(0f, 1f)]
    private float dontStop;
    
    [SerializeField]
    Color rayColor = Color.magenta;
    [SerializeField, Range(0.1f, 150f)]
    float rayDistance = 25f;
    [SerializeField]
    LayerMask playerLayer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        bulletEnemy2 = GameObject.Find("FirePointEnemy2");
    }

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(Physics2D.Raycast(transform.position, Vector2.right, rayDistance, playerLayer) || Physics2D.Raycast(transform.position, Vector2.left, rayDistance, playerLayer))
        {
            dontStop = 1;
        }
        if(dontStop >= 1)
        {
            anim.SetBool("seen", true);
            
            if(playerPos.position.x>this.transform.position.x)
            {
                this.transform.localScale = new Vector2(1,1);
                bulletEnemy2.transform.eulerAngles = new Vector3(0f,0f,0f);
            }
            else
            {
                this.transform.localScale = new Vector2(-1,1);
                bulletEnemy2.transform.eulerAngles = new Vector3(0f,180f,0f);
            }

            tiempo += Time.deltaTime;
            if(tiempo >= 1.5)
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
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = rayColor;
        Gizmos.DrawRay(transform.position, Vector2.right * rayDistance);
        Gizmos.DrawRay(transform.position, Vector2.left * rayDistance);
    }
}
