﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDev_Project2
{
    internal class Gold:Item
    {
       
       private int CurrentGold;
       private Random random;


        public Gold(int x, int y, int ValueOfGold ):base(x,y, TileType.Gold, 2, ValueOfGold)
        {

        }



        public override string ToString()
        {

            return String.Format("Current Gold:{0}",getCurrentGold());

        }

        public  string ToSaveString()
        {

            return String.Format("{0},{1},{2},{3}", TileType.Gold,GetX(), GetY(), getCurrentGold());

        }
    }
}
