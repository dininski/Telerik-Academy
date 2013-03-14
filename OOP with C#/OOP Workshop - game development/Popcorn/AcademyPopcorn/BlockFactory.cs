using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class BlockFactory
    {
        public static Block GetBlock(int type, MatrixCoords coords)
        {
            switch (type)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    return new Block(coords);
                case 7:
                    return new UnpassableBlock(coords);
                case 8:
                    return new GiftBlock(coords);
                case 9:
                    return new ExplodingBlock(coords);
                default:
                    return new Block(coords);
            }
        }
    }
}
