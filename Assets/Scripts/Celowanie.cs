using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celowanie : MonoBehaviour
{
    public Transform weapon;

    private Camera _cam;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousepos = _cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 aimdirection = (mousepos - transform.position).normalized;
        float angle = Mathf.Atan2(aimdirection.y, aimdirection.x) * Mathf.Rad2Deg;
        weapon.localEulerAngles = new Vector3(0, 0, angle);

    }
}
