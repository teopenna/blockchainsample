using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockchain.API.Models
{
    public class BlockChain : IBlockChain
    {
        public LinkedList<Block> Chain { get; private set; }

        public BlockChain()
        {
            var firstBlock = new Block(1, string.Empty);

            Chain = new LinkedList<Block>();
            Chain.AddFirst(firstBlock);
        }

        public void MineBlock(int blockId)
        {
            var blockToBeMined = Chain.FirstOrDefault(b => b.Id == blockId);
            if (blockToBeMined == null)
            {
                throw new ApplicationException($"Block with id {blockId} not found!");
            }

            var blockHash = blockToBeMined.MineBlock(2);

            if (blockToBeMined.IsMined)
            {
                var blockList = Chain.Find(blockToBeMined);
                if (blockList.Next == null)
                {
                    var newBlock = new Block(blockId + 1, blockHash);
                    Chain.AddAfter(blockList, newBlock);
                }
            }
        }
    }
}
