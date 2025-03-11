using Unity.VisualScripting;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{

    public int attack = 3;

    public int magicalBonus = 0;
    //1 = fire
    //2 = water
    //3 = rock


    private void Start()
    {
        
    }

    private void Update()
    {
        magic();
    }

    public void magic()
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
