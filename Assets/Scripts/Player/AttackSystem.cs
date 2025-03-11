using Unity.VisualScripting;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{

    public int attack = 2;

    public int magicalBonus = 0;
    //1 = fire
    //2 = water
    //3 = rock


    private void Start()
    {
        
    }

    private void Update()
    {
        magicPlus();
    }


    public void magicPlus()
    {

        if (magicalBonus == 1)
        {
            attack += 4;
        }

        if (magicalBonus == 2)
        {
            attack += 2;
        }

        if (magicalBonus == 3)
        {
            attack += 3;
        }
    }

    

}
