using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    Task task;

    public Task Task { get => task; }

    void Awake()
    {
        instance = this;
    }
}
