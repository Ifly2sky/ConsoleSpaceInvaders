using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders.Image
{
    public class Chunk
    {
        public List<Block> blocks = new();

        public Block
            middleBlock = new(),
            leftBlock = new(),
            rightBlock = new(),
            bottomBlock = new(),
            topBlock = new(),
            topLeftBlock = new(),
            topRightBlock = new(),
            bottomLeftBlock = new(),
            bottomRightBlock = new();

        public Chunk(string chars)
        {
            try
            {
                middleBlock.character = chars[0];
                leftBlock.character = chars[1];
                rightBlock.character = chars[2];
                bottomBlock.character = chars[3];
                topBlock.character = chars[4];

                topLeftBlock.character = chars[5];
                topRightBlock.character = chars[6];
                bottomLeftBlock.character = chars[7];
                bottomRightBlock.character = chars[8];
            }
            catch (Exception) { }

            leftBlock.x = -1;
            rightBlock.x = 1;
            bottomBlock.y = 1;
            topBlock.y = -1;

            topLeftBlock.x = -1;
            topLeftBlock.y = -1;
            topRightBlock.x = 1;
            topRightBlock.y = -1;
            bottomLeftBlock.x = -1;
            bottomLeftBlock.y = 1;
            bottomRightBlock.x = 1;
            bottomRightBlock.y = 1;

            blocks.Add(middleBlock);
            blocks.Add(leftBlock);
            blocks.Add(rightBlock);
            blocks.Add(bottomBlock);
            blocks.Add(topBlock);
            blocks.Add(topLeftBlock);
            blocks.Add(topRightBlock);
            blocks.Add(bottomLeftBlock);
            blocks.Add(bottomRightBlock);
        }
    }
}
