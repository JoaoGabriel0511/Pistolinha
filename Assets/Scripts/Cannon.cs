using System.Collections;
using UnityEngine;

public class Cannon : MonoBehaviour {

	[SerializeField] GameObject ballRedPrefab;
	[SerializeField] GameObject ballGreenPrefab;
	[SerializeField] GameObject ballBluePrefab;
	[SerializeField] GameObject ballPrefab;
	[SerializeField] BallCollisionBehaviour[] ballBehaviours;

	[SerializeField] bool _redEnable = true;
	[SerializeField] bool _blueEnable = true;
	[SerializeField] bool _greenEnable = true;

	Constants.Type selectedColor = Constants.Type.RED;
	SpriteRenderer _spriteRenderer;

	[FMODUnity.EventRef]
	public string ShotEvent;
	FMOD.Studio.EventInstance Shot;

	[SerializeField] int _typeVar = (int)Constants.Type.RED;

    ColorMunition[] colorMunition;

	void Awake() {
		_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
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
	}
    /*
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
    }*/

    private void OnCollisionEnter2D(Collision2D collision) {

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
		if (Input.GetButtonDown("Fire")) {
			Shoot();
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
        GetComponentInChildren<Animator>().SetBool("isShooting", true);
		Shot = FMODUnity.RuntimeManager.CreateInstance(ShotEvent);
		Shot.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
		Shot.start();

		StartCoroutine("MakeShootSFX");
	}

	IEnumerator MakeShootSFX() {
		yield return new WaitForSeconds(0.175f);

		BallMovement ball;
		switch (selectedColor) {
			case Constants.Type.RED:
				ball = Instantiate(ballRedPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			case Constants.Type.BLUE:
				ball = Instantiate(ballBluePrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			case Constants.Type.GREEN:
				ball = Instantiate(ballGreenPrefab, transform.position, Quaternion.identity).GetComponent<BallMovement>();
				break;
			default:
				ball = null;
				break;
		}
		if (ball) {
			ball.SetRotation(transform.rotation);
		}

		yield break;
	}
}
