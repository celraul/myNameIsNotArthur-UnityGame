using UnityEngine;

public class Trampuline : MonoBehaviour
{
    public float JumpForce;
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            Anim.SetTrigger("Jump");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
