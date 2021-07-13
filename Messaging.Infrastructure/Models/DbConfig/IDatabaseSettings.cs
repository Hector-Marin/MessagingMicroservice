using System;
using System.Collections.Generic;
using System.Text;

namespace Messaging.Infrastructure.Models.DbConfig
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
