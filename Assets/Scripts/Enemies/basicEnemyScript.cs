using UnityEngine;

public class basicEnemyScript : MonoBehaviour
{

    private int health = 10;

    private AttackSystem atck;


    private void Awake()
    {
        atck = Object.FindAnyObjectByType<AttackSystem>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("staff"))
        {
            health -= atck.attack;
            Debug.Log("health left: " +  health);
            if (health < 0)
            {
                Destroy(gameObject);
            }
        }
    }


}
