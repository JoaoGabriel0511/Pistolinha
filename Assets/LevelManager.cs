using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int shootsFor1Star = 30;
    [SerializeField] int shootsFor2Stars = 20;
    [SerializeField] int shootsFor3Stars = 10;
    int shootsFired;
    // Start is called before the first frame update
    void Start()
    {
        shootsFired = 0;        
    }

    public void CountShoot() {
        shootsFired++;
        Debug.Log("shoots fired" + shootsFired);
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
}
