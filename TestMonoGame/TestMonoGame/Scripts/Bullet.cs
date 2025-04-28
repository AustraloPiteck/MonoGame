using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.Threading.Tasks;

namespace TestMonoGame.Scripts
{
    internal class Bullet: IUpdatableItem
    {
        private Texture2D _bulletTexture => LoadSystem.PlayerBulletSprite;
        private readonly float _bulletSpeed = 600;
        private readonly Vector2 _bulletScale = new Vector2(1, 1);

        private Vector2 _position;
        private float _rotation;
        private Vector2 _origin;
        private float _deltaTime;
        private Vector2 _direction;

        private RenderItem _thisRenderItem;
       

        public Bullet(Vector2 startPos, float startRot, Game1 game)
        {
            _origin = new Vector2(_bulletTexture.Width / 2f,
                _bulletTexture.Height / 2f);
            _position = startPos;
            _direction = Vector2.Normalize(startPos);
            _rotation = startRot;

            _thisRenderItem = new RenderItem(_bulletTexture, () => _position,
                Color.White, () => _rotation, _origin, _bulletScale);
            game.AddToRenderQueue(_thisRenderItem);
            AwaitDeath(game);
        }

        private async void AwaitDeath(Game1 game)
        {
            await BulletMove();
            game.RemoveRender(_thisRenderItem);
            game.RemoveUpdatable(this);
            //ремуваем и уничтожаем
        }

        private async Task BulletMove()
        {
            float time = 0f;
            while(time < 4)
            {
                time += _deltaTime;
                _position += _direction * _bulletSpeed * _deltaTime;
                await Task.Yield();
            }
        }

        public void OnUpdate(float deltaTime)=>_deltaTime = deltaTime;
        
    }
}
