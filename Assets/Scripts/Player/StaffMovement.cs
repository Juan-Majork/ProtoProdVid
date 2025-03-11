using UnityEngine;

public class StaffMovement : MonoBehaviour
{

    private int velX = 1;
    public bool active = true;
    private float movementTime = 0;
    private float coolDown = 0.7f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheStaff();
    }

    public void MoveTheStaff()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (active)
            {
                transform.Translate(velX * 1f, 0, 0);
                
                active = false;
                Debug.Log("enter");

            }
        }

        if (!active)
        {
            movementTime += Time.deltaTime;
            if (movementTime > coolDown)
            {
                transform.Translate(-velX * 1f, 0, 0);
                active = true;
                movementTime = 0;
                Debug.Log("enter2");
            }
        }
        

        
    }
}
