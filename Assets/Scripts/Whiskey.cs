using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiskey : MonoBehaviour
{
    [SerializeField, Range(1,2)]
    int points;

    public int Points { get => points; }
}
