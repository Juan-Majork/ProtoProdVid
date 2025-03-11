using UnityEngine;

public class DropScript : MonoBehaviour
{

    [SerializeField] public GameObject element;

    public void Dropeo()
    {
        Instantiate(element, transform.position, transform.rotation);
    }
}
