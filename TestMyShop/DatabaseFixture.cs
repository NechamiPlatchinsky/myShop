using Microsoft.EntityFrameworkCore;
using Reposetories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TestMyShop
{
    public class DataBaseFixture : IDisposable
    {
        public _214416448WebApiContext Context { get; private set; }
        public DataBaseFixture()
        {
            var options = new DbContextOptionsBuilder<_214416448WebApiContext>()
                .UseSqlServer("Server = SRV2\\PUPILS; Database = myTest; Trusted_Connection = True; TrustServerCertificate = True")
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
