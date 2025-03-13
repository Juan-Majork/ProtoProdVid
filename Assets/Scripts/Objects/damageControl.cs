using Unity.VisualScripting;
using UnityEngine;

public class damageControl : MonoBehaviour
{

    [SerializeField] public int dmg;

    [SerializeField] public float fireDuration = 0;
    public float dmgCounter = 0;



    [SerializeField] public float waterDuration = 0;

    private magicsScript magicsScript;


    private void Awake()
    {
        magicsScript = Object.FindAnyObjectByType<magicsScript>();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MagicDamage();
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        //magia de roca desaparece on hit con piso
        if (collision.gameObject.CompareTag("floor") && gameObject.CompareTag("rockMagic"))
        {
            Destroy(gameObject);
        }

    }

    public void MagicDamage()
    {
        
        if (magicsScript.Fire.activeSelf)
        {
            //magia de fuego se mantiene durante 10 segundos
            if (fireDuration < 10)
            {
                fireDuration += Time.deltaTime;
                if (fireDuration >= 10)
                {
                    fireDuration = 0;
                    magicsScript.Fire.SetActive(false);
                }
            }
        }
        

        //magia de agua se mantiene durante 1 segundo
        if (waterDuration < 0.2f)
        {
            waterDuration += Time.deltaTime;
            if (waterDuration >= 0.2f)
            {
                waterDuration = 0;
                magicsScript.Water.SetActive(false);
            }
        }
        
    }
}
