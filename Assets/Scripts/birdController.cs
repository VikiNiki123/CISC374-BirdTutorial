using UnityEngine;

public class birdController : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public ScreenShake screenShake;
    public bool birdIsAlive = true;

    public float maxRotation = 15f; //Max tilt power
    public float rotationSpeed = 5f; //Speed for Tween


    public AudioSource soundCollision;
    public AudioSource soundBounce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        screenShake = Camera.main.GetComponent<ScreenShake>();
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
            myRigidbody.linearVelocity = Vector2.up *  flapStrength;
            logic.playSound(soundBounce);
            float rotationZ = Mathf.LerpAngle(transform.eulerAngles.z, maxRotation, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, rotationZ);
        }

        if(transform.position.y > Camera.main.orthographicSize || transform.position.y < -Camera.main.orthographicSize){
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        logic.playSound(soundCollision);
        screenShake.TriggerShake(0.5f, 0.2f);
    }

    void FixedUpdate()
    {
        if (birdIsAlive)
        {
            // If falling, rotate the bird downward
            if (myRigidbody.linearVelocity.y < 0)
            {
                float rotationZ = Mathf.LerpAngle(transform.eulerAngles.z, -maxRotation, rotationSpeed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, rotationZ);
            }
        }
    }
}
