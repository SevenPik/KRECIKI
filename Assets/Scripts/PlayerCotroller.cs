using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCotroller : MonoBehaviour
{
    public KeyCode fireButton = KeyCode.Mouse0;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Weapon weapon;
    public Rigidbody2D bron;
    public Animator animator;
    public int startingAmmo;
    public int ammo;
    public AmmoDisplay ammoDisplay;

    Vector2 moveDirection;
    Vector2 mousePosition;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.1f;
    private float dashingCooldown = 1f; //s//

    [SerializeField] private TrailRenderer tr; //s//


    // Update is called once per frame
    void Start()
    {
        ammo = startingAmmo;
        bron = GameObject.Find("Weapon").GetComponent<Rigidbody2D>();
        ammoDisplay.SetAmmo(ammo);
    }

    void Update()
    {
      
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(fireButton) && ammo > 0)
        {
            ammo--;
            weapon.Fire();
            ammoDisplay.SetAmmo(ammo);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = startingAmmo;
            ammoDisplay.SetAmmo(ammo);
        }

        moveDirection = new Vector2(moveX, moveY);
        moveDirection = Vector2.ClampMagnitude(moveDirection, 1f);

        animator.SetFloat("moveX", moveDirection.x);
        animator.SetFloat("moveY", moveDirection.y);
        animator.SetFloat("moveSpeed", moveDirection.magnitude);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.E) && canDash)
        {
            StartCoroutine(Dash()); //e//
        }
    }


    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        } 
        rb.velocity = moveDirection * moveSpeed;

    }

    public enum MoveDirection
    {
        Left,
        Right,
        Up,
        Down
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    } //e//
}