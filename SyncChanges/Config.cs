using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SyncChanges
{
    /// <summary>
    /// Represents configuration information for the replication of database changes.
    /// </summary>
    public class Config
    {
        public List<ReplicationSet> ReplicationSets { get; private set; } = [];
    }
    /// <summary>
    /// Represents a replication sets, i.e. the combination of a source database and one or more destination databases.
    /// </summary>
    public class ReplicationSet
    {
        public string Name { get; set; }
        public DatabaseInfo Source { get; set; }
        public List<DatabaseInfo> Destinations { get; private set; } = [];
        public List<string> Tables { get; set; } = [];
        public List<string> ExcludeTables { get; set; } = [];
        /// <summary>
        /// Gets or sets the Kafka endpoints configuration
        /// </summary>
        public List<KafkaEndpoint> KafkaEndpoints { get; set; } = [];
    }
    /// <summary>
    /// Represents information about a database.
    /// </summary>
    public class DatabaseInfo
    {
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }

    /// <summary>
    /// Represents Kafka endpoint configuration
    /// </summary>
    public class KafkaEndpoint
    {
        /// <summary>
        /// Gets or sets the Kafka broker address
        /// </summary>
        public string Broker { get; set; }

        /// <summary>
        /// Gets or sets the Kafka topic name
        /// </summary>
        public string Topic { get; set; }
    }
}
