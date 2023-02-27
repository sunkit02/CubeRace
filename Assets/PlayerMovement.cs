using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rigidBody;

    public float forwardForce = 2000f;
    public float sidewaysForce = 70f;
    public float upwardForce = 100f;
    public int jumpsLeft = 3;

    public bool isGoingRight = false;
    public bool isGoingLeft = false;
    public bool isJumping = false;

    void Update() {
        if (Input.GetKey("d")) {
            isGoingRight = true;
        } else {
            isGoingRight = false;
        }

        if (Input.GetKey("a")) {
            isGoingLeft = true;
        } else {
            isGoingLeft = false;
        }

        if (Input.GetKeyDown("space") && jumpsLeft > 0) {
            isJumping = true;
            jumpsLeft--;
        } else {
            isJumping = false;
        }
    }

    void OnCollisionEnter(Collision collisionInfo) {
        if (collisionInfo.collider.tag == "Ground") {
            jumpsLeft = 3;
        }
    }

    // We mark this as FixedUpdate because we are messing with Physics
    void FixedUpdate() {
        // Add a forward force
        rigidBody.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (isGoingRight) {
            rigidBody.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (isGoingLeft) {
            rigidBody.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (isJumping) {
            rigidBody.AddForce(0, upwardForce * Time.deltaTime, 0, ForceMode.VelocityChange);
            isJumping = false;
        }

    }
}
