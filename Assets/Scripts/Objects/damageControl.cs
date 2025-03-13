using Unity.VisualScripting;
using UnityEngine;

public class damageControl : MonoBehaviour
{

    [SerializeField] public int dmg;
    [SerializeField] public float fireDuration = 0;
    public bool fireOnScreen = false;
    [SerializeField] public float waterDuration = 0;
    public bool waterOnScreen = false;

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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //magia de roca desaparece on hit con piso
        if (collision.gameObject.CompareTag("floor") && gameObject.CompareTag("rockMagic"))
        {
            Destroy(gameObject);
        }

    }

    public void MagicDamage()
    {
        //magia de fuego se mantiene durante 10 segundos
        if (fireDuration < 10 && fireOnScreen)
        {
            fireDuration += Time.deltaTime;
        }
        if (fireDuration >= 10)
        {
            fireOnScreen = false;
            fireDuration = 0;
            Destroy(magicsScript.Fire);
        }

        //magia de agua se mantiene durante 1 segundo
        if (waterDuration < 1 && waterOnScreen)
        {
            waterDuration += Time.deltaTime;
        }
        if (waterDuration >= 1)
        {
            waterOnScreen = false;
            waterDuration = 0;
            Destroy(magicsScript.Water);
        }
    }
}
