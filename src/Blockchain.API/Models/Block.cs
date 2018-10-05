using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blockchain.API.Models
{
    public class Block
    {
        public int Id { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public string PreviousHash { get; private set; }
        public string Data { get; set; }
        public int Nonce { get; set; }
        public string Hash { get; set; }

        public Block(int id, string previousHash)
        {
            Id = id;
            TimeStamp = DateTime.UtcNow;
            PreviousHash = previousHash;
        }
    }
}
