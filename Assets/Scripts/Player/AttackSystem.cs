using Unity.VisualScripting;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{

    public int attack = 2;

    private magicsScript magicsScript;


    private void Awake()
    {
        magicsScript = magicsScript = Object.FindAnyObjectByType<magicsScript>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        magicPlus();
    }


    public void magicPlus()
    {
        //Incrementa el daño del baston cuando se pickea magia
        if (magicsScript.fireAtk && magicsScript.fullMagic < 3)
        {
            attack = 5;
        }
        if (magicsScript.waterAtk && magicsScript.fullMagic < 3)
        {
            attack = 4;
        }
        if (magicsScript.rockAtk && magicsScript.fullMagic < 3)
        {
            attack = 6;
        }
    }

    

}
