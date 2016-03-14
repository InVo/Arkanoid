using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public BallController Ball;
    public float BallStartPosition;
    public Vector2 BallStartVelocity;
    public float Speed;
    private Rigidbody _rigidbody;

    private const float BALL_START_POSITION = 0.3f;
    private Vector3 _ballStartPositionV;
    private float _ballRadius;
    private Rigidbody _ballRigidbody;

    private bool _ballLaunched = false;

    private const float PLAYER_X_LIMIT = 7.334f;

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
        float playerPosX = transform.position.x + hinput * Speed * Time.deltaTime;
        transform.position = new Vector3 (Mathf.Clamp(playerPosX, -PLAYER_X_LIMIT, PLAYER_X_LIMIT), transform.position.y);
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
        Ball.Launch(BallStartVelocity);
    }
}
