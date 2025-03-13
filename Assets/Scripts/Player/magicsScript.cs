using UnityEngine;

public class magicsScript : MonoBehaviour
{
    public int fullMagic = 0;

    public bool waterAtk = false;
    public bool fireAtk = false;
    public bool rockAtk = false;

    [SerializeField] public GameObject Rock;
    [SerializeField] public GameObject Fire;
    [SerializeField] public GameObject Water;
    [SerializeField] public Transform spawnRock;


    private AttackSystem attackSystem;

    private damageControl damageControl;

    private void Awake()
    {
        attackSystem = Object.FindAnyObjectByType<AttackSystem>();
        damageControl = Object.FindAnyObjectByType<damageControl>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void magicAttacks()
    {
        if (fullMagic == 2) //Si los slots estan llenos, chequea el valor del ataque del baston, que es equivalente al ultimo hechizo agarrado.
        {
            if (rockAtk && attackSystem.attack == 6)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(Rock, spawnRock.position, spawnRock.rotation);
                    rockAtk = false;
                    fullMagic--;
                }
            }
            if (fireAtk && attackSystem.attack == 5)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Fire.SetActive(true);
                    fireAtk = false;
                    fullMagic--;
                }
            }
            if (waterAtk && attackSystem.attack == 4)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Water.SetActive(true);
                    waterAtk = false;
                    fullMagic--;
                }
            }
        }
        else //Sino, solo necesita chequear que booleano quedó en true.
        {
            if (rockAtk)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(Rock, spawnRock.position, spawnRock.rotation);
                    rockAtk = false;
                    fullMagic--;
                }
            }
            if (fireAtk)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Fire.SetActive(true);
                    fireAtk = false;
                    fullMagic--;
                }
            }
            if (waterAtk)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Water.SetActive(true);
                    waterAtk = false;
                    fullMagic--;
                }
            }
        }

        
    }


}
