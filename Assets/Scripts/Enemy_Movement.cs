using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    private bool isChasing;
    private int facingDirection = -1;

    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;   // <-- aggiunto

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();   // <-- aggiunto
    }

    void Update()
    {
        if (isChasing && player != null)
        {
            if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
            {
                Flip();
            }

            Vector2 direction = (player.position - transform.position).normalized;
            rb.velocity = direction * speed;

            // stessa logica del player: passo i valori assoluti all'Animator
            anim.SetFloat("horizontal", Mathf.Abs(direction.x));
            anim.SetFloat("vertical", Mathf.Abs(direction.y));
        }
        else
        {
            // fermo: azzero velocità e animazione (torna in idle)
            rb.velocity = Vector2.zero;
            anim.SetFloat("horizontal", 0);
            anim.SetFloat("vertical", 0);
        }
    }

    void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player == null)
            {
                player = collision.transform;
            }
            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
}