using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public Text ammoDisplay;

    // Update is called once per frame
    void Update()
    {

    }

    public void SetAmmo(int ammo)
    {
        ammoDisplay.text = ammo.ToString();
    }
}
