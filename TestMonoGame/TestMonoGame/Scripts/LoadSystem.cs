
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Net.Mime;

namespace TestMonoGame.Scripts
{
    internal static class LoadSystem
    {
        public static Texture2D PlayerSprite {  get; private set; }


        public static void Load(ContentManager content) 
        {
            PlayerSprite = content.Load<Texture2D>("PlayerSprite");
        }
    }
}
