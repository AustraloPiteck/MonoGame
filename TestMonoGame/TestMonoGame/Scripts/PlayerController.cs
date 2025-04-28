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
     //   private readonly float _rotatingSpeed = 800f;
        private readonly Vector2 _scale = new Vector2(0.2f, 0.2f);
        private readonly Vector2 _offsetOrigin = new Vector2(-200f, 0);

        private Texture2D _playerTexture => LoadSystem.PlayerSprite;
        private Vector2 _directionMove;
        private Vector2 _playerPosition;
        private float _playerRotation;
        private Vector2 _playerOrigin;
        private Game1 _mainGame;

        private Vector2 _mousePos;

        
        private BulletFabric _bulletFabric;
        
      
        
        public PlayerController(Game1 mainGame)
        {
            _mainGame = mainGame;
            _bulletFabric = new BulletFabric();
            LoadSystem.OnLoadCompleted += WaitAntilLoad;
        }

        private void WaitAntilLoad()
        {
            _playerOrigin = new Vector2(_playerTexture.Width / 2f,
                _playerTexture.Height / 2f)+_offsetOrigin;

            _mainGame.AddToRenderQueue(new RenderItem(_playerTexture,() => _playerPosition,
                Color.White,() => _playerRotation, _playerOrigin, _scale));
        }
       

        public void MoveInput(Vector2 value)=>_directionMove = value;
        public void MouseInput(Vector2 value)=>_mousePos = value;

        public void OnUpdate(float deltaTime)
        {
           Rotate(deltaTime);
           Move(deltaTime);
        }

        private void Move(float deltaTime)
        {
            if (_directionMove == Vector2.Zero) return;
            _playerPosition += _directionMove * _speed * deltaTime;
            
        }

        public void OnShoot()
        {
            _bulletFabric.Create(_playerPosition, _playerRotation,_mainGame);
        }

        private void Rotate(float deltaTime)
        {
            float directionRotation = GetAngleToMouse();
            _playerRotation = directionRotation;
          //  if (_playerRotation == directionRotation) return;
           // _playerRotation += GetSign(directionRotation) 
               // * _rotatingSpeed * deltaTime;
        }

       /* private int GetSign(float value)
        {
            if (value < 0) return -1;
            else if (value >= 0) return 1;
            return 0;
        }*/

        private float GetAngleToMouse()
        {
            return (float)Math.Atan2(_mousePos.Y - _playerPosition.Y,
                                  _mousePos.X - _playerPosition.X);
        }
    }
}
