using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Threading.Tasks;


namespace TestMonoGame.Scripts
{
    internal class PlayerController: IUpdatableItem, IMovable
    {
        private readonly float _speed = 800f;
        private readonly Vector2 _scale = new Vector2(0.2f, 0.2f);

        private Texture2D _playerTexture => LoadSystem.PlayerSprite;
        private Vector2 _directionMove;
        private Vector2 _playerPosition;
        private float _playerRotation;
        private Vector2 _playerOrigin;
        private Game1 _mainGame;
      
        
        public PlayerController(Game1 mainGame)
        {
           _mainGame = mainGame;
            LoadSystem.OnLoadCompleted += WaitAntilLoad;
        }

        private void WaitAntilLoad()
        {
            _mainGame.AddToRenderQueue(new RenderItem(_playerTexture,() => _playerPosition,
                Color.White,() => _playerRotation, () => _playerOrigin, _scale));
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
            if (_directionMove == Vector2.Zero) return;
            _playerPosition += _directionMove * _speed * deltaTime;
            _playerOrigin = _playerPosition +
               new Vector2(_playerTexture.Width, _playerTexture.Height) / 2;
        }
    }
}
