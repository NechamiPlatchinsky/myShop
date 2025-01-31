using Microsoft.EntityFrameworkCore;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMyShop
{
    public class DatabaseFixture
    {
        public _214416448WebApiContext Context { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<_214416448WebApiContext>()
                .UseSqlServer("Server=srv2\\pupils;Database=Tests;Trusted_Connection=True;")
                .Options;
            Context = new _214416448WebApiContext(options);
            Context.Database.EnsureCreated();

        }
        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
