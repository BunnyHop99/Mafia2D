using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodDestroy : MonoBehaviour
{
    [SerializeField, Range(0.01f, 3f)]
    float deathTime = 0.1f;
    void Start()
    {
        destroyBlood();
    }

    void destroyBlood ()
    {
        StartCoroutine(BloodCoroutine());
    }

    IEnumerator BloodCoroutine()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy (gameObject);
    }
}
