using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D Rig;
    private Animator Anim;

    public float Speed;

    public Transform RightCol;
    public Transform LeftCol;
    public Transform HeadPoint;

    private bool Colliding;

    public LayerMask Layer;

    public BoxCollider2D _boxCollider2D;
    public CircleCollider2D _circleCollider2D;

    bool _playerDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Rig.velocity = new Vector2(Speed, Rig.velocity.y);

        Colliding = Physics2D.Linecast(RightCol.position, LeftCol.position, Layer);
        if (Colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            Speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var height = collision.contacts[0].point.y - HeadPoint.position.y; // 
            if (height > 0 && !_playerDestroyed)
            {
                // JUmpo force
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                Anim.SetTrigger("die");

                Speed = 0;

                _boxCollider2D.enabled = false;
                _circleCollider2D.enabled = false;
                Rig.bodyType = RigidbodyType2D.Kinematic;

                Destroy(gameObject, 0.33f);
            }
            else
            {
                _playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(collision.gameObject);
            }

        }
    }
}
