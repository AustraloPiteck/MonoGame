
using Microsoft.Xna.Framework;


namespace TestMonoGame.Scripts
{
    internal class BulletFabric
    {
        public Bullet Create(Vector2 startPos, float startRot, Game1 game)
        {
            Bullet bullet = new Bullet(startPos, startRot, game);
            game.AddUpdatable(bullet);
            return bullet;
        }
    }
}
