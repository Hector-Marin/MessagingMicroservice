using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Infrastructure.Models.DbConfig
{
    public class MongoDbSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
