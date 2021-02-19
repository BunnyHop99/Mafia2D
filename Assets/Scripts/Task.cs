using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField]
    Text taskTxt;
    [SerializeField]

    int currentTask = 0;
    
    public void AddPoints(int Points)
    {
        currentTask += Points;
        taskTxt.text = $"Whiskey: {currentTask}/10";
        if(currentTask >= 10)
        {
            Win.show();
        }
    }
}
