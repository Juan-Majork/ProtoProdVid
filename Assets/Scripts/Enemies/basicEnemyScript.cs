using UnityEditor;
using UnityEngine;

public class basicEnemyScript : MonoBehaviour
{
    //Stats
    [SerializeField] private int health;
    [SerializeField] private float speed;
    private Vector2 movement;

    //Parametros Knockback 
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KBRight;
    public bool hit=false;
    private float KBcoolDown = 0; 
    private float KBReset = 1f;

    //Tipo de enemigo
    [SerializeField] public int type;
    
    private GameObject player;
    private Transform playerTransform;

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
        player = GameObject.FindWithTag("player");
        playerTransform = player.GetComponent<Transform>();
    }


    private void Update()
    {
        if (!hit)
        {
            KBcoolDown = 0;
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            movement = new Vector2(direction.x, 0);

            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
        if (hit)
        {
            KBcoolDown += Time.deltaTime;
            if(KBcoolDown > KBReset)
            {
                hit = false;
            }
        }
        
        
    }

    private void FixedUpdate()
    {
        
        
        Health();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("staff") && staffM.active == false ) //Si colision y baston sin cooldown 
        {
            KBCounter = 0; //Arranca el contador de knockback desde 0 
            hit = true;

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
