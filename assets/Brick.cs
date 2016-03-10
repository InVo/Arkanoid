using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        Destroy(this.gameObject);
    }
}
