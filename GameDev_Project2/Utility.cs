using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameDev_Project2
{
    class Utility
    {
        
           public FileStream saveFile = new FileStream(Directory.GetCurrentDirectory() + "/save.File", FileMode.Create);
        
        public void CreateReader()
        {
            BinaryReader reader = new BinaryReader(saveFile);
        }

        public void CreateWriter()
        {
           
        }

        
    }
}
