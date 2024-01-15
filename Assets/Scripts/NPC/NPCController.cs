using System;
using UnityEngine;
using UnityEngine.Events;

public class NPCController : MonoBehaviour
{
    public static event EventHandler<OnNPCStartTalkArgument> OnNPCStartTalk;
    public class OnNPCStartTalkArgument : EventArgs
    {
        public Dialogue dialogue;
        public bool isShopNPC;
    }
    [SerializeField]
    public Dialogue dialogue;
    private UnityEvent onClickEvent = new UnityEvent();
    public bool isActiveTalk = false;

    private bool isFacingRight = true;

    private void OnEnable()
    {
        
    }

    private void GameInput_OnTalkAction(object sender, System.EventArgs e)
    {
        if (isActiveTalk)
        {
            onClickEvent.Invoke();
        }
    }

    private void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        
    }

    public void StartTalk(Vector3 position)
    {
        if(transform.position.x < position.x && !isFacingRight)
        {
            Flip();
        }else if(transform.position.x > position.x && isFacingRight)
        {
            Flip();
        }
        OnNPCStartTalk?.Invoke(this, new OnNPCStartTalkArgument { dialogue=this.dialogue});
    }

   
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
