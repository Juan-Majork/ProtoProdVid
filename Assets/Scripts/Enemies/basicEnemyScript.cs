using UnityEngine;

public class basicEnemyScript : MonoBehaviour
{

    [SerializeField] private int health;

    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KBRight;

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

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("staff") && !staffM.active)
        {
            KBCounter = 0;

            if (gameObject.transform.position.x > collision.transform.position.x) KBRight = true;
            else KBRight = false;

            if (KBRight == true && KBCounter < KBTotalTime)
            {
                health -= atck.attack;
                KBCounter += Time.deltaTime;
                rb.linearVelocity = new Vector2 (KBForce, KBForce);
                Debug.Log("health left: " +  health);
                if (health < 0)
                {
                    Destroy(gameObject);
                    dropScript.Dropeo(type);
                }
            }
            if (KBRight == false && KBCounter < KBTotalTime)
            {
                health -= atck.attack;
                rb.linearVelocity = new Vector2(-KBForce, KBForce);
                KBCounter += Time.deltaTime;
                Debug.Log("health left: " + health);
                if (health < 0)
                {
                    Destroy(gameObject);
                    dropScript.Dropeo(type);
                }
            }
            
        }
    }


}
