using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockchain.API.Models
{
    public class BlockChain
    {
        public LinkedList<Block> Chain { get; private set; }

        public BlockChain()
        {
            var firstBlock = new Block(1, string.Empty);

            Chain = new LinkedList<Block>();
            Chain.AddFirst(firstBlock);
        }
    }
}
