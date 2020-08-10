using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float Speed;
    public float MoveTime;

    private bool DirRight = true;
    private float Timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (DirRight)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime);
        }

        Timer += Time.deltaTime;

        if (Timer >= MoveTime)
        {
            DirRight = !DirRight;
            Timer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player tocou na cerra");
            GameController.instance.ShowGameOver();

            Destroy(collision.gameObject);
        }
    }
}
