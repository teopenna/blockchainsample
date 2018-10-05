using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blockchain.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.API.Controllers
{
    [Route("api/blockchain")]
    public class BlockChainController : Controller
    {
        private BlockChain _blockChain;

        public BlockChainController(BlockChain blockChain)
        {
            _blockChain = blockChain ?? throw new ArgumentNullException(nameof(blockChain), "A valid BlockChain must be supplied.");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}