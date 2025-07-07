using System;
using Unity.VisualScripting;
using UnityEngine;
public class Player : MonoBehaviour, IKitchenObjectParent
{
    public static Player Instance { get; private set; }
    public event EventHandler OnPickedSomething;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float rotateSpeed = 15f;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask countersLayerMask;
    private Vector3 lastMoveDirection;
    private bool isWalking;
    private KitchenObject kitchenObject;
    public Transform kitchenObjectHoldPoint;
    private BaseCounter selectedCounter;
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public BaseCounter selectedCounter;
    }
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Only one instance of Player is allowed");
        }

        Instance = this;
    }
    void Start()
    {
        gameInput.onInteractAction += GameInput_onInteractAction;
        gameInput.onInteractAlternateAction += GameInput_onInteractAlternateAction;
    }
    private void GameInput_onInteractAction(object sender, System.EventArgs e)
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }
    private void GameInput_onInteractAlternateAction(object sender, System.EventArgs e)
    {
        if (!GameManager.Instance.IsGamePlaying()) return;
        if (selectedCounter != null)
        {
            if (selectedCounter is IInteractableAlternate interactableAlternate)
            {
                interactableAlternate.InteractAlternate(this);
            }
        }
    }
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }
    private void HandleInteractions()
    {
        var inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        float interactDistance = 2f;

        if (moveDir != Vector3.zero)
            lastMoveDirection = moveDir;

        if (Physics.Raycast(transform.position, lastMoveDirection, out RaycastHit raycastHit, interactDistance, countersLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {

                if (baseCounter != selectedCounter)
                {
                    SetSelectedCounter(baseCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }
    private void HandleMovement()
    {
        var inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        var playerSize = .6f;
        var playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + playerHeight * Vector3.up, playerSize, moveDir, (moveSpeed * Time.deltaTime));
        if (!canMove)
        {
            var moveDirX = new Vector3(moveDir.x, 0f, 0f).normalized;
            canMove = (moveDir.x < -.5f || moveDir.x > +.5f) && !Physics.CapsuleCast(transform.position, transform.position + playerHeight * Vector3.up, playerSize, moveDirX, (moveSpeed * Time.deltaTime));
            if (canMove)
                moveDir = moveDirX;
            else
            {
                var moveDirZ = new Vector3(0f, 0f, moveDir.z).normalized;
                canMove = (moveDir.z < -.5f || moveDir.z > +.5f) && !Physics.CapsuleCast(transform.position, transform.position + playerHeight * Vector3.up, playerSize, moveDirZ, (moveSpeed * Time.deltaTime));
                if (canMove)
                    moveDir = moveDirZ;
            }
        }
        if (canMove)
        {
            transform.position += moveDir * (moveSpeed * Time.deltaTime);
        }
        isWalking = moveDir != Vector3.zero;
        if (isWalking)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);
        }
        
    }    
    public bool IsWalking()
    {
        return isWalking;
    }
    private void SetSelectedCounter(BaseCounter counter)
    {
        this.selectedCounter = counter;
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs()
        {
            selectedCounter = counter
        });
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return kitchenObjectHoldPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
        if (kitchenObject != null)
        {
            OnPickedSomething?.Invoke(this, EventArgs.Empty);
        }
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}