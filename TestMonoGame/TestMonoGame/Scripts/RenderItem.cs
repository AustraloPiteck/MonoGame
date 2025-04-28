using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace TestMonoGame.Scripts
{
    internal struct RenderItem
    {
        public readonly Texture2D Texture;
        public readonly Vector2 Position;
        public readonly Rectangle? Rectangle;
        public readonly Color Color;
        public readonly float Rotation;
        public readonly Vector2 RotationOrigin;
       
        public RenderItem(Texture2D Tex,ref Vector2 Pos,
            Color Col,ref float Rot,ref Vector2 RotOrigin)
        {
            Texture = Tex; 
            Position = Pos; 
            Color = Col; 
            Rotation = Rot;
            RotationOrigin = RotOrigin;
        }
        public RenderItem(Texture2D Tex, ref Vector2 Pos, Rectangle rect,
           Color Col, ref float Rot, ref Vector2 RotOrigin)
        {
            Texture = Tex;
            Position = Pos;
            Rectangle = rect;
            Color = Col;
            Rotation = Rot;
            RotationOrigin = RotOrigin;
        }
    }
}
