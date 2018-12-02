using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class mainCharControl : MonoBehaviour {

    // what do we want here?
    // Done!
    // 1. when the mouse holds on a character it should get seperated not run anymore and change sprite and selector comes up
    //
    // 2. chars have type --> change color by type
    //
    // 3. camera target must change when one's selected
    //
    // 4. Lose

    public bool grounded = false, jumping = false, air = false, angry = false, selected = false, active = false;
    public float moveToMouseDuration = 0.5f, jumpAfter = 0.2f, speed, inactivationTime = 0.1f, getCharsIn = 0.1f, timeBeforeDie = 3;
    public GameObject selectorPrefab, selector, blood, UIPrefab;
    public Animator animator;
    public AudioClip[] stepsounds;
    public AudioClip thacrifaazthSound;
    public AudioClip[] die;
    

    public static int count = 0;
    public static charsArr charArray;

    private AudioSource audioSource, talk;
    private Camera cam;
    private int step;
    private bool killed = false, getKilled = false;
    private Color c;
    private Tween colorTween;
    private SpriteRenderer sr;
    private float time;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        c = sr.color;
        audioSource = GetComponent<AudioSource>();
        talk = GetComponentInChildren<Light>().GetComponent<AudioSource>();
        cam = FindObjectOfType<Camera>();
        count++;
        animator = gameObject.GetComponent<Animator>();
    }

    public void StepSound()
    {
        audioSource.PlayOneShot(stepsounds[step]);
        step++;
        step = step % stepsounds.Length;
    }
    
    public void kill()
    {
        count--;
        if(count <= 0)
        {
            //lose condition
            Lose();
        }
        Instantiate(blood, transform.position, Quaternion.identity);
        charArray.getCharsIn(getCharsIn);
        Destroy(gameObject);
    }

    void Lose()
    {
        LevelManager lm = Instantiate(UIPrefab).GetComponentInChildren<LevelManager>();
        lm.Lose();
    }

    void Win()
    {
        LevelManager lm = Instantiate(UIPrefab).GetComponentInChildren<LevelManager>();
        lm.Win();
    }

    public void Inactivate()
    {
        active = false;
    }

    #region on mouse drag - up

    private void OnMouseDown()
    {
        cam.GetComponent<followChar>().ChangeTarget(transform);
        talk.PlayOneShot(thacrifaazthSound);
        getKilled = true;
        time = timeBeforeDie;
        colorTween = sr.DOColor(Color.black, timeBeforeDie);
    }

    private void OnMouseDrag()
    {

        //mouse on target
        selected = true; // call the function to creat selection
        air = true;
        //move to mouse position:
        Vector3 mousePos = cam.ScreenToWorldPoint( Input.mousePosition );
        Vector3 newPos = new Vector3( mousePos.x, mousePos.y< charArray.ghab1.position.y && mousePos.y > charArray.ghab2.position.y? mousePos.y: transform.position.y, transform.position.z );
        transform.position = newPos;
        active = true;

    }

    private void OnMouseUp()
    {
        //mouse up
        active = false;
        air = false;
        selected = false;
        colorTween.Kill();
        getKilled = false;
        sr.DOColor(c, 0.2f);
    }

    #endregion

    #region ontriggerstay and exit

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            makeGrounded(collision);
        }

        if(collision.tag == "killer" && !killed)
        {
            killed = true;
            kill();
        }

        if( active && collision.tag == "gear" && !killed)
        {

            killed = true;
            collision.GetComponent<gear>().stop( sr.color );
            kill();

        }

        if(collision.tag == "winZone")
        {
            Win();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            makeGrounded(collision);
        }
    }

    void makeGrounded(Collider2D collision)
    {
        grounded = true;
        CancelInvoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "ground")
        {
            Invoke("Jump", jumpAfter);
        }

    }

    private void Jump()
    {
        grounded = false;
    }

    #endregion

    private void FixedUpdate()
    {
        // move the character
        //transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y, transform.position.z); it's done in camera
        if (!grounded && !jumping && !air)
        {
            jumping = true;
            animator.SetBool("jump", true);
        }
        if(grounded && jumping)
        {
            jumping = false;
            animator.SetBool("jump", false);
        }
        if (air)
        {
            animator.SetBool("air", true);
        }
        else
        {
            animator.SetBool("air", false);
        }
        if (angry)
        {
            animator.SetBool("angry", true);
        }
        else
        {
            animator.SetBool("angry", false);
        }
        if(selected && !selector)
        {
            selector = Instantiate(selectorPrefab, transform);
        }
        if( !selected && selector)
        {

            Destroy(selector);
            selector = null;

        }
    }

    private void Update()
    {

        if (getKilled)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                kill();
            }
        }

    }

}
