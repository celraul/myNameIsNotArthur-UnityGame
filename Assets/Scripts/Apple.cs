﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameObject collected;
    public int Score;

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.instance.TotalScore++;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
