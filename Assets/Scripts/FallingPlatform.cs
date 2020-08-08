using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float FallingTime;
    
    private TargetJoint2D Target;
    private BoxCollider2D BoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        Target = GetComponent<TargetJoint2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Invoke("Falling", FallingTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
            Destroy(gameObject);
    }

    void Falling()
    {
        Target.enabled = false;
        BoxCollider.isTrigger = true;
    }
}
