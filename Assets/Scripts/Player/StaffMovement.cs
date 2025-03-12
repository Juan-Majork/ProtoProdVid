using UnityEngine;

public class StaffMovement : MonoBehaviour
{

    private int velX = 1;
    public bool active = true;
    private float movementTime = 0;
    private float coolDown = 0.2f;

    private basicEnemyScript basicEnemyScript;

    private magicsScript magicsScript;

    private CircleCollider2D circleCollider;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        basicEnemyScript = Object.FindAnyObjectByType<basicEnemyScript>();
        magicsScript = Object.FindAnyObjectByType<magicsScript>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheStaff(); //Ataque de baston
    }

    public void MoveTheStaff()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Activacion del baston
        {
            if (magicsScript.rockAtk)
            {
                magicsScript.magicAttacks();
            }
            else
            {
                if (active)
                {
                    transform.Translate(velX * 0.5f, 0, 0);
                    spriteRenderer.enabled = true;
                    circleCollider.enabled = true;
                    active = false;
                    Debug.Log("enter");

                }
            }
            
        }

        if (!active) //Reseteo del baston (Cooldown)
        {
            movementTime += Time.deltaTime;
            if (movementTime > coolDown)
            {
                transform.Translate(-velX * 0.5f, 0, 0);
                spriteRenderer.enabled = false;
                circleCollider.enabled = false;
                active = true;
                movementTime = 0;
                basicEnemyScript.hit = false;
                Debug.Log("enter2");
            }
        }
        

        
    }
}
