using UnityEngine;
using System.Collections;
public class Player1 : MonoBehaviour {
    public static GameObject noActiveWeapon = null;
    public static bool weaponB = false;
    public static GameObject playerObj;
    public static GameObject[] weapons;
    public GameObject[] weaponList;

    bool check = false;
    // Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        if (!check)
        {
            playerObj = this.gameObject;
            if (playerObj != null) check = true;
        }
	}

}
