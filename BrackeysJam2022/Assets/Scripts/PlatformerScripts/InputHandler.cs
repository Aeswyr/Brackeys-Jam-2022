using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : Singleton<InputHandler>
{
    public Vector2 dir {
        get;
        private set;
    }
    public Vector2 mousePos {
        get;
        private set;
    }

    public Vector2 mouseDelta {
        get;
        private set;
    }
    private ButtonState m_mouseLeft;
    public ButtonState mouseLeft {
        get{return m_mouseLeft;}
    }
    private ButtonState m_move;
    public ButtonState move {
        get{return m_move;}
    }
    private ButtonState m_jump;
    public ButtonState jump {
        get{return m_jump;}
    }

    private ButtonState m_interact;
    public ButtonState interact {
        get {return m_interact;}
    }

    private ButtonState m_menu;
    public ButtonState menu {
        get {return m_menu;}
    }

    private ButtonState m_special;
    public ButtonState special {
        get{return m_special;}
    }

    private ButtonState m_bomb;
    public ButtonState bomb {
        get{return m_bomb;}
    }

    private void FixedUpdate() {
        this.m_move.Reset();
        this.m_jump.Reset();
        this.m_interact.Reset();
        this.m_menu.Reset();
        this.m_special.Reset();
        this.m_bomb.Reset();
        this.m_mouseLeft.Reset();
    }

    public void PointerPos(InputAction.CallbackContext ctx) {
        this.mousePos = ctx.ReadValue<Vector2>();
    }

    public void PointerDelta(InputAction.CallbackContext ctx) {
        this.mouseDelta = ctx.ReadValue<Vector2>();
    }

    public void MouseLeft(InputAction.CallbackContext ctx) {
        this.m_mouseLeft.Set(ctx);
    }

    public void Move(InputAction.CallbackContext ctx) {
        this.dir = ctx.ReadValue<Vector2>();
        this.m_move.Set(ctx);
    }

    public void Jump(InputAction.CallbackContext ctx) {
        this.m_jump.Set(ctx);
    }
    public void Interact(InputAction.CallbackContext ctx) {
        this.m_interact.Set(ctx);
    }

    public void Menu(InputAction.CallbackContext ctx) {
        this.m_menu.Set(ctx);
    }

    public void Special(InputAction.CallbackContext ctx) {
        this.m_special.Set(ctx);
    }

    public void Bomb(InputAction.CallbackContext ctx) {
        this.m_bomb.Set(ctx);
    }

    public struct ButtonState {
        private bool firstFrame;
        public bool down {
            get;
            private set;
        }
        public bool pressed {
            get {
                return down && firstFrame;
            }
        }
        public bool released {
            get {
                return !down && firstFrame;
            }
        }

        public void Set(InputAction.CallbackContext ctx) {
            down = !ctx.canceled;             
            firstFrame = true;
        }
        public void Reset() {
            firstFrame = false;
        }
    }
}
