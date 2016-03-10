using UnityEngine;
using System.Collections.Generic;

public class BricksController : MonoBehaviour {

    [SerializeField]
    private int _columns;

    [SerializeField]
    private int _rows;

    private List<Brick> _bricksPool;
    private Brick _original;

    public int Columns { get { return _columns; } set { _columns = value; } }
    public int Rows { get { return _rows; } set { _rows = value; } }

    void Awake()
    {

    }
    // Use this for initialization
    void Start () {
        InitBricks();
	}

    public void InitBricks()
    {
        Brick brick = Resources.Load<Brick>("prefabs/brick");
        float brickWidth = brick.transform.localScale.x * brick.GetComponent<BoxCollider>().size.x;
        float brickHeight = brick.transform.localScale.y * brick.GetComponent<BoxCollider>().size.y;
        float totalWidth = brickWidth * _columns;
        float totalHeight = brickHeight * _rows;
        Vector2 startPoint = new Vector2((-totalWidth + brickWidth) / 2f, (totalHeight + brickHeight) / 2f);
        for(int i = 0; i < _columns; ++i)
        {
            for (int j = 0; j < _rows; ++j)
            {
                Brick newBrick = Instantiate<Brick>(brick);
                newBrick.transform.localPosition = new Vector3(startPoint.x + i * brickWidth, startPoint.y - j * brickHeight);
            }
        }
    }

    public void InitBricks(int columns, int rows)
    {

    }
}
