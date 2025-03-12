using UnityEngine;

public class basicEnemyScript : MonoBehaviour
{

    [SerializeField] private int health;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KBRight;
    public bool hit = false;

    [SerializeField] public int type;

    private AttackSystem atck;

    private StaffMovement staffM;

    private DropScript dropScript;

    public Rigidbody2D rb;

    private void Awake()
    {
        atck = Object.FindAnyObjectByType<AttackSystem>();
        staffM = Object.FindAnyObjectByType<StaffMovement>();
        rb = GetComponent<Rigidbody2D>();
        dropScript = GetComponent<DropScript>();
    }

    private void FixedUpdate()
    {
        Health();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("staff") && staffM.active == false /*&& hit == false*/) //Si colision, baston y hitbox suceden
        {
            KBCounter = 0; //Arranca el contador de knockback desde 0 
            //hit = true; //Se confirma el hit y se evita un multihit

            if (gameObject.transform.position.x > collision.transform.position.x) KBRight = true; //Si golpea por derecha
            else KBRight = false; //Si golpea por derecha

            if (KBRight == true && KBCounter < KBTotalTime) //Si golpea por derecha y el contador es menor al tiempo total del knockback
            {
                health -= atck.attack; //Se resta vida
                KBCounter += Time.deltaTime; //El contador suma
                rb.linearVelocity = new Vector2 (KBForce, KBForce); //Se ejecuta el knockback
                
                Debug.Log("health left: " +  health); //notificacion por consola
            }
            if (KBRight == false && KBCounter < KBTotalTime) //Si golpea por izquierda y el contador es menor al tiempo total del knockback
            {
                health -= atck.attack; //Se resta vida
                rb.linearVelocity = new Vector2(-KBForce, KBForce); //El contador suma
                KBCounter += Time.deltaTime; //Se ejecuta el knockback

                Debug.Log("health left: " + health); //notificacion por consola
            }
            
        }
    }

    private void Health()
    {
        if (health < 0)
        {
            dropScript.Dropeo();
            Destroy(gameObject);
        }
    }

}
