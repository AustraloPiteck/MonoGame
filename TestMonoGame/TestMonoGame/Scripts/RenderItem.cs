using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;


namespace TestMonoGame.Scripts
{
    internal struct RenderItem
    {
        public readonly Texture2D Texture;
        public readonly Rectangle? Rectangle;
        public readonly Color Color;
        public readonly Vector2 Scale;
        public Func<Vector2> GetPosition;
        public Func<float> GetRotation;
        public Vector2 GetOrigin;
        public (SpriteEffects, SpriteEffects) Flip;

        public RenderItem(Texture2D Texture, Func<Vector2> GetPosition,
            Color Color, Func<float> GetRotation, Vector2 GetOrigin, 
            Vector2 Scale, (SpriteEffects, SpriteEffects) Flip)
        {
            this.Texture = Texture; 
            this.Color = Color;
            this.Scale = Scale;
            this.GetPosition = GetPosition;
            this.GetRotation = GetRotation;
            this.GetOrigin = GetOrigin;
            this.Flip = Flip;
        }
      
        public RenderItem(Texture2D Texture, Func<Vector2> GetPosition,Rectangle Rectangle,
             Color Color, Func<float> GetRotation, Vector2 GetOrigin,
             Vector2 Scale, (SpriteEffects, SpriteEffects) Flip)
        {
            this.Texture = Texture;
            this.Color = Color;
            this.Scale = Scale;
            this.Rectangle = Rectangle;
            this.GetPosition = GetPosition;
            this.GetRotation = GetRotation;
            this.GetOrigin = GetOrigin;
            this.Flip = Flip;
        }
    }
}
