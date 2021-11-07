using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MarbleBehavior : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 15f;

    private float fbInput;
    private float lrInput;

    private Rigidbody _rb;

    public GameObject BlastPrefab;
    public SphereCollider _collider;

    public uint health = 5;

    public Text health_field;
    public GameObject obstacle_container;
    public GameObject game_manager;

    void UpdateHealth() {
        health_field.text = "Health: " + health.ToString();
    }

    void Start()
    {
        //You'll need to add a rigidbody to the marble first
       _rb = GetComponent<Rigidbody>();
       _collider = GetComponent<SphereCollider>();
       UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        // Put code is for movement using the Sprite's native variables here
        fbInput = Input.GetAxis("Vertical") * moveSpeed;
        lrInput = Input.GetAxis("Horizontal") * rotateSpeed;
        this.transform.Translate(Vector3.forward * fbInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * lrInput * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y <= 0.51) {
            _rb.AddForce(new Vector3(0.0f, 5.0f, 0.0f), ForceMode.Impulse);
        }
    }

    void OnMouseDown()
    {
        GameObject blast = Instantiate(BlastPrefab, this.transform.position + this.transform.forward * _collider.radius, this.transform.rotation);
    }

    void FixedUpdate()
    {

        //Put code that moves the sprite using the RigidBody here
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            health -= 1;
            UpdateHealth();
            if (health == 0) {
                game_manager.GetComponent<GameBehavior>().MarbleLose();
            }
        }
    }
}
