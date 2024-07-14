using UnityEngine;
using UnityEngine.InputSystem;

public class InputController
{

    private CustomInput input;


    public bool Run { get => input.player.move.IsPressed();}
    
    public bool Punch { get => input.player.punch.IsPressed(); }
    public bool Getter { get => input.player.getter.IsPressed(); }

    private InputAction.CallbackContext ctx;

    public InputAction.CallbackContext Context { get { return ctx; } }

    public InputController() {
        input = new CustomInput();

        input.player.move.performed += ctx => UpdateContext(ctx);

        input.Enable();
    }
    ~InputController()
    {
        input.Disable();
    }

    public void UpdateContext(InputAction.CallbackContext ctx)
    {
        this.ctx = ctx;
    }
}
