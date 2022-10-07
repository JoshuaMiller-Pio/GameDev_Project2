using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    public abstract class Item : Tile
    {
        public Item(int x, int y, TileType type, int SymbolIndex) : base(x, y, type, SymbolIndex)
        {

        }
        public abstract override string ToString();
    }
}
