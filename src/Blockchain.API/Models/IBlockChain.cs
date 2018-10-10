using System.Collections.Generic;

namespace Blockchain.API.Models
{
    public interface IBlockChain
    {
        LinkedList<Block> Chain { get; }

        void MineBlock(int blockId);
    }
}
