using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    Rigidbody _rigidbody;
    Vector3 _currentVelocity;

	// Use this for initialization
	void Start () {
        _rigidbody = GetComponent<Rigidbody>();
        SetVelocity(new Vector3(0f, 0f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerCollision(collision);
        } else
        {
            EnvironmentCollision(collision);
        }
    }

    public void SetVelocity(Vector2 velocity)
    {
        _currentVelocity = velocity;
        _rigidbody.velocity = _currentVelocity;
    }

    void PlayerCollision(Collision collision)
    {
        BoxCollider boxCollider = collision.collider as BoxCollider;
        if (boxCollider != null)
        {
            Vector3 collisionNormal = collision.contacts[0].normal;
            // There's a trouble with collisions near walls (possibly contacts[0]) and something bad happens on hitting rear side
            Vector3 contactPoint = collision.contacts[0].point;
            Vector3 localContactPoint = collision.gameObject.transform.InverseTransformPoint(contactPoint);
            _currentVelocity = Quaternion.Euler(0, 0, -localContactPoint.x * 90) * collisionNormal * _currentVelocity.magnitude / collisionNormal.magnitude;
            _rigidbody.velocity = _currentVelocity;
        }
    }

    void EnvironmentCollision(Collision collision)
    {
        Vector3 collisionNormal = collision.contacts[0].normal;
        float projection = Vector3.Dot(_currentVelocity, collisionNormal);
        Vector3 projVector = projection / collisionNormal.magnitude * collisionNormal;
        _currentVelocity = _currentVelocity - 2 * projVector;
        _rigidbody.velocity = _currentVelocity;
    }
}
