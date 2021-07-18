using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour {
	public Action<int> StageCleared;

	[SerializeField] int shootsFor1Star = 30;
	[SerializeField] int shootsFor2Stars = 20;
	[SerializeField] int shootsFor3Stars = 10;
	int shootsFired;
	int score = 0;


	void Start() {
		shootsFired = 0;
		FindObjectOfType<Goal>().StageCleared.AddListener(() => {
			OnStageCleared();
		});
	}

	public void CountShoot() {
		shootsFired++;
	}

	public int GetShootCount() {
		return shootsFired;
	}

	public int GetShootsFor1Star() {
		return shootsFor1Star;
	}

	public int GetShootsFor2Stars() {
		return shootsFor2Stars;
	}

	public int GetShootsFor3Stars() {
		return shootsFor3Stars;
	}

	void OnStageCleared()
	{
		if (shootsFired < shootsFor3Stars) 
		{
			score = 3;
		}
		else if (shootsFired < shootsFor2Stars) 
		{
			score = 2;
		}
		else if (shootsFired < shootsFor1Star) 
		{
			score = 1;
		}
		GameManager.Instance.StageCleared(score);
		StageCleared?.Invoke(score);
	}
}
