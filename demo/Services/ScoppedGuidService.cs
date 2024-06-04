namespace demo.Services
{
    public class ScoppedGuidService : IScoppedGuidServices
    {

        private readonly Guid Id;

        public ScoppedGuidService()
        {
            Id = Guid.NewGuid();
        }


        public string GetGuid()
        {
            return Id.ToString();
        }
    }
}
