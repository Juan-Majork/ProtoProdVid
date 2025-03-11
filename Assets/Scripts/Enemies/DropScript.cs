using UnityEngine;

public class DropScript : MonoBehaviour
{

    [SerializeField] public GameObject fire;
    [SerializeField] public GameObject water;
    [SerializeField] public GameObject rock;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Dropeo(int type)
    {
        if (type == 1)
        {
            fire.SetActive(true);
        }
        if (type == 2)
        {
            water.SetActive(true);
        }
        if (type == 3)
        {
            rock.SetActive(true);
        }
    }
}
