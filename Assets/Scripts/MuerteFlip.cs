using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuerteFlip : MonoBehaviour
{
    public Transform playerPos;

    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if(playerPos.position.x>this.transform.position.x)
        {
            this.transform.localScale = new Vector2(-1,1);
        }
        else
        {
            this.transform.localScale = new Vector2(1,1);
        }
    }
}
