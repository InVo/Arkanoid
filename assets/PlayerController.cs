using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public BallController Ball;
    public float BallStartPosition;
    public Vector2 BallStartVelocity;
    private Rigidbody _rigidbody;

    private const float BALL_START_POSITION = 0.3f;
    private Vector3 _ballStartPositionV;
    private float _ballRadius;
    private Rigidbody _ballRigidbody;

    private bool _ballLaunched = false;

    // Use this for initialization
    void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        _ballStartPositionV = new Vector3(BallStartPosition, boxCollider.size.y * transform.localScale.y / 2f);
        _ballRadius = Ball.GetComponent<SphereCollider>().radius;
        SetBallPosition();
    }
	 
	// Update is called once per frame
	void Update () {
        float hinput = Input.GetAxis("Horizontal");
        if (hinput != 0)
        {
            _rigidbody.AddForce(hinput, 0, 0);
        }
        if (!_ballLaunched)
        {
            SetBallPosition();
        }
        if (!_ballLaunched && Input.GetButton("Fire1"))
        {
            LaunchBall();
        }
	}

    void FixedUpdate()
    {

    }

    void SetBallPosition()
    {
        Ball.transform.position = transform.TransformPoint(_ballStartPositionV + new Vector3(0, _ballRadius));
    }

    void LaunchBall()
    {
        _ballLaunched = true;
        Ball.SetVelocity(BallStartVelocity);
    }
}
