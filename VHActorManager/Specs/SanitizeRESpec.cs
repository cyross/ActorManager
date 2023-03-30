namespace VHActorManager.Specs
{
    internal class SanitizeRESpec
    {
        public int Id { get; set; }
        public string Pattern { get; set; }
        public string Sub { get; set; }

        public SanitizeRESpec() {
            Id = -1;
            Pattern = string.Empty;
            Sub = string.Empty;
        }

        public SanitizeRESpec Duplicate(
            int? id = null,
            string? pattern = null,
            string? sub = null
            )
        {
            return new SanitizeRESpec()
            {
                Id = id ?? this.Id,
                Pattern = pattern ?? this.Pattern,
                Sub = sub ?? this.Sub
            };
        }
    }
}
