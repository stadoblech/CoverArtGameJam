using UnityEngine;
using System.Collections;

public class PlayerControlls : MonoBehaviour {

    public KeyCode moveLeft = KeyCode.LeftArrow;
    public KeyCode moveRight = KeyCode.RightArrow;
    public KeyCode moveUp = KeyCode.Space;

    public float movementSpeed;
    public float jumpSpeed;

    public float jumpHeight;
    Vector3 jumpDestination;
    public Vector3 previousPosition
    { get; private set; }

    public float maxLeft;
    public float maxRight;

    Rigidbody2D rigid;

    public bool jumping
    {
        get; private set;
    }

    void Start () {
        previousPosition = transform.position;
        rigid = GetComponent<Rigidbody2D>();
        jumping = false;
	}
	
	// Update is called once per frame
	void Update () {

        checkForBoundaries();

	    if(Input.GetKey(moveLeft) && !jumping)
        {
            rigid.AddForce(-transform.right * movementSpeed);
        }

        if (Input.GetKey(moveRight) && !jumping)
        {
            rigid.AddForce(transform.right * movementSpeed);
        }

        if (Input.GetKeyDown(moveUp) && !jumping)
        {
            rigid.velocity = new Vector2(0, 0);
            jumping = true;
            jumpDestination = new Vector2(transform.position.x, jumpHeight);
            previousPosition = transform.position;
        }

        if(jumping)
        {
            JumpManeuvre();
        }
    }

    void JumpManeuvre()
    {
        transform.position = Vector3.MoveTowards(transform.position,jumpDestination,jumpSpeed*Time.deltaTime);

        if(transform.position == jumpDestination)
        {
            jumpDestination = previousPosition;
        }

        if(transform.position == previousPosition)
        {
            jumping = false;
        }
    }

    void checkForBoundaries()
    {
        if (transform.position.x > maxRight)
        {
            transform.position = new Vector3(maxRight, transform.position.y);
        }

        if (transform.position.x < maxLeft)
        {
            transform.position = new Vector3(maxLeft, transform.position.y);
        }
    }
}
