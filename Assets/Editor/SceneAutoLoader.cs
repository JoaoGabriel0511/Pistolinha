using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public static class SceneAutoLoader {

    const string _MasterScene = "SceneAutoLoader.MasterScene";
    const string _LoadMasterOnPlay = "SceneAutoLoader.LoadMasterOnPlay";
    const string _PreviousScene = "SceneAutoLoader.PreviousScene";

    static string MasterScene
    {
        get { return EditorPrefs.GetString(_MasterScene, ""); }
        set { EditorPrefs.SetString(_MasterScene, value); }
    }
    static bool LoadMasterOnPlay
    {
        get { return EditorPrefs.GetBool(_LoadMasterOnPlay, false); }
        set { EditorPrefs.SetBool(_LoadMasterOnPlay, value); }
    }
    static string PreviousScene
    {
        get { return EditorPrefs.GetString(_PreviousScene, EditorSceneManager.GetActiveScene().path); }
        set { EditorPrefs.SetString(_PreviousScene, value); }
    }
    // Menu Itens
    #region
    [MenuItem("File/Scene Autoload/Select Master Scene...")]
    static void SelectMasterScene()
    {
        string masterScene = EditorUtility.OpenFilePanel("Select Master Scene", Application.dataPath, "unity");
        masterScene = masterScene.Replace(Application.dataPath, "Assets");
        if (!string.IsNullOrEmpty(masterScene))
        {
            MasterScene = masterScene;
            LoadMasterOnPlay = true;
        }
    }

    [MenuItem("File/Scene Autoload/Load Master On Play", true)]
    static bool ShowLoadMasterOnPlay()
    {
        return !LoadMasterOnPlay;
    }

    [MenuItem("File/Scene Autoload/Don't load Master On Play", true)]
    static bool ShowDontLoadMasterOnPlay()
    {
        return LoadMasterOnPlay;
    }

    [MenuItem("File/Scene Autoload/Load Master On Play")]
    static void EnableLoadMasterOnPlay()
    {
        LoadMasterOnPlay = true;
    }

    [MenuItem("File/Scene Autoload/Don't load Master On Play")]
    static void DisableLoadMasterOnPlay()
    {
        LoadMasterOnPlay = false;
    }
    #endregion


    static SceneAutoLoader() {
        EditorApplication.playModeStateChanged += OnPlayModeStateChange;
    }

    static void OnPlayModeStateChange(PlayModeStateChange state)
    {
        if (!LoadMasterOnPlay) return;

        if(!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
        {
            PreviousScene = EditorSceneManager.GetActiveScene().path;
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                try
                {
                    EditorSceneManager.OpenScene(MasterScene);
                }
                catch
                {
                    Debug.LogError(string.Format("error: scene not found: {0}", MasterScene));
                    EditorApplication.isPlaying = false;
                }
            }
            else
            {
                EditorApplication.isPlaying = false;
            }

        }

        if(!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
        {
            try
            {
                EditorSceneManager.OpenScene(PreviousScene);
            }
            catch
            {
                Debug.Log(string.Format("error: scene not found: {0}", PreviousScene));
            }
        }
    }
}
