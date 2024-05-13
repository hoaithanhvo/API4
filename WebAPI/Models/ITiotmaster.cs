namespace WebAPI.Models
    {
    public class ITiotmasterView
        {
        public int? Id { get; set; }
        public string MoldNo { get; set; }
        public string MoldName { get; set; }
        public string MoldSerial { get; set; }
        public decimal? StackQty { get; set; }
        public decimal? CavQty { get; set; }
        public string MaterialType { get; set; }
        public string MaterialUsage { get; set; }
        public decimal? ReycleRatio { get; set; }
        public string MachineCd { get; set; }
        public int? MachineStatus { get; set; }
        public decimal? MaintenanceShot { get; set; }
        public decimal? MaintenanceQty { get; set; }
        public decimal? ScrapShot { get; set; }
        public decimal? ScrapQty { get; set; }
        }

    public class ITiotmaster: ITiotmasterView
        {
        public int? Id { get; set; }
        }
    }
