using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnfood : MonoBehaviour
{
    public GameObject foodprefab;
    public Slider foodspeed;
    public Transform bordertop;
    public Transform borderbottom;
    public Transform borderleft;
    public Transform borderright;
    public Text foodspeedtext;
    private float z = 1.2f;


    
    void Start()
    {
        InvokeRepeating("Spawn", z, z);
        foodspeed.onValueChanged.AddListener((z) =>
             {
                 CancelInvoke();
                 z = 4 - z;
                 InvokeRepeating("Spawn", z, z);
             });
            }
    
    public void Adjustfoodspeed(float s)
    {
        z = s;
        int m = (int)(z * 10);
        foodspeedtext.text = m.ToString();
    }
    void Spawn()
    {
        int x = (int)Random.Range(borderleft.position.x, borderright.position.x);
        int y = (int)Random.Range(borderbottom.position.y, bordertop.position.y);
        Instantiate(foodprefab, new Vector2(x, y), Quaternion.identity);
    }

    
}
