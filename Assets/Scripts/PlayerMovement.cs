using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public RectTransform road;
    public Transform bottleTransform;
    public Transform FinishLineTransform;

    public GameObject Bottle;

    public float speedForward;
    public float speedSide;

    private float leftSideMax, rightSideMax;

    private float playerWidth;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerWidth = rb.transform.localScale.x / 2;
        leftSideMax = -road.sizeDelta.x / 2 + playerWidth;
        rightSideMax = road.sizeDelta.x / 2 - playerWidth;
        //Debug.Log("Left max: " + leftSideMax + "; Right max: " + rightSideMax);
    }


    void FixedUpdate()
    {
        
        Vector3 position = transform.position;
        float horizontal = Input.GetAxis("Horizontal");

        
        position.z += speedForward * Time.deltaTime;
        position.x += horizontal * speedSide * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(position.x, leftSideMax, rightSideMax), position.y, position.z);



    }

    [System.Obsolete]
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speedForward *= 5;
            
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speedForward /= 5;
        }

        //Debug.Log(bottleTransform.position.y);

        if ((bottleTransform.position.y < -5) || (transform.position.z > bottleTransform.position.z + 5))
        {
            Lose();
        }
        else if (bottleTransform.position.z > FinishLineTransform.position.z) {

            bottleTransform.position = FinishLineTransform.position;
            
            Win();
 
        }

        //Application.LoadLevel("");
    }


    void Lose()
    {
        SceneManager.LoadScene("Main");
    }

    void Win()
    {
        speedForward = 0;
        //Destroy(Bottle);
        Debug.Log("Win!");
    }




}
