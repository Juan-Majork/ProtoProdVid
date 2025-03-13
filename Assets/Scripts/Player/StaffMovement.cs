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

    private void Awake()
    {
        basicEnemyScript = Object.FindAnyObjectByType<basicEnemyScript>();
        magicsScript = Object.FindAnyObjectByType<magicsScript>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheStaff(); //Ataque de baston
    }

    public void MoveTheStaff() //Ataque con baston
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
                circleCollider.enabled = false;
                active = true;
                basicEnemyScript.hit = false;
                movementTime = 0;
                Debug.Log("enter2");
            }
        }
    }
}
