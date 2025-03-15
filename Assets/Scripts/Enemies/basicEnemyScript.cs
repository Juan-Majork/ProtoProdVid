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
    private float KBcoolDown = 0;
    private float KBReset = 1f;

    //Tipo de enemigo
    [SerializeField] public int type;

    [SerializeField] private int killScore;

    private int iceCounter = 0;
    private float frozen = 0;

    private int fireCounter = 0;
    
    private GameObject player;
    private Transform playerTransform;

    private AttackSystem atck;

    private StaffMovement staffM;

    private DropScript dropScript;

    private damageControl damageControl;

    public Rigidbody2D rb;

    private ScoreController scoreController;

    private void Awake()
    {
        atck = GameObject.FindAnyObjectByType<AttackSystem>();
        staffM = GameObject.FindAnyObjectByType<StaffMovement>();
        rb = GetComponent<Rigidbody2D>();
        dropScript = GetComponent<DropScript>();
        player = GameObject.FindWithTag("player");
        playerTransform = player.GetComponent<Transform>();
        scoreController = FindFirstObjectByType<ScoreController>();
    }


    private void Update()
    {
        //Ajustes de Knockback
        if (!staffM.hitConfirmer) //El enemigo camina hacia el jugador cuando no esta stuneado
        {
            KBcoolDown = 0;
            Vector2 direction = (playerTransform.position - transform.position).normalized;

            movement = new Vector2(direction.x, 0);

            rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
        }
        if (staffM.hitConfirmer) //Si recibe un ataque del baston, recibe knockback
        {
            KBcoolDown += Time.deltaTime;
            if(KBcoolDown > KBReset)
            {
                staffM.hitConfirmer = false;
            }
        }
        
        
    }

    private void FixedUpdate()
    {   
        Health();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Daño del baston
        if (collision.gameObject.CompareTag("staff") && staffM.active == false ) //Si colision y baston sin cooldown 
        {
            KBCounter = 0; //Arranca el contador de knockback desde 0 
            staffM.hitConfirmer = true;

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

        //Daño magia de 1 colision
        if (collision.gameObject.CompareTag("rockMagic")) //colision con hechizo
        {
            damageControl = GameObject.Find("rockMagic(Clone)").GetComponent<damageControl>();
            health -= damageControl.dmg;
        }

        if (collision.gameObject.CompareTag("waterMagic"))
        {
            damageControl = GameObject.Find("waterMagic").GetComponent<damageControl>();
            health -= damageControl.dmg;
            iceCounter++;
            if (iceCounter > 2)
            {
                speed -= speed;
                if (frozen < 2)
                {
                    frozen += Time.deltaTime;
                }
                else
                {
                    speed += speed;
                    frozen = 0;
                    iceCounter = 0;
                    Debug.Log("Frozen Ended");
                }
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //Daño magia sostenida en el tiempo
        if (collision.gameObject.CompareTag("fireMagic"))
        {
            damageControl = GameObject.Find("fireMagic").GetComponent<damageControl>();
            damageControl.dmgCounter += Time.deltaTime;
            if (damageControl.dmgCounter > 1) //Cada 1 segundo, hace daño
            {
                health -= damageControl.dmg;
                damageControl.dmgCounter = 0;
            }
        }
    }


    private void Health()
    {
        if (health <= 0)
        {
            scoreController.AddScore(killScore);

            dropScript.Dropeo();
            Destroy(gameObject);
        }
    }

}
