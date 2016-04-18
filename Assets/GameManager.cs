using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    [SerializeField]
    private Animator _youWinTextAnim;
    [SerializeField]
    private GameObject _youWinText;
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public PlayerController Player;
    public BricksController Bricks;

    private int _initialBricksCount;
    private int _currentBricksCount;

	// Use this for initialization
	void Start () {
        _initialBricksCount = FindObjectsOfType<Brick>().Length;
        _currentBricksCount = _initialBricksCount;
    }

    public void ReduceBricksCount() {
        --_currentBricksCount;
        if (_currentBricksCount == 0)
        {
            _youWinText.gameObject.SetActive(true);
            _youWinTextAnim.SetBool("PlayerWon", true);
        }
    }
    
    public void OnDeathCollision()
    {
        Player.Reset();
    }
}
