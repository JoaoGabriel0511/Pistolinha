using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    //[SerializeField] GameObject redBallPrefab;
    //[SerializeField] GameObject blueBallPrefab;
    //[SerializeField] GameObject greenBallPrefab;
    
    [SerializeField] List<BallMovement> ballPoll = new List<BallMovement>();
    List<BallMovement> ballUsed = new List<BallMovement>();
    


    [SerializeField] bool _redEnable = true;
	[SerializeField] bool _blueEnable = true;
	[SerializeField] bool _greenEnable = true;

	Constants.Type selectedColor = Constants.Type.RED;
	SpriteRenderer _spriteRenderer;
    Animator _animator;
    AudioEmitter _audioEmitter;

	[SerializeField] int _typeVar = (int)Constants.Type.RED;

    ColorMunition[] colorMunition;

	void Awake() {
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animator = GetComponentInChildren<Animator>();
        _audioEmitter = GetComponent<AudioEmitter>();

		if (!_spriteRenderer) {
			Debug.Log("No SpriteRenderer found.");
		}

		if (_redEnable) {
			_spriteRenderer.color = Color.red;
			selectedColor = Constants.Type.RED;
			_typeVar = (int)Constants.Type.RED;
		}
		else if (_blueEnable) {
			_spriteRenderer.color = Color.blue;
			selectedColor = Constants.Type.BLUE;
			_typeVar = (int)Constants.Type.BLUE;
		}
		else if (_greenEnable) {
			_spriteRenderer.color = Color.green;
			selectedColor = Constants.Type.GREEN;
			_typeVar = (int)Constants.Type.GREEN;
		}
		else {
			Debug.Log("No color enabled in the cannon!");
		}

        foreach(BallMovement ball in ballPoll)
        {
            ball.GetComponentInChildren<VisualCallbacks>().onAnimationFinish = DeactiveBall;
            ball.GetComponentInChildren<VisualCallbacks>().onBecameInvisible = DeactiveBall;
            ball.gameObject.SetActive(false);
        }
	}
    
    void OnEnable()
    {
        colorMunition = FindObjectsOfType<ColorMunition>();
        foreach (ColorMunition cl in colorMunition)
        {
            cl.clickedEvent.AddListener(ChangeColor);
        }
    }

    void OnDisable()
    {
        foreach (ColorMunition cl in colorMunition)
        {
            cl.clickedEvent.RemoveListener(ChangeColor);
        }
    }

    public void ChangeColor(Constants.Type type)
    {
        switch (type)
        {
            case Constants.Type.BLUE:
                SwitchToBlue();
                break;
            case Constants.Type.RED:
                SwitchToRed();
                break;
            case Constants.Type.GREEN:
                SwitchToGreen();
                break;
            default:
                break;
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Input.mousePosition;
            Bounds bounds = GetComponent<BoxCollider2D>().bounds;
            Vector2 size = GetComponent<BoxCollider2D>().size;
            if (new Rect(bounds.min.x, bounds.min.y, size.x, size.y).Contains(Camera.main.ScreenToWorldPoint(mousePos))) {
                Shoot();
            }
        }
	}

	private void SwitchToPreviousBall() {

		switch (selectedColor) {
			case Constants.Type.RED:
				selectedColor = Constants.Type.GREEN;
				_spriteRenderer.color = Color.green;
				break;
			case Constants.Type.BLUE:
				selectedColor = Constants.Type.RED;
				_spriteRenderer.color = Color.red;
				break;
			case Constants.Type.GREEN:
				selectedColor = Constants.Type.BLUE;
				_spriteRenderer.color = Color.blue;
				break;
			default:
				break;
		}
	}

	public void SwitchToGreen() {
        selectedColor = Constants.Type.GREEN;
        _spriteRenderer.color = Color.green;
	}

    public void SwitchToBlue() {
        selectedColor = Constants.Type.BLUE;
        _spriteRenderer.color = Color.blue;
    }

    public void SwitchToRed()
    {
        selectedColor = Constants.Type.RED;
        _spriteRenderer.color = Color.red;
    }

    private void Shoot() {
        _animator.SetBool("isShooting", true);
		_audioEmitter.PlaySound();

		StartCoroutine("MakeShootSFX");
	}

    IEnumerator MakeShootSFX() {
        yield return new WaitForSeconds(0.175f);

        BallMovement ball;
        /*
        switch (selectedColor) {
			case Constants.Type.RED:
                //ball = Instantiate(redBallPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			case Constants.Type.BLUE:
				//ball = Instantiate(blueBallPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			case Constants.Type.GREEN:
				//ball = Instantiate(greenBallPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			default:
				ball = null;
				break;
		}*/
        int ballIndex = ballPoll.FindIndex(0,
            (BallMovement ballMovement) => ballMovement.Type == selectedColor);

        if (ballIndex != -1)
        {
            ball = ballPoll[ballIndex];
            ballPoll.RemoveAt(ballIndex);
            ballUsed.Add(ball);
        }
        else ball = null;

        if (ball) {
            ball.gameObject.SetActive(true);
			ball.SetRotation(transform.rotation);
		}

		yield break;
	}

    void DeactiveBall(GameObject go)
    {

        go.transform.parent.gameObject.SetActive(false);
        BallMovement ball = go.transform.parent.GetComponent<BallMovement>();
        int ballIndex = ballUsed.IndexOf(ball);

        if (ballIndex != -1)
        {
            ball.transform.position = transform.position;
            ball = ballUsed[ballIndex];
            ballUsed.RemoveAt(ballIndex);
            ballPoll.Add(ball);
        }
    }

}
