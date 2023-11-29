using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
<<<<<<< Updated upstream
=======
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
>>>>>>> Stashed changes
public class AU_PlayerController : MonoBehaviour, IPunObservable
{
    [SerializeField] bool hasControl;
    public static AU_PlayerController localPlayer;
    
    //Components
    Rigidbody myRB;
    Animator myAnim;
    Transform myAvatar;
    //Player movement
    [SerializeField] InputAction WASD;
    Vector2 movementInput;
    [SerializeField] float movementSpeed;

    float direction = 1;
    //Player Color
    //edit
    [SerializeField] static Color myColor;
    [SerializeField] public TMP_Text pUsername;
    SpriteRenderer myAvatarSprite;
    //Player Hat
    static Sprite myHatSprite;
    SpriteRenderer myHatHolder;
    //Role
    [SerializeField] public bool isImposter;
    [SerializeField] InputAction KILL;
    float killInput;
    List<AU_PlayerController> targets;
    [SerializeField] Collider myCollider;
<<<<<<< Updated upstream
    bool isDead;
=======
    [SerializeField] public bool isDead;
>>>>>>> Stashed changes
    [SerializeField] GameObject bodyPrefab;
    public static List<Transform> allBodies;
    List<Transform> bodiesFound;
    [SerializeField] InputAction REPORT;
    [SerializeField] LayerMask ignoreForBody;
    //Interaction
    [SerializeField] InputAction MOUSE;
    Vector2 mousePositionInput;
    Camera myCamera;
    [SerializeField] InputAction INTERACTION;
    [SerializeField] LayerMask interactLayer;
    //Networking
    public PhotonView myPV;
    [SerializeField] GameObject lightMask;
    [SerializeField] lightcaster myLightCaster;
<<<<<<< Updated upstream
=======
    [SerializeField] SpriteRenderer tempBodySprite;
    [SerializeField] SpriteRenderer tempPartSprite;
    public TMP_Text syncCheck;
    public TMP_Text syncCheckBR;
    [SerializeField] Button KB;
    [SerializeField] Button RB;

    [SerializeField] GameObject Stick;

    //public TaskBar task;

    //public int taskTimes;

    [SerializeField] int numDead;

    //[SerializeField] int tempDead;

    public AU_Body[] objectsOfType;

