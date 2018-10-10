using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blockchain.API.Models
{
    public class Block
    {
        public int Id { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public string PreviousHash { get; private set; }
        public string Data { get; set; }
        public int Nonce { get; private set; }
        public string Hash { get; private set; }
        public bool IsMined { get; private set; }

        public Block(int id, string previousHash)
        {
            Id = id;
            TimeStamp = DateTime.UtcNow;
            PreviousHash = previousHash;
        }

        public string MineBlock(int difficulty)
        {
            if (IsMined) throw new ApplicationException("Block is already mined!");

            SHA256 sha256 = SHA256.Create();
            var blockMined = false;
            var nonce = 0;

            while (!blockMined)
            {
                var blockData = $"{TimeStamp}-{nonce}-{PreviousHash ?? string.Empty}-{Data}";
                var inputBytes = Encoding.UTF8.GetBytes(blockData);
                var hashedBytes = sha256.ComputeHash(inputBytes);

                var hashedData = Convert.ToBase64String(hashedBytes);
                var startHashedString = new string('0', difficulty);
                if (hashedData.StartsWith(startHashedString))
                {
                    blockMined = true;
                    Nonce = nonce;
                    Hash = hashedData;
                }
                nonce += 1;
            }

            IsMined = true;

            return Hash;
        }
    }
}
