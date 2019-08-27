using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionManager : MonoBehaviour {
	#region Attributes

	#region Player Pref Key Constants

	private const string RESOLUTION_PREF_KEY = "resolution";

	#endregion

	#region Resolution

	[SerializeField] private TextMeshProUGUI resolutionText;
	struct Res {
		public int width;
		public int height;
	}
	private Res[] resolutions;
	private int currentResolutionIndex = 0;

	#endregion

	#endregion


	#region Helpers

	#region IndexWrappers
	private int GetNextWrappedIndex<T>(IList<T> collection, int currentIndex) {
		if (collection.Count < 1) return 0;
		return (currentIndex + 1) % collection.Count;
	}

	private int GetPreviousWrappedIndex<T>(IList<T> collection, int currentIndex) {
		if (collection.Count < 1) return 0;
		if ((currentIndex - 1) < 0) return collection.Count - 1;
		return (currentIndex - 1) % collection.Count;
	}

	#endregion

	#endregion

	#region Resolution cycling

	private void SetResolutionText(Res resolution) {
		resolutionText.text = resolution.width + "X" + resolution.height;
	}

	public void SetNextResolution() {
		currentResolutionIndex = GetNextWrappedIndex(resolutions, currentResolutionIndex);
		SetResolutionText(resolutions[currentResolutionIndex]);
	}

	public void SetPreviousResolution() {
		currentResolutionIndex = GetPreviousWrappedIndex(resolutions, currentResolutionIndex);
		SetResolutionText(resolutions[currentResolutionIndex]);
	}

	#endregion

	private void Start() {
		//resolutions = Screen.resolutions;
		resolutions = new Res[4];
		// 0
		resolutions[0].width = 360;
		resolutions[0].height = 640;
		// 1
		resolutions[1].width = 240;
		resolutions[1].height = 426;
		// 2
		resolutions[2].width = 144;
		resolutions[2].height = 256;
		// 3
		resolutions[3].width = 540;
		resolutions[3].height = 960;

		//currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);
		currentResolutionIndex = 0;

		SetResolutionText(resolutions[currentResolutionIndex]);
	}

	#region Apply Resolution

	private void SetAndApplyResolution(int newResolutionIndex) {
		currentResolutionIndex = newResolutionIndex;
		ApplyCurrentResolution();
	}

	private void ApplyCurrentResolution() {
		ApplyResolution(resolutions[currentResolutionIndex]);
	}

	private void ApplyResolution(Res resolution) {
		SetResolutionText(resolution);
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
		//PlayerPrefs.SetInt(RESOLUTION_PREF_KEY, currentResolutionIndex);
	}

	#endregion

	public void ApplyChanges() {
		SetAndApplyResolution(currentResolutionIndex);
	}

}
