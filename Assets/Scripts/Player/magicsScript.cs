using UnityEngine;

public class magicsScript : MonoBehaviour
{


    public bool rockAtk = false;

    [SerializeField] public GameObject Rock;
    [SerializeField] public Transform spawnRock;



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
        if (rockAtk)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(Rock, spawnRock.position, spawnRock.rotation);
                rockAtk = false;
            }
        }
    }


}
