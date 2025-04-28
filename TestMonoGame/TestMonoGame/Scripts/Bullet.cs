using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TestMonoGame.Scripts
{
    internal class Bullet: IUpdatableItem
    {
        private Texture2D _bulletTexture => LoadSystem.PlayerBulletSprite;
        private readonly float _bulletSpeed = 1750;
        private readonly Vector2 _bulletScale = new Vector2(0.1f, 0.1f);
        private readonly Vector2 _bulletOffset = new Vector2(100f,10f);
        private readonly Vector2 _bulletOffsetRot = new Vector2(-0.2f, 0.2f);

        private Vector2 _position;
        private float _rotation;
        private Vector2 _origin;
        private Vector2 _direction;

        private RenderItem _thisRenderItem;
        private float _time;
        private Game1 _game;


        public Bullet(Vector2 startPos, float startRot, Game1 game)
        {
            _game = game;
            _origin = new Vector2(_bulletTexture.Width / 2f,
                _bulletTexture.Height / 2f);

            _position = startPos + new Vector2(
            (float)Math.Cos(startRot) * _bulletOffset.X - (float)Math.Sin(startRot) * _bulletOffset.Y,
            (float)Math.Sin(startRot) * _bulletOffset.X + (float)Math.Cos(startRot) * _bulletOffset.Y
);

            Random random = new Random();
            float randVal = (float)(random.NextDouble() * 
                (_bulletOffsetRot.Y - _bulletOffsetRot.X) + _bulletOffsetRot.X);
            
            _direction = new Vector2((float)Math.Cos(startRot+randVal),
              (float)Math.Sin(startRot+randVal));

           
            _rotation = startRot;

            _thisRenderItem = new RenderItem(_bulletTexture, () => _position,
                Color.White, () => _rotation, _origin,
                _bulletScale, (SpriteEffects.FlipHorizontally, SpriteEffects.None));
            game.AddToRenderQueue(_thisRenderItem);

        }

     
        public void OnUpdate(float deltaTime)
        {
            _time += deltaTime;
            if (_time < 1.5f)
            {
                _position += _direction * _bulletSpeed * deltaTime;
            }
            else 
            {
                _game.RemoveRender(_thisRenderItem);
                _game.RemoveUpdatable(this);
            }
          
        }
        
    }
}
