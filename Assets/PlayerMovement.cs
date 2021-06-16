using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float sidespeed;
    public float speedUp;
    public float roll;
    public TextMeshPro scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, speed * Time.deltaTime);
        rb.transform.Rotate(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), roll);

        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidespeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidespeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("s") && speed >= 0)
        {
            speed -= 100;
        }
        if (Input.GetKey("w") && speed <= 2000)
        {
            speed += 100;
        }

        if (Input.GetKey("q"))
        {
            roll += 0.15f;
        }
        if (Input.GetKey("e"))
        {
            roll -= 0.15f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(0, speedUp * Time.deltaTime, 0, ForceMode.VelocityChange);
        }

        scoreText.text = transform.position.z.ToString("#");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            speed = 0;
            sidespeed = 0;
        }
    }
}
