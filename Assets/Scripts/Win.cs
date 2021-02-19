using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject GameWinText;
    public static GameObject GameWinStatic;
    

    void Start()
    {
        Win.GameWinStatic = GameWinText;
        Win.GameWinStatic.gameObject.SetActive (false);
    }

    public static void show()
    {
        Win.GameWinStatic.gameObject.SetActive (true);
    }
}
