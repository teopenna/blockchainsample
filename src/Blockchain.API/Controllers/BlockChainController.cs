using System;
using Blockchain.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Blockchain.API.Controllers
{
    [Produces("application/json")]
    [Route("api/blockchain")]
    public class BlockChainController : Controller
    {
        private IBlockChain _blockChain;

        public BlockChainController(IBlockChain blockChain)
        {
            _blockChain = blockChain ?? throw new ArgumentNullException(nameof(blockChain), "A valid BlockChain must be supplied.");
        }

        [HttpGet]
        public IActionResult GetBlockChain()
        {
            return Ok(_blockChain);
        }

        [HttpPut("{blockId}")]
        public IActionResult MineBlock(int blockId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _blockChain.MineBlock(blockId);

                return Ok(_blockChain);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}