using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class snake : MonoBehaviour
{
    Vector2 dir = Vector2.right;
    List<Transform> tail = new List<Transform>();
    bool ate = false;
    public GameObject tailprefab;
    public Slider snakespeed;
    public Text score;
    public Text snakespeedtext;
    private AudioSource eat;
    public static int s;
    public int lost = 0;
    public float z = 0.3f; 

    void Start()
    {
        dir = Vector2.right;
        eat = GetComponent<AudioSource>();
        InvokeRepeating("move", 1f, z);
        snakespeed.onValueChanged.AddListener((z) =>
        {
           CancelInvoke();
            z = 0.32f - z;
            InvokeRepeating("move", z, z);
        });
        s = 0;
        SetScore();

    }
    public void Adjustsnakespeed(float s)
    {
        z = s;
        int m = (int)(z * 100);
        snakespeedtext.text = m.ToString();
    }
    

    void Update()
    {
            if (Input.GetKey(KeyCode.RightArrow))
                dir = Vector2.right;
            else if (Input.GetKey(KeyCode.DownArrow))
                dir = -Vector2.up;
            else if (Input.GetKey(KeyCode.LeftArrow))
                dir = -Vector2.right;
            else if (Input.GetKey(KeyCode.UpArrow))
                dir = Vector2.up;
 
        
    }

    void move()
    {
        if(lost==1)
        {
            return;
        }
        Vector2 v = transform.position;
        transform.Translate(dir);
        if(ate)
        {
            s = s + 5;
            SetScore();
            GameObject g = (GameObject)Instantiate(tailprefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
            

        }

        else if(tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.name.StartsWith("foodprefab"))
        {
            ate = true;
            eat.Play();
            Destroy(coll.gameObject);
        }
        else
        {
            lost = 1;
            SceneManager.LoadSceneAsync("restartsnakegame");
        }
    }

    void SetScore()
    {
        score.text = "Score: " + s;
    }

}