    bool SceneRan;
    public int voteCast;
    public int voteCast1;
    public int voteCast2;
    public int voteCast3;
    public int voteCast4;
    public int voteCast5;
    public int voteCast6;
    public int voteCast7;
    public int voteCast8;
    public int voteCast9;
    public int voteCast10;
    public int voteCastSkip;
    public int questCorr;

>>>>>>> Stashed changes
    private void Awake()
    {
        KILL.performed += KillTarget;
        INTERACTION.performed += Interact;
    }
    private void OnEnable()
    {
        WASD.Enable();
        KILL.Enable();
        REPORT.Enable();
        MOUSE.Enable();
        INTERACTION.Enable();
    }
    private void OnDisable()
    {
        WASD.Disable();
        KILL.Disable();
        REPORT.Disable();
        MOUSE.Disable();
        INTERACTION.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
        if(myPV.IsMine)
        {
            localPlayer = this;
        }
        

        //edit
        myCamera = transform.GetChild(2).GetComponent<Camera>();
        targets = new List<AU_PlayerController>();
        myRB = GetComponent<Rigidbody>();
        myAnim = GetComponent<Animator>();
        myAvatar = transform.GetChild(0);
        myAvatarSprite = myAvatar.GetComponent<SpriteRenderer>();
        myHatHolder = transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>();
        if (!myPV.IsMine)
        {
            myCamera.gameObject.SetActive(false);
            lightMask.SetActive(false);
            myLightCaster.enabled = false;
            RB.gameObject.SetActive(false);
            Stick.SetActive(false);
            return;
        }
        //numDead = 0;
        KB.gameObject.SetActive(false);
        if (myColor == Color.clear)
            myColor = Color.white;
        myAvatarSprite.color = myColor;
        if(allBodies == null)
        {
            allBodies = new List<Transform>();
        }
        bodiesFound = new List<Transform>();
        if (myHatSprite != null)
            myHatHolder.sprite = myHatSprite;
<<<<<<< Updated upstream
=======
        }
        if(myPV.IsMine)
        {
            SetColor(myColor);
        }
        
    }

    [PunRPC]
    void resetVote()
    {
        voteCast = 0;
        voteCast1 = 0;
        voteCast2 = 0;
        voteCast3 = 0;
        voteCast4 = 0;
        voteCast5 = 0;
        voteCast6 = 0;
        voteCast7 = 0;
        voteCast8 = 0;
        voteCast9 = 0;
        voteCast10 = 0;
        voteCastSkip = 0;
    }

    public void resetCasting()
    {
        myPV.RPC("resetVote", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote()
    {
        voteCast++;
    }

    public void voteCasting()
    {
        myPV.RPC("incVote", RpcTarget.AllBuffered);
    }


    [PunRPC]
    void incVote1()
    {
        voteCast1++;
    }

    public void voteCasting1()
    {
        myPV.RPC("incVote1", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote2()
    {
        voteCast2++;
    }

    public void voteCasting2()
    {
        myPV.RPC("incVote2", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote3()
    {
        voteCast3++;
    }

    public void voteCasting3()
    {
        myPV.RPC("incVote3", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote4()
    {
        voteCast4++;
    }

    public void voteCasting4()
    {
        myPV.RPC("incVote4", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote5()
    {
        voteCast5++;
    }

    public void voteCasting5()
    {
        myPV.RPC("incVote5", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote6()
    {
        voteCast6++;
    }

    public void voteCasting6()
    {
        myPV.RPC("incVote6", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote7()
    {
        voteCast7++;
    }

    public void voteCasting7()
    {
        myPV.RPC("incVote7", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote8()
    {
        voteCast8++;
    }

    public void voteCasting8()
    {
        myPV.RPC("incVote8", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote9()
    {
        voteCast9++;
    }

    public void voteCasting9()
    {
        myPV.RPC("incVote9", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVote10()
    {
        voteCast10++;
    }

    public void voteCasting10()
    {
        myPV.RPC("incVote10", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incVoteSkip()
    {
        voteCastSkip++;
    }

    public void voteCastingSkip()
    {
        myPV.RPC("incVoteSkip", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void incCorr()
    {
        questCorr++;
    }

    public void increaseCorrectAns()
    {
        myPV.RPC("incCorr", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void decCorr()
    {
        questCorr--;
    }

    public void decreaseCorrectAns()
    {
        myPV.RPC("decCorr", RpcTarget.AllBuffered);
    }

    [PunRPC]
    void resCorr()
    {
        questCorr = 0;
    }

    public void resetCorrectAns()
    {
        myPV.RPC("resCorr", RpcTarget.AllBuffered);
    }

    public void SetUsName(TMP_Text uName)
    {
        pUsername.text = uName.text;
        PhotonNetwork.NickName = pUsername.text;
        PhotonNetwork.LocalPlayer.NickName = PhotonNetwork.NickName;
        myPV.RPC("SyncName", RpcTarget.All,pUsername.text);
    }

    public void SetColor(Color newColor)
    {
        myColor = newColor;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
            int R;
            int G;
            int B;
            R = (int)(myColor.r * 255);
            G = (int)(myColor.g * 255);
            B = (int)(myColor.b * 255);
            myPV.RPC("SyncColor", RpcTarget.All, R, G, B); // Sync color across network
        }
    }

    // public void SetColor(Color newColor)
    // {
    //     myColor = newColor;
    //     if (myAvatarSprite != null)
    //     {
    //         myAvatarSprite.color = myColor;
    //     }
    // }

    // RPC to synchronize color across all players
    [PunRPC]
    void SyncColor(int R, int G, int B)
    {
        float floatRed = R / 255f;
        float floatGreen = G / 255f;
        float floatBlue = B / 255f;
        Color reconstructedColor = new Color(floatRed, floatGreen, floatBlue);
        myColor = reconstructedColor;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
>>>>>>> Stashed changes
    }

    [PunRPC]
    void SyncName(string name)
    {
        pUsername.text = name;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
    }

    

    void BodySearch()
    {
        foreach(Transform body in allBodies)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, body.position - transform.position);
            Debug.DrawRay(transform.position, body.position - transform.position, Color.cyan);
            if(Physics.Raycast(ray, out hit, 1000f, ~ignoreForBody))
            {
                
                if (hit.transform == body)
                {
                    Debug.Log(hit.transform.name);
                    Debug.Log(bodiesFound.Count);
                    if (bodiesFound.Contains(body.transform))
                        return;
                    bodiesFound.Add(body.transform);
                }
                else
                {
                    
                    bodiesFound.Remove(body.transform);
                }
            }
        }
    }
    // Update is called once per frame
     void Update()
    {
        if(allBod.Count == 0)
        {
            if(bodiesFound != null)
            {
                if(bodiesFound.Count != 0)
                {
                    bodiesFound.Clear();
                }
            }
            
        }
        myAvatar.localScale = new Vector2(direction, 1);
        if (!myPV.IsMine)
            return;
        movementInput = WASD.ReadValue<Vector2>();
        myAnim.SetFloat("Speed", movementInput.magnitude);
        if (movementInput.x != 0)
        {
            direction = Mathf.Sign(movementInput.x);
            
        }
<<<<<<< Updated upstream
        
        if(allBodies.Count > 0)
        {
            BodySearch();
=======
        syncCheck.text = allBod.Count.ToString();
        syncCheckBR.text = bodiesFound.Count.ToString();
        // if(allBodies.Count > 0)
        // {
        //     BodySearch();
        // }
        if(isImposter == true)
        {
            //Debug.Log("How");
            if(myPV.IsMine)
            {
                KB.gameObject.SetActive(true);
            }
        }
        // if(taskTimes == 0)
        // {
        //     if(SceneManager.GetActiveScene().buildIndex == 2)
        //     {
        //         //access to taskbar
        //         GameObject tasks = GameObject.Find("RawImage");
        //         task = tasks.GetComponent<TaskBar>();
        //         taskTimes++;
        //     }
        // }
        if(SceneRan == false)
        {
            objectsOfType = FindObjectsOfType<AU_Body>();
            numDead = objectsOfType.Length;
        }


        if(PhotonNetwork.PlayerList.Length - numDead == 0)
        {
            if(PhotonNetwork.PlayerList.Length != 1)
            {
                numDead = 0;
                PhotonNetwork.AutomaticallySyncScene = true;
                PhotonNetwork.LoadLevel(4);
                SceneRan = true;
            }
>>>>>>> Stashed changes
        }
        if(REPORT.triggered)
        {
            if (bodiesFound.Count == 0)
            {
                return;
            }
            if(isDead == true)
            {
                return;
            }
            Transform tempBody = bodiesFound[bodiesFound.Count - 1];
<<<<<<< Updated upstream
            allBodies.Remove(tempBody);
            bodiesFound.Remove(tempBody);
            tempBody.GetComponent<AU_Body>().Report();
=======
            // allBodies.Clear();
            // foreach (AU_Body bod in allBod){
            //     tempBodySprite = bod.bodySprite;
            //     tempPartSprite = bod.partSprite;
            myPV.RPC("RPC_disableBody", RpcTarget.All);
            // }
            // allBod.Clear();
            //bodiesFound.Clear();
            
            //tempBody.GetComponent<AU_Body>().Report();
            myPV.RPC("enableVote", RpcTarget.AllBuffered);
>>>>>>> Stashed changes
        }
        mousePositionInput = MOUSE.ReadValue<Vector2>();
        
    }
<<<<<<< Updated upstream
=======

    [PunRPC]
    void RPC_disableBody()
    {
        
        allBodies.Clear();
        foreach (AU_Body bod in allBod){
            tempBodySprite = bod.bodySprite;
            tempPartSprite = bod.partSprite;
            tempBodySprite.enabled = false;
            tempPartSprite.enabled = false;
            bod.sphereCollider.enabled = false;
            //Debug.Log("Destroy");
        }
        allBod.Clear();
        if(bodiesFound != null)
        {
            bodiesFound.Clear();
        }
        else
        {
            bodiesFound = new List<Transform>();
            bodiesFound.Clear();
        }
        // WASD.Disable();
        // KILL.Disable();
        // REPORT.Disable();
        // INTERACTION.Disable();

        
    }
>>>>>>> Stashed changes
    private void FixedUpdate()
    {
        if (!myPV.IsMine)
            return;
        myRB.velocity = movementInput * movementSpeed;
    }
    public void SetColor(Color newColor)
    {
        myColor = newColor;
        if (myAvatarSprite != null)
        {
            myAvatarSprite.color = myColor;
        }
    }
    public void SetHat(Sprite newHat)
    {
        myHatSprite = newHat;
        myHatHolder.sprite = myHatSprite;
    }
    public void SetRole(bool newRole)
    {
        isImposter = newRole;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AU_PlayerController tempTarget = other.GetComponent<AU_PlayerController>();
            if (isImposter)
            {
                if (tempTarget.isImposter)
                    return;
                else
                {
                    targets.Add(tempTarget);
                    
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            AU_PlayerController tempTarget = other.GetComponent<AU_PlayerController>();
            if (targets.Contains(tempTarget))
            {
                    targets.Remove(tempTarget);
            }
        }
    }
    void KillTarget(InputAction.CallbackContext context)
    {

        if (!myPV.IsMine)
            return;
        if (!isImposter)
            return;

        if (context.phase == InputActionPhase.Performed)
        {
            if (targets.Count == 0)
                return;
            else
            {
                if (targets[targets.Count - 1].isDead)
                    return;
                transform.position = targets[targets.Count - 1].transform.position;
                //targets[targets.Count - 1].Die();
                //myPV.RPC("RPC_AddKill", RpcTarget.All);
                targets[targets.Count - 1].myPV.RPC("RPC_Kill", RpcTarget.All);
                targets.RemoveAt(targets.Count - 1);
            }
        }
    }

<<<<<<< Updated upstream
=======

    // [PunRPC]
    // void SetDeadValue(int newValue)
    // {
    //     numDead = newValue;
    //     //Debug.Log("p1 updated to: " + p1);
    // }

    // // Example method to trigger the synchronization
    // public void TriggerSynchronization(int newValue)
    // {
    //     // Check if it's the local player's view
    //     if (myPV.IsMine)
    //     {   
            
    //         myPV.RPC("SetDeadValue", RpcTarget.AllBuffered, newValue);
    //     }
    // }

>>>>>>> Stashed changes
    [PunRPC]
    public void RPC_Kill()
    {
        Die();
    }

    public void Die()
    {
        Transform child1;
        Transform child2;
        Camera CM;
        child1 = gameObject.transform.GetChild(0);
        child2 = child1.transform.GetChild(0);
        CM = gameObject.transform.GetChild(2).GetComponent<Camera>();
        if (!myPV.IsMine)
        {
            isDead = true;
            child1.gameObject.layer = 8;
            child2.gameObject.layer = 8;
            return;
        }
        //AU_Body tempBody = Instantiate(bodyPrefab, transform.position, transform.rotation).GetComponent<AU_Body>();
        AU_Body tempBody = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "AU_Body"), transform.position, transform.rotation).GetComponent<AU_Body>();
        tempBody.SetColor(myAvatarSprite.color);
<<<<<<< Updated upstream
=======
        //edit

        //gameObject.layer = 8;
        int newCullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "OtherSide", "Ghost");
        CM.cullingMask = newCullingMask;
        child1.gameObject.layer = 8;
        child2.gameObject.layer = 8;
        myCollider.enabled = false;
        //allBod.Add(tempBody);
        //Debug.Log("bodies num: " + allBod.Count);
>>>>>>> Stashed changes
        isDead = true;
        myAnim.SetBool("IsDead", isDead);
        //edit
        gameObject.layer = 6;
        myCollider.enabled = false;
    }
    
<<<<<<< Updated upstream
=======
    [PunRPC]
    void enableVote()
    {
        GameObject.Find("Canvas").transform.Find("Voting").gameObject.SetActive(true);
    }

    public void timeToVote()
    {
        myPV.RPC("enableVote", RpcTarget.AllBuffered);
    }
    
>>>>>>> Stashed changes
    void Interact(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("Here");
            RaycastHit hit;
            Ray ray = myCamera.ScreenPointToRay(mousePositionInput);
            if (Physics.Raycast(ray, out hit,interactLayer))
            {
                if (hit.transform.tag == "Interactable")
                {
                    AU_Interactable temp = hit.transform.GetComponent<AU_Interactable>();
<<<<<<< Updated upstream
                    temp.PlayMiniGame();
=======
                    if(temp.name == "VoteInteract")
                    {
                        myPV.RPC("enableVote", RpcTarget.AllBuffered);
                    }
                    else
                    {
                        //Debug.Log("function not called");
                        temp.PlayMiniGame();
                    }
>>>>>>> Stashed changes
                }
                /*
                if(hit.transform.tag == "Vent")
                {
                    //myAnim.SetBool("Vented", true);
                    AU_Interactable temp = hit.transform.GetComponent<AU_Interactable>();
                    temp.PlayMiniGame();
                }
                */
            }
           
        }
        
    }
    
    /*
    public void ExitVent()
    {
        //myAnim.SetBool("Vented", false);
    }*/

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(direction);
            stream.SendNext(isImposter);
<<<<<<< Updated upstream
=======
            //stream.SendNext(numDead);
            //stream.SendNext(myColor);
            //stream.SendNext(myColor);
            //Debug.Log("send");
>>>>>>> Stashed changes
        }
        else
        {
            this.direction = (float)stream.ReceiveNext();
            this.isImposter = (bool)stream.ReceiveNext();
<<<<<<< Updated upstream
=======
            //this.numDead = (int)stream.ReceiveNext();
            //myColor = (Color)stream.ReceiveNext();
            //this.myColor = (Color)stream.ReceiveNext();
            //Debug.Log("do Something");
            //Debug.Log((bool)stream.ReceiveNext());
>>>>>>> Stashed changes
        }
    }

    public void BecomeImposter(int ImposterNumber)
    {
        if(PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[ImposterNumber])
        {
<<<<<<< Updated upstream
            isImposter = true;
=======
            //Debug.Log(isImposter);
            isImposter = true;
            //Debug.Log(isImposter);
>>>>>>> Stashed changes
        }
    }
    
}