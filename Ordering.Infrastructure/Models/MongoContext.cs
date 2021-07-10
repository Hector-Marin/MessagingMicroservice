using Messaging.Domain.SharedKernel;
using Messaging.Infrastructure.Models.DbConfig;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messaging.Infrastructure.Models
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly IClientSessionHandle _session = null;
        private bool disposedValue;

        public MongoContext(IDatabaseSettings settings)
        {
            
            var client = new MongoClient(settings.ConnectionString);
            if (client != null)
            {
                _database = client.GetDatabase(settings.DatabaseName);
                _session = client.StartSession();
                _session.StartTransaction(new TransactionOptions(
                        readConcern: ReadConcern.Snapshot,
                        writeConcern: WriteConcern.WMajority,
                        readPreference: ReadPreference.Primary)
                    );
            }
                
            _database.RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();
            
        }

        public IMongoCollection<MessageMongo> Messages
        {
            get
            {
                return _database.GetCollection<MessageMongo>("Messages");
            }
        }

        public IClientSessionHandle Session
        {
            get
            {
                return _session;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _session.CommitTransactionAsync(cancellationToken);
                return 1;
            }
            catch(Exception ex)
            {
                await _session.AbortTransactionAsync(cancellationToken);
                return 0;
            }
            
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _session.CommitTransactionAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                await _session.AbortTransactionAsync(cancellationToken);
                return false;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: eliminar el estado administrado (objetos administrados)
                }

                // TODO: liberar los recursos no administrados (objetos no administrados) y reemplazar el finalizador
                // TODO: establecer los campos grandes como NULL
                disposedValue = true;
            }
        }

        // // TODO: reemplazar el finalizador solo si "Dispose(bool disposing)" tiene código para liberar los recursos no administrados
        // ~MessageContext()
        // {
        //     // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en el método "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
