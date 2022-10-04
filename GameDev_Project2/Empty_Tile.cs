using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    internal class Empty_Tile : Tile
    {
        public Empty_Tile(int X, int Y) : base(X, Y, TileType.Empty, 5)
        {
        }
    }
}
