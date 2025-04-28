using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonoGame.Scripts
{
    internal class PlayerFabric
    {
        public PlayerController Create(InputManager inputManager, Game1 game) 
        {
            PlayerController controller = new PlayerController(game);
            inputManager._movementValue += controller.MoveInput;
            inputManager._mousePosValue += controller.MouseInput;
            inputManager._shootAction += controller.OnShoot;

            return controller;
        }
    }
}
