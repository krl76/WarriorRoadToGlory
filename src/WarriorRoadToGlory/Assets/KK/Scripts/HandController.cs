using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator _animatorLeft;
    [SerializeField] private Animator _animatorRight;

    [Header("Attach")]
    [SerializeField] private GameObject _attachShield;
    
    private InputController inputController;
    private bool isLeftAttach = false;
    private bool isTake;
    private string whichTake;
    private void Awake()
    {
        inputController = new InputController();

        inputController.RightHand.Grip.started += ctx => Grip(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Grip.canceled += ctx => Grip(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Fist.started += ctx => Fist(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Fist.canceled += ctx => Fist(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Pointing.started += ctx => Pointing(ctx.ReadValueAsButton(), "Right");
        inputController.RightHand.Pointing.canceled += ctx => Pointing(ctx.ReadValueAsButton(), "Right");
        
        inputController.LeftHand.Grip.started += ctx => Grip(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Grip.canceled += ctx => Grip(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Fist.started += ctx => Fist(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Fist.canceled += ctx => Fist(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Pointing.started += ctx => Pointing(ctx.ReadValueAsButton(), "Left");
        inputController.LeftHand.Pointing.canceled += ctx => Pointing(ctx.ReadValueAsButton(), "Left");
    }

    private void OnEnable()
    {
        inputController.Enable();
    }

    private void OnDisable()
    {
        inputController.Disable();
    }

    private void Grip(bool isGrip, string hand)
    {
        if (hand == "Right")
        {
            _animatorRight.SetBool("Grip", isGrip);
        }
        else
        {
            _animatorLeft.SetBool("Grip", isGrip);
        }
    }

    private void Fist(bool isFist, string hand)
    {
        if (hand == "Right")
        {
            _animatorRight.SetBool("Fist", isFist);
        }
        else
        {
            _animatorLeft.SetBool("Fist", isFist);
        }
    }
    
    private void Pointing(bool isPointing, string hand)
    {
        if (hand == "Right")
        {
            _animatorRight.SetBool("Pointing", isPointing);
        }
        else
        {
            _animatorLeft.SetBool("Pointing", isPointing);
        }
    }

    private void Update()
    {
        if(whichTake == "Right Controller")
            _animatorRight.SetBool("Grip", isTake);
        if(whichTake == "Left Controller")
            _animatorLeft.SetBool("Grip", isTake);
    }

    public void Take(SelectEnterEventArgs enterEvent)
    {
        isTake = true;
        whichTake = enterEvent.interactorObject.transform.name;
    }

    public void TakeShield(SelectEnterEventArgs enterEvent)
    {
       if(enterEvent.interactorObject.transform.name == "Left Controller" && !isLeftAttach)
        {
            _attachShield.transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            isLeftAttach = true;
        }
       if (enterEvent.interactorObject.transform.name == "Right Controller" && isLeftAttach)
        {
            _attachShield.transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
            isLeftAttach = false;
        }
    }

    public void TakeOff(SelectExitEventArgs exitEvent)
    {
        isTake = false;
        whichTake = "";
    }
}
