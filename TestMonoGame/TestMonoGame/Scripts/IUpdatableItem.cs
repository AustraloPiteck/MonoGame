using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMonoGame.Scripts
{
    internal interface IUpdatableItem
    {
        void OnUpdate(float deltaTime);
    }
}
