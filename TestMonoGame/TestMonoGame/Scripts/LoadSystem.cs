
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using System.Net.Mime;
using System.Threading.Tasks;

namespace TestMonoGame.Scripts
{
    internal static class LoadSystem
    {
        public static Texture2D PlayerSprite {  get; private set; }
        public static Texture2D PlayerBulletSprite {  get; private set; }

        public static event Action OnLoadCompleted;

        public static async Task Load(ContentManager content) 
        {
            PlayerSprite = await Task.Run(() => content.Load<Texture2D>("PlayerSprite"));
            PlayerBulletSprite = await Task.Run(() => content.Load<Texture2D>("BulletPlayer"));
            OnLoadCompleted?.Invoke();
        }
    }
}
