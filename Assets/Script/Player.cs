using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    #region//publicïœêî
    public GameObject menuPanel;
    public Sprite normal;
    public Sprite fly;
    public Sprite heavy;
    public Sprite goal;
    public AudioClip Equip;
    public AudioClip Freedom;
    public AudioClip Jump;
    public float speed;
    public float jumpSpeed;
    public GroundCheck ground;
    public bool isGoal = false;
    #endregion

    #region//privateïœêî
    private SpriteRenderer sr = null;
    private Rigidbody2D rb = null;
    private GameObject SE;
    private bool isGround = false;
    private bool isMenu = false;
    public bool onParts1 = false;
    public bool onParts2 = false;
    public bool onGoal = false;
    private bool jumped = false;
    private string parts1tag = "Parts1";
    private string parts2tag = "Parts2";
    private string goaltag = "Goal";
    public enum PlayerMode
    {
        NORMAL,
        FLY,
        HEAVY,
        GOAL
    };
    public PlayerMode pMode = PlayerMode.NORMAL;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        SE = GameObject.Find("SEManager");
    }

    // Update is called once per frame
    void Update()
    {
        isGround = ground.IsGround();
        if(!isMenu)
        {
            float xSpeed = GetXSpeed() * Time.timeScale;
            float ySpeed = GetYSpeed() * Time.timeScale;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isMenu = true;
                Time.timeScale = 0.0f;
                menuPanel.SetActive(true);
            }
            EquipParts();

            rb.velocity = new Vector2(xSpeed, ySpeed);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isMenu = false;
                Time.timeScale = 1.0f;
                menuPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1.0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }

    /// <summary>
    /// PlayerÇÃXê¨ï™ÇÃë¨Ç≥ÇéÊìæ
    /// </summary>
    /// <returns>PlayerÇÃXê¨ï™ÇÃë¨Ç≥</returns>
    float GetXSpeed()
    {
        float xSpeed = 0.0f;
        if (Input.GetKey(KeyCode.A))
        {
            if (pMode == PlayerMode.HEAVY)
            {
                xSpeed = -speed * 0.8f;
            }
            else
            {
                xSpeed = -speed;
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (pMode == PlayerMode.HEAVY)
            {
                xSpeed = speed * 0.8f;
            }
            else
            {
                xSpeed = speed;
            }
        }
        else
        {
            xSpeed = 0.0f;
        }
        return xSpeed;
    }

    /// <summary>
    /// PlayerÇÃYê¨ï™ÇÃë¨Ç≥ÇéÊìæ
    /// </summary>
    /// <returns>PlayerÇÃYê¨ï™ÇÃë¨Ç≥</returns>
    float GetYSpeed()
    {
        float ySpeed = rb.velocity.y;
        if (isGround)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if(!jumped)
                {
                    SE.GetComponent<ChangeSEVolume>().PlaySE(Jump);
                }
                jumped = true;
                if (pMode == PlayerMode.FLY)
                {
                    ySpeed = jumpSpeed * 1.25f;
                }
                else if(pMode == PlayerMode.HEAVY)
                {
                    ySpeed = jumpSpeed * 0.75f;
                }
                else ySpeed = jumpSpeed;
            }
        }
        else
        {
            jumped = false;
        }
        return ySpeed;
    }

    /// <summary>
    /// PlayerModeÇ…âûÇ∂ÇΩèdóÕÇÃílÇÃê›íË
    /// </summary>
    void setGravity()
    {
        if (pMode == PlayerMode.HEAVY)
        {
            rb.gravityScale = 2.0f;
        }
        else
        {
            rb.gravityScale = 2.0f;
        }
    }

    /// <summary>
    /// óéâ∫ÇµÇƒÇ¢ÇÈPartsÇÃëïíÖÅAÇ®ÇÊÇ—PlayerModeÇÃä«óù
    /// </summary>
    void EquipParts()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(pMode == PlayerMode.NORMAL)
            {
                if(onGoal)
                {
                    SE.GetComponent<ChangeSEVolume>().PlaySE(Freedom);
                    pMode = PlayerMode.GOAL;
                    sr.sprite = goal;
                    GameObject[] parts = GameObject.FindGameObjectsWithTag(goaltag);
                    foreach (GameObject part in parts)
                    {
                        Destroy(part);
                    }
                    //GManager.instance.Goal = true;
                    isGoal = true;
                }
                else if(onParts1)
                {
                    SE.GetComponent<ChangeSEVolume>().PlaySE(Equip);
                    pMode = PlayerMode.FLY;
                    sr.sprite = fly;
                    GameObject[] parts = GameObject.FindGameObjectsWithTag(parts1tag);
                    foreach (GameObject part in parts)
                    {
                        Destroy(part);
                    }
                }
                else if(onParts2)
                {
                    SE.GetComponent<ChangeSEVolume>().PlaySE(Equip);
                    pMode = PlayerMode.HEAVY;
                    sr.sprite = heavy;
                    GameObject[] parts = GameObject.FindGameObjectsWithTag(parts2tag);
                    foreach (GameObject part in parts)
                    {
                        Destroy(part);
                    }
                }
            }
            else if(pMode == PlayerMode.FLY)
            {
                SE.GetComponent<ChangeSEVolume>().PlaySE(Equip);
                pMode = PlayerMode.NORMAL;
                sr.sprite = normal;
                GameObject obj = (GameObject)Resources.Load("Parts1");
                GameObject instance = (GameObject)Instantiate(obj, this.transform.position, Quaternion.identity);
            }
            else if (pMode == PlayerMode.HEAVY)
            {
                SE.GetComponent<ChangeSEVolume>().PlaySE(Equip);
                pMode = PlayerMode.NORMAL;
                sr.sprite = normal;
                GameObject obj = (GameObject)Resources.Load("Parts2");
                GameObject instance = (GameObject)Instantiate(obj, this.transform.position, Quaternion.identity);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == parts1tag)
        {
            onParts1 = true;
        }
        if (collision.tag == parts2tag)
        {
            onParts2 = true;
        }
        if (collision.tag == goaltag)
        {
            onGoal = true;
        }
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == parts1tag)
        {
            onParts1 = true;
        }
        if (collision.tag == parts2tag)
        {
            onParts2 = true;
        }
        if (collision.tag == goaltag)
        {
            onGoal = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == parts1tag)
        {
            onParts1 = false;
        }
        if (collision.tag == parts2tag)
        {
            onParts2 = false;
        }
        if (collision.tag == goaltag)
        {
            onGoal = false;
        }
    }
}
