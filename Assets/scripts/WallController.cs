using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour {

    public GameObject left;
    public GameObject right;
    public GameObject top;
    public GameObject bottom;

	// Use this for initialization
	void Start () {
        right.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2f, 10f));
        left.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(0f, Screen.height / 2f, 10f));
        top.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height, 10f));
        bottom.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0f, 10f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
