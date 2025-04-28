using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace TestMonoGame.Scripts
{
    internal class PlayerController: IUpdatableItem, IMovable
    {
        private readonly float _speed = 1.5f;

        private Texture2D _playerTexture => LoadSystem.PlayerSprite;
        private Vector2 _directionMove;
        private Vector2 _playerPosition;
        private float _playerRotation;
        private Vector2 _playerOrigin;
      

        public PlayerController(Game1 mainGame)
        {
            mainGame.AddToRenderQueue(new RenderItem(_playerTexture, ref _playerPosition,
                Color.White, ref _playerRotation, ref _playerOrigin));
        }

        public void MoveInput(Vector2 value)
        {
            _directionMove = value;
        }

        public void OnUpdate(float deltaTime)
        {
           Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            if(_directionMove == Vector2.Zero)return;

            _playerOrigin = _playerPosition +
                new Vector2(_playerTexture.Width, _playerTexture.Height) / 2;

            _playerPosition += _directionMove * _speed * deltaTime;
        }

    
    }
}
