using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;
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
    SpriteRenderer myAvatarSprite;
    //Player Hat
    static Sprite myHatSprite;
    SpriteRenderer myHatHolder;
    //Role
    [SerializeField] bool isImposter;
    [SerializeField] InputAction KILL;
    float killInput;
    List<AU_PlayerController> targets;
    [SerializeField] Collider myCollider;
    bool isDead;
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
    PhotonView myPV;
    [SerializeField] GameObject lightMask;
    [SerializeField] lightcaster myLightCaster;
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
            return;
        }
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
        myAvatar.localScale = new Vector2(direction, 1);
        if (!myPV.IsMine)
            return;
        movementInput = WASD.ReadValue<Vector2>();
        myAnim.SetFloat("Speed", movementInput.magnitude);
        if (movementInput.x != 0)
        {
            direction = Mathf.Sign(movementInput.x);
            
        }
        
        if(allBodies.Count > 0)
        {
            BodySearch();
        }
        if(REPORT.triggered)
        {
            if (bodiesFound.Count == 0)
                return;
            Transform tempBody = bodiesFound[bodiesFound.Count - 1];
            allBodies.Remove(tempBody);
            bodiesFound.Remove(tempBody);
            tempBody.GetComponent<AU_Body>().Report();
        }
        mousePositionInput = MOUSE.ReadValue<Vector2>();
        
    }
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
                targets[targets.Count - 1].myPV.RPC("RPC_Kill", RpcTarget.All);
                targets.RemoveAt(targets.Count - 1);
            }
        }
    }

    [PunRPC]
    void RPC_Kill()
    {
        Die();
    }

    public void Die()
    {
        if (!myPV.IsMine)
            return;
        
        //AU_Body tempBody = Instantiate(bodyPrefab, transform.position, transform.rotation).GetComponent<AU_Body>();
        AU_Body tempBody = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "AU_Body"), transform.position, transform.rotation).GetComponent<AU_Body>();
        tempBody.SetColor(myAvatarSprite.color);
        isDead = true;
        myAnim.SetBool("IsDead", isDead);
        //edit
        gameObject.layer = 6;
        myCollider.enabled = false;
    }
    
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
                    temp.PlayMiniGame();
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
        }
        else
        {
            this.direction = (float)stream.ReceiveNext();
            this.isImposter = (bool)stream.ReceiveNext();
        }
    }

    public void BecomeImposter(int ImposterNumber)
    {
        if(PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[ImposterNumber])
        {
            isImposter = true;
        }
    }
    
}