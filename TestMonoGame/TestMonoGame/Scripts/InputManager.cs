using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonoGame.Scripts
{
    internal class InputManager: IUpdatableItem
    {
        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }

        private readonly KeyboardState _keyState;

        public event Action<Vector2> _movementValue;
        private Vector2 _inputDelta;

        public InputManager() 
        { 
            _keyState = Keyboard.GetState();
        }

        public void OnUpdate(float deltaTime)
        {
            Horizontal = 0;
            Vertical = 0;

            if (_keyState.IsKeyDown(Keys.A)) Horizontal -= 1;
            if (_keyState.IsKeyDown(Keys.D)) Horizontal += 1;
            if (_keyState.IsKeyDown(Keys.W)) Vertical -= 1;
            if (_keyState.IsKeyDown(Keys.S)) Vertical += 1;

            if(Horizontal != _inputDelta.X || Vertical != _inputDelta.Y)
            {
                _inputDelta = new Vector2(Horizontal, Vertical);
                _movementValue.Invoke(_inputDelta);
            }
        }
    }
}
