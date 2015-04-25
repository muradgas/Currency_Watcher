using System.Runtime.Serialization;

namespace Currency_Watcher.Dto
{
    [DataContract(Name = "QueryRoot")]
    public class QueryRoot
    {
        [DataMember(Name = "query")]
        public Query Query { get; set; }
    }

    [DataContract(Name = "Query")]
    public class Query
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "created")]
        public string Created { get; set; }

        [DataMember(Name = "lang")]
        public string Lang { get; set; }

        [DataMember(Name = "results")]
        public Results Results { get; set; }
    }

    [DataContract(Name = "Results")]
    public class Results
    {
        [DataMember(Name = "rate")]
        public RateDetails Rate { get; set; }
    }

    [DataContract(Name = "RateDetails")]
    public class RateDetails
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "Name")]
        public string Name { get; set; }

        [DataMember(Name = "Rate")]
        public string Rate { get; set; }

        [DataMember(Name = "Date")]
        public string Date { get; set; }

        [DataMember(Name = "Time")]
        public string Time { get; set; }

        [DataMember(Name = "Ask")]
        public string Ask { get; set; }

        [DataMember(Name = "Bid")]
        public string Bid { get; set; }
    }
}