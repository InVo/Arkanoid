using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public ParticleSystem BrickBreak;
    public DestroyParticles DestroyPart;

    void Awake()
    {
        if (BrickBreak == null)
        {
            BrickBreak = GetComponentInChildren<ParticleSystem>();
            DestroyPart = GetComponentInChildren<DestroyParticles>();
        }
        DestroyPart.enabled = false;
    }

	// Use this for initialization
	void Start () {

	}

    void OnCollisionEnter(Collision col)
    {
        BrickBreak.transform.parent = null;
        DestroyPart.enabled = true;
        BrickBreak.Play();
        GameManager.Instance.ReduceBricksCount();
        Destroy(gameObject);
    }
}
