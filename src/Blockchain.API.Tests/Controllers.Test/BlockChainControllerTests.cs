using Blockchain.API.Controllers;
using Blockchain.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Blockchain.API.Tests.Controllers.Test
{
    public class BlockChainControllerTests
    {
        protected BlockChainController Sut { get;  }

        public BlockChainControllerTests()
        {
            IBlockChain blockChain = new BlockChain();
            blockChain.Chain.First.Value.Data = "First Block Data";

            Sut = new BlockChainController(blockChain);
        }

        [Fact]
        public void ControllerWithNullBlockChainShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new BlockChainController(null));
        }

        public class GetBlockChain : BlockChainControllerTests
        {
            [Fact]
            public void ShouldReturnOkWithBlockChainContent()
            {
                var result = Sut.GetBlockChain();
                var okResult = Assert.IsType<OkObjectResult>(result);
                var okResultValue = Assert.IsAssignableFrom<BlockChain>(okResult.Value);
                Assert.Single(okResultValue.Chain);
            }
        }

        public class Mine : BlockChainControllerTests
        {
            [Fact]
            public void ShouldReturnOkWithANewBlockWhenLastBlockIsMined()
            {
                var result = Sut.MineBlock(1);
                var okResult = Assert.IsType<OkObjectResult>(result);
                var okResultValue = Assert.IsAssignableFrom<BlockChain>(okResult.Value);
                var minedBlock = okResultValue.Chain.FirstOrDefault(b => b.Id == 1);
                Assert.True(minedBlock.IsMined);
                Assert.Equal(2, okResultValue.Chain.Count);
            }
        }
    }
}
