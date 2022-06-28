using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalscore : MonoBehaviour
{
    public Text fscore;
    void Start()
    {
        int f = snake.s;
        fscore.text = f.ToString();
    }

    
}
