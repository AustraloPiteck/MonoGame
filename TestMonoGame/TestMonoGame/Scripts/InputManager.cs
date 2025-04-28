using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonoGame.Scripts
{
    internal class InputManager: IUpdatableItem
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private KeyboardState _keyState;
        private MouseState _mouseState;

        public event Action<Vector2> _movementValue;
        public event Action<Vector2> _mousePosValue;
        private Vector2 _inputDelta;
        private Vector2 _inputMouseDelta;

        private Vector2 _currentMousePos;


     

        public void OnUpdate(float deltaTime)
        {
            _keyState = Keyboard.GetState();
            Horizontal = 0;
            Vertical = 0;

            if (_keyState.IsKeyDown(Keys.A)) Horizontal -= 1;
            if (_keyState.IsKeyDown(Keys.D)) Horizontal += 1;
            if (_keyState.IsKeyDown(Keys.W)) Vertical -= 1;
            if (_keyState.IsKeyDown(Keys.S)) Vertical += 1;
           

            if (Horizontal != _inputDelta.X || Vertical != _inputDelta.Y)
            {
                
                _inputDelta = new Vector2(Horizontal, Vertical);
                Vector2 normilizedVector = _inputDelta == Vector2.Zero 
                    ? Vector2.Zero 
                    :Vector2.Normalize(_inputDelta);
                _movementValue.Invoke(normilizedVector);
            }
            
            _mouseState = Mouse.GetState();
            _currentMousePos = _mouseState.Position.ToVector2();
            if (_currentMousePos != _inputMouseDelta)
            {
                _mousePosValue.Invoke(_currentMousePos);
                _inputMouseDelta = _currentMousePos;
            }
        }
    }
}
